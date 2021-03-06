﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;

namespace TerraTeam3
{

    class Program
    {

        private static Timer aTimer;
        private static bool tijdOverschreden = false;

        public static void SetTimer()
        {
            aTimer = new Timer(200);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = false;
        }

        public static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            tijdOverschreden = true;
        }

        static void Main(string[] args)
        {
            Console.WindowWidth = 120;

            ShowIntro();

            Console.ReadKey();

            Console.Clear();

            // Startwaardes
            Random rnd = new Random();
            var aantalPlanten = Parameter.AantalPlanten;
            var aantalHerbivoren = Parameter.AantalHerbivoren;
            var aantalCarnivoren = Parameter.AantalCarnivoren;
            var aantalMensen = Parameter.AantalMensen;


            // Onze matrix van "vandaag"
            Matrix laatsteMatrix = new Matrix();

            SetTimer();
            // Onze matrix van "gisteren" - Leeg in startsituatie
            Matrix voorgaandeMatrix = new Matrix();

            // Aanmaken planten
            for (var lus = 0; lus < aantalPlanten; lus++)
            {
                var toeTeVoegenPlant = new Plant();
                laatsteMatrix.VoegItemToe(toeTeVoegenPlant);
            }

            // Aanmaken herbivoren
            for (var lus = 0; lus < aantalHerbivoren; lus++)
            {
                var toeTeVoegenHerbivoor = new Herbivoor();
                laatsteMatrix.VoegItemToe(toeTeVoegenHerbivoor);
            }

            // Aanmaken carnivoren
            for (var lus = 0; lus < aantalCarnivoren; lus++)
            {
                var toeTeVoegenCarnivoor = new Carnivoor();
                laatsteMatrix.VoegItemToe(toeTeVoegenCarnivoor);
            }

            // Aanmaken mensen
            // SELECTIE OP BASIS VAN TIJDSLIJN HIERONDER
            // if (tijdslijnMensAanwezig == true) {
            for (var lus = 0; lus < aantalMensen; lus++)
            {
                var toeTeVoegenMens = new Mens();
                laatsteMatrix.VoegItemToe(toeTeVoegenMens);
            }
            // }

            // Eerste weergave
            // De matrix van "gisteren" weergeven - Leeg in startsituatie
            GeefSituatieWeer(voorgaandeMatrix, "Vorige situatie:");

            Console.WriteLine();
            Console.WriteLine();

            // De matrix van "vandaag" weergeven
            GeefSituatieWeer(laatsteMatrix, "Huidige situatie:");


            string input = ".";

            do
            {
                tijdOverschreden = false;
                do
                {

                    Console.WriteLine();
                    Console.WriteLine("  Kies een commando:");
                    Console.WriteLine();
                    Console.WriteLine("   [ v + enter : Bekijk de volgende dag ]");
                    Console.WriteLine("   [ s + enter : Stoppen ]");
                    Console.WriteLine("   [ o + enter : Spel opslaan ]");
                    Console.WriteLine("   [ l + enter : Opgeslagen spel laden ]");
                    Console.WriteLine("   [ t + enter : Automatisch mode starten/stoppen ]");

                    while (!Console.KeyAvailable && !tijdOverschreden)
                    { }
                    if (!tijdOverschreden)
                    {
                        input = Console.ReadLine();
                    }
                }
                while (input != "v" && input != "s" && input != "o" && input != "l" && input != "t" && !tijdOverschreden);

                Console.WriteLine();
                if (input == "t")
                {
                    input = ".";
                    if (aTimer.Enabled == false)
                    {
                        aTimer.Enabled = true;
                        Console.WriteLine("De automatische modus werd gestart");
                    }
                    else
                    {
                        aTimer.Enabled = false;
                        tijdOverschreden = false;
                        Console.WriteLine("De automatische modus werd gestopt");
                    }
                }

                if (input == "v" || tijdOverschreden)
                {
                    // Scherm leegmaken
                    Console.Clear();

                    // Matrix van gisteren weergeven
                    GeefSituatieWeer(laatsteMatrix, "Vorige situatie:");

                    var gesorteerdeMatrix = laatsteMatrix.GeefGesorteerdeLijst();
                    int toeTeVoegenHerbivorenBabies = 0;
                    int toeTeVoegenMensenBabies = 0;

                    laatsteMatrix.ResetIsVeranderd();

                    for (var x = 0; x < gesorteerdeMatrix.Count; x++)
                    {
                        var geselecteerditem = gesorteerdeMatrix[x];

                        var matrixItemBuurman = laatsteMatrix.GeefBuurmanRechts(geselecteerditem);

                        if (matrixItemBuurman != null)
                        {
                            // Herbivoor eet plant
                            if (geselecteerditem.Symbool == Parameter.HerbivoorTeken && matrixItemBuurman.Symbool == Parameter.PlantTeken && geselecteerditem.IsVeranderd == false)
                            {
                                var geselecteerdeHerbivoor = (Herbivoor)geselecteerditem;
                                geselecteerdeHerbivoor.Levenskracht++;

                                matrixItemBuurman.IsVeranderd = true;
                                geselecteerditem.IsVeranderd = true;

                                laatsteMatrix.Beweeg(geselecteerdeHerbivoor, matrixItemBuurman);
                            }

                            // Carnivoor eet herbivoor
                            if (geselecteerditem.Symbool == Parameter.CarnivoorTeken && matrixItemBuurman.Symbool == Parameter.HerbivoorTeken && geselecteerditem.IsVeranderd == false)
                            {
                                var geselecteerdeCarnivoor = (Carnivoor)geselecteerditem;
                                var buurmanHerbivoor = (Herbivoor)matrixItemBuurman;

                                matrixItemBuurman.IsVeranderd = true;
                                geselecteerditem.IsVeranderd = true;

                                geselecteerdeCarnivoor.Levenskracht += buurmanHerbivoor.Levenskracht;

                                laatsteMatrix.Beweeg(geselecteerdeCarnivoor, buurmanHerbivoor);
                            }

                            // Herbivoor vrijt met herbivoor
                            if (geselecteerditem.Symbool == Parameter.HerbivoorTeken && matrixItemBuurman.Symbool == Parameter.HerbivoorTeken)
                            {
                                toeTeVoegenHerbivorenBabies++;
                            }


                            // Carnivoor vecht met carnivoor
                            if (geselecteerditem.Symbool == Parameter.CarnivoorTeken && matrixItemBuurman.Symbool == Parameter.CarnivoorTeken && geselecteerditem.IsVeranderd == false)
                            {
                                var speler1 = (Carnivoor)geselecteerditem;
                                var speler2 = (Carnivoor)matrixItemBuurman;

                                if (speler1.Levenskracht > speler2.Levenskracht)
                                {
                                    speler1.IsVeranderd = true;

                                    speler1.Levenskracht += speler2.Levenskracht;
                                    laatsteMatrix.Beweeg(speler1, speler2);
                                }
                                else if (speler1.Levenskracht < speler2.Levenskracht)
                                {
                                    speler2.Levenskracht += speler1.Levenskracht;
                                    laatsteMatrix.VerwijderItem(speler1);
                                }
                            }

                            // Carnivoor vecht met mens
                            if (geselecteerditem.Symbool == Parameter.CarnivoorTeken && matrixItemBuurman.Symbool == Parameter.MensTeken && geselecteerditem.IsVeranderd == false)
                            {
                                var speler1 = (Carnivoor)geselecteerditem;
                                var speler2 = (Mens)matrixItemBuurman;

                                if (speler1.Levenskracht > speler2.Levenskracht)
                                {
                                    speler1.IsVeranderd = true;

                                    speler1.Levenskracht += speler2.Levenskracht;
                                    laatsteMatrix.Beweeg(speler1, speler2);
                                }
                                else
                                //if (speler1.Levenskracht <= speler2.Levenskracht)
                                {
                                    speler2.Levenskracht += speler1.Levenskracht;
                                    laatsteMatrix.VerwijderItem(speler1);
                                }
                            }


                            // Mens vecht met carnivoor
                            if (geselecteerditem.Symbool == Parameter.MensTeken && matrixItemBuurman.Symbool == Parameter.CarnivoorTeken && geselecteerditem.IsVeranderd == false)
                            {
                                var speler1 = (Mens)geselecteerditem;
                                var speler2 = (Carnivoor)matrixItemBuurman;

                                if (speler1.Levenskracht >= speler2.Levenskracht)
                                {
                                    speler1.IsVeranderd = true;
                                    // ADDED
                                    speler2.IsVeranderd = true;
                                    speler1.Levenskracht += speler2.Levenskracht;
                                    laatsteMatrix.Beweeg(speler1, speler2);
                                }
                                else if (speler1.Levenskracht < speler2.Levenskracht)
                                {
                                    speler2.Levenskracht += speler1.Levenskracht;
                                    laatsteMatrix.VerwijderItem(speler1);
                                }
                            }

                            // Mens vrijt met Mens
                            if (geselecteerditem.Symbool == Parameter.MensTeken && matrixItemBuurman.Symbool == Parameter.MensTeken)
                            {
                                toeTeVoegenMensenBabies++;
                            }

                            // Herbivoren, carnivoren en mensen bewegen
                            if ((geselecteerditem.Symbool == Parameter.CarnivoorTeken || geselecteerditem.Symbool == Parameter.HerbivoorTeken || geselecteerditem.Symbool == Parameter.MensTeken) && matrixItemBuurman.Symbool == Parameter.LeegItemTeken && geselecteerditem.IsVeranderd == false)
                            {
                                // Controle welke plaatse rondom vrij is
                                var matrixItemMogelijkheden = laatsteMatrix.geefLegePosities(geselecteerditem);

                                if (matrixItemMogelijkheden.Count() > 0)
                                {
                                    var randomGeselecteerdItem = matrixItemMogelijkheden[rnd.Next(0, matrixItemMogelijkheden.Count())];
                                    laatsteMatrix.Beweeg(geselecteerditem, randomGeselecteerdItem);
                                    randomGeselecteerdItem.IsVeranderd = true;
                                }
                                geselecteerditem.IsVeranderd = true;

                            }
                        }
                    }



                    int aantalPlaatsen;

                    // Babies herbivoren toevoegen
                    aantalPlaatsen = laatsteMatrix.AantalLegePosities();

                    if (toeTeVoegenHerbivorenBabies > aantalPlaatsen)
                    {
                        toeTeVoegenHerbivorenBabies = aantalPlaatsen;
                    }

                    for (var lus = 0; lus < toeTeVoegenHerbivorenBabies; lus++)
                    {
                        var toeTeVoegenHerbivoor = new Herbivoor();
                        toeTeVoegenHerbivoor.Levenskracht = 0;
                        laatsteMatrix.VoegItemToe(toeTeVoegenHerbivoor);
                    }


                    // Babies mensen toevoegen
                    aantalPlaatsen = laatsteMatrix.AantalLegePosities();

                    if (toeTeVoegenMensenBabies > aantalPlaatsen)
                    {
                        toeTeVoegenMensenBabies = aantalPlaatsen;
                    }

                    for (var lus = 0; lus < toeTeVoegenMensenBabies; lus++)
                    {
                        var toeTeVoegenMens = new Mens();
                        toeTeVoegenMens.Levenskracht = 1;
                        laatsteMatrix.VoegItemToe(toeTeVoegenMens);
                    }

                    // Planten ad random toevoegen
                    var aantalPlantenBijvoegen = Parameter.AantalPlantenBijvoegen;
                    aantalPlaatsen = laatsteMatrix.AantalLegePosities();

                    if (aantalPlantenBijvoegen > aantalPlaatsen - Parameter.MinAantalLeeg)
                    {
                        aantalPlantenBijvoegen = aantalPlaatsen - Parameter.MinAantalLeeg;
                    }

                    for (var lus = 0; lus < aantalPlantenBijvoegen; lus++)
                    {
                        var toeTeVoegenPlant = new Plant();
                        laatsteMatrix.VoegItemToe(toeTeVoegenPlant);
                    }


                    Console.WriteLine();
                    Console.WriteLine();
                    // De matrix van "vandaag" weergeven
                    GeefSituatieWeer(laatsteMatrix, "Huidige situatie:");
                }

                if (input == "o")
                {
                    input = ".";
                    try
                    {
                        using (var bestand = File.Open(@"Terrarium.obj", FileMode.OpenOrCreate))
                        //using (var bestand = File.Open(@"C:\Users\net06\Desktop\Terrarium.obj", FileMode.OpenOrCreate))
                        {
                            var schrijverMatrix = new BinaryFormatter();
                            schrijverMatrix.Serialize(bestand, laatsteMatrix.Items);
                        }
                        Console.WriteLine("Uw spel werd opgeslagen");
                        Console.WriteLine("Duw op enter om verder te gaan");
                        Console.Read();
                    }
                    catch (SerializationException)
                    {
                        Console.WriteLine("Fout bij het opslaan van de matrix");
                        Console.Read();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("User error, please replace user\n" + ex.Message);
                        Console.Read();
                    }
                }

                if (input == "l")
                {
                    input = ".";
                    Console.Clear();
                    try
                    {
                        using (var bestand = File.Open(@"Terrarium.obj", FileMode.OpenOrCreate))
                        //using (var bestand = File.Open(@"C:\Users\net06\Desktop\Terrarium.obj", FileMode.Open, FileAccess.Read))
                        {
                            var lezerMatrix = new BinaryFormatter();
                            List<MatrixItem> nieuweItems;
                            nieuweItems = (List<MatrixItem>)lezerMatrix.Deserialize(bestand);
                            laatsteMatrix.Items = nieuweItems;
                            GeefSituatieWeer(laatsteMatrix, "Opgeslagen spel:");
                        }
                        Console.WriteLine("Duw op enter om verder te gaan");
                        Console.Read();
                    }
                    catch (SerializationException)
                    {
                        Console.WriteLine("Fout bij het openen van de opgeslagen matrix");
                        Console.Read();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Djuu, het lukt nie!/n" + ex.Message);
                        Console.Read();
                    }

                }

                tijdOverschreden = false;
            }
            while (input != "s");
        }

        // Method om Matrix weer te geven
        public static void GeefSituatieWeer(Matrix mijnMatrix, string titel)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(titel);
            Console.WriteLine();
            mijnMatrix.GeefWeer();
        }


        public static void ShowIntro()
        {
            Console.WindowWidth = 110;


            string text = System.IO.File.ReadAllText(@"intro1.txt");

            for (int i = 0; i < text.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                if (text[i] == '@')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(text[i]);
            }

            Console.WriteLine();



            string text2 = System.IO.File.ReadAllText(@"intro2.txt");

            for (int i = 0; i < text2.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                if (text2[i] == '╝' || text2[i] == '═' || text2[i] == '║' || text2[i] == '╗' || text2[i] == '╚' || text2[i] == '╔')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                Console.Write(text2[i]);
            }

            Console.WriteLine();



            string text3 = System.IO.File.ReadAllText(@"intro3.txt");

            for (int i = 0; i < text3.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                if (text3[i] == '╝' || text3[i] == '═' || text3[i] == '║' || text3[i] == '╗' || text3[i] == '╚' || text3[i] == '╔')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(text3[i]);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                 [ DRUK OP EEN ");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("TOETS");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" OM VERDER TE GAAN ]");
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}


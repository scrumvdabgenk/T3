using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TerraTeam3
{

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            var aantalPlanten = Parameter.AantalPlanten;
            var aantalHerbivoren = Parameter.AantalHerbivoren;
            var aantalCarnivoren = Parameter.AantalCarnivoren;
            var aantalMensen = Parameter.AantalMensen;


            Matrix mijnMatrix = new Matrix();


            // Aanmaken planten
            for (var lus = 0; lus < aantalPlanten; lus++)
            {
                var toeTeVoegenPlant = new Plant();
                mijnMatrix.VoegItemToe(toeTeVoegenPlant);
            }

            // Aanmaken herbivoren
            for (var lus = 0; lus < aantalHerbivoren; lus++)
            {
                var toeTeVoegenHerbivoor = new Herbivoor();
                mijnMatrix.VoegItemToe(toeTeVoegenHerbivoor);
            }

            // Aanmaken carnivoren
            for (var lus = 0; lus < aantalCarnivoren; lus++)
            {
                var toeTeVoegenCarnivoor = new Carnivoor();
                mijnMatrix.VoegItemToe(toeTeVoegenCarnivoor);
            }

            // Aanmaken mensen
            for (var lus = 0; lus < aantalMensen; lus++)
            {
                var toeTeVoegenMens = new Mens();
                mijnMatrix.VoegItemToe(toeTeVoegenMens);
            }

            // Eerste weergave
            mijnMatrix.GeefWeer();

            string input;

            do
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Geef een commando:");
                    Console.WriteLine("- v + enter om de volgende dag te zien");
                    Console.WriteLine("- s + enter om te stoppen");
                    Console.WriteLine("- o + enter om op te slaan");
                    Console.WriteLine("- l + enter om een opgeslagen spel te laden");
                    input = Console.ReadLine();

                } while (input != "v" && input != "s" && input != "o" && input != "l");

                Console.WriteLine();

                if (input == "v")
                {
                    var gesorteerdeMatrix = mijnMatrix.GeefGesorteerdeLijst();
                    int toeTeVoegenBabies = 0;

                    mijnMatrix.ResetIsVeranderd();

                    for (var x = 0; x < gesorteerdeMatrix.Count; x++)
                    {
                        var geselecteerditem = gesorteerdeMatrix[x];

                        var matrixItemBuurman = mijnMatrix.GeefBuurmanRechts(geselecteerditem);

                        if (matrixItemBuurman != null)
                        {
                            // Herbivoor eet plant
                            if (geselecteerditem.Symbool == Parameter.HerbivoorTeken && matrixItemBuurman.Symbool == Parameter.PlantTeken && geselecteerditem.IsVeranderd == false)
                            {
                                var geselecteerdeHerbivoor = (Herbivoor)geselecteerditem;
                                geselecteerdeHerbivoor.Levenskracht++;

                                matrixItemBuurman.IsVeranderd = true;
                                geselecteerditem.IsVeranderd = true;

                                mijnMatrix.Beweeg(geselecteerdeHerbivoor, matrixItemBuurman);
                            }

                            // Carnivoor eet herbivoor
                            if (geselecteerditem.Symbool == Parameter.CarnivoorTeken && matrixItemBuurman.Symbool == Parameter.HerbivoorTeken && geselecteerditem.IsVeranderd == false)
                            {
                                var geselecteerdeCarnivoor = (Carnivoor)geselecteerditem;
                                var buurmanHerbivoor = (Herbivoor)matrixItemBuurman;

                                matrixItemBuurman.IsVeranderd = true;
                                geselecteerditem.IsVeranderd = true;

                                geselecteerdeCarnivoor.Levenskracht += buurmanHerbivoor.Levenskracht;

                                mijnMatrix.Beweeg(geselecteerdeCarnivoor, buurmanHerbivoor);
                            }

                            // Herbivoor vrijt met herbivoor
                            if (geselecteerditem.Symbool == Parameter.HerbivoorTeken && matrixItemBuurman.Symbool == Parameter.HerbivoorTeken)
                            {
                                toeTeVoegenBabies++;
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
                                    mijnMatrix.Beweeg(speler1, speler2);
                                }
                                else if (speler1.Levenskracht < speler2.Levenskracht)
                                {
                                    speler2.Levenskracht += speler1.Levenskracht;
                                    mijnMatrix.VerwijderItem(speler1);
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

                                    speler1.Levenskracht += speler2.Levenskracht;
                                    mijnMatrix.Beweeg(speler1, speler2);
                                }
                                else if (speler1.Levenskracht < speler2.Levenskracht)
                                {
                                    speler2.Levenskracht += speler1.Levenskracht;
                                    mijnMatrix.VerwijderItem(speler1);
                                }
                            }

                            // Herbivoren, carnivoren en mensen bewegen
                            if ((geselecteerditem.Symbool == Parameter.CarnivoorTeken || geselecteerditem.Symbool == Parameter.HerbivoorTeken || geselecteerditem.Symbool == Parameter.MensTeken) && matrixItemBuurman.Symbool == Parameter.LeegItemTeken && geselecteerditem.IsVeranderd == false)
                            {
                                // Controle welke plaatse rondom vrij is
                                var matrixItemMogelijkheden = mijnMatrix.geefLegePosities(geselecteerditem);

                                if (matrixItemMogelijkheden.Count() > 0)
                                {
                                    var randomGeselecteerdItem = matrixItemMogelijkheden[rnd.Next(0, matrixItemMogelijkheden.Count())];
                                    mijnMatrix.Beweeg(geselecteerditem, randomGeselecteerdItem);
                                    randomGeselecteerdItem.IsVeranderd = true;
                                }
                                geselecteerditem.IsVeranderd = true;

                            }
                        }
                    }

                    

                    int aantalPlaatsen;

                    // Babies herbivoren toevoegen
                    aantalPlaatsen = mijnMatrix.AantalLegePosities();

                    if (toeTeVoegenBabies > aantalPlaatsen)
                    {
                        toeTeVoegenBabies = aantalPlaatsen;
                    }

                    for (var lus = 0; lus < toeTeVoegenBabies; lus++)
                    {
                        var toeTeVoegenHerbivoor = new Herbivoor();
                        toeTeVoegenHerbivoor.Levenskracht = 0;
                        mijnMatrix.VoegItemToe(toeTeVoegenHerbivoor);
                    }

                    // Planten ad random toevoegen
                    var aantalPlantenBijvoegen = Parameter.AantalPlantenBijvoegen;
                    aantalPlaatsen = mijnMatrix.AantalLegePosities();

                    if (aantalPlantenBijvoegen > aantalPlaatsen - Parameter.MinAantalLeeg)
                    {
                        aantalPlantenBijvoegen = aantalPlaatsen - Parameter.MinAantalLeeg;
                    }

                    for (var lus = 0; lus < aantalPlantenBijvoegen; lus++)
                    {
                        var toeTeVoegenPlant = new Plant();
                        mijnMatrix.VoegItemToe(toeTeVoegenPlant);
                    }


                    Console.Clear();
                    mijnMatrix.GeefWeer();
                }

                if (input == "o")
                {
                    try
                    {
                        using (var bestand = File.Open(@"C:\Data\Terrarium.obj", FileMode.OpenOrCreate))
                        //using (var bestand = File.Open(@"C:\Users\net06\Desktop\Terrarium.obj", FileMode.OpenOrCreate))
                        {
                            var schrijverMatrix = new BinaryFormatter();
                            schrijverMatrix.Serialize(bestand, mijnMatrix.Items);                            
                        }
                        Console.WriteLine("Uw spel werd opgeslagen");
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
                    Console.Clear();
                    try
                    {
                        using (var bestand = File.Open(@"C:\Data\Terrarium.obj", FileMode.OpenOrCreate))
                        //using (var bestand = File.Open(@"C:\Users\net06\Desktop\Terrarium.obj", FileMode.Open, FileAccess.Read))
                        {
                            var lezerMatrix = new BinaryFormatter();
                            List<MatrixItem> nieuweItems;
                            nieuweItems = (List<MatrixItem>)lezerMatrix.Deserialize(bestand);
                            mijnMatrix.Items = nieuweItems;
                            mijnMatrix.GeefWeer();
                        }
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

            }
            while (input == "v" || input == "o" || input == "l");
                        
        }
    }
}


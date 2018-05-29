using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int aantalPlantenBijvoegen;

            Matrix mijnMatrix = new Matrix();


            for (var lus = 0; lus < aantalPlanten; lus++)
            {
                var toeTeVoegenPlant = new Plant();
                mijnMatrix.VoegItemToe(toeTeVoegenPlant);
            }

            for (var lus = 0; lus < aantalHerbivoren; lus++)
            {
                var toeTeVoegenHerbivoor = new Herbivoor();
                mijnMatrix.VoegItemToe(toeTeVoegenHerbivoor);
            }

            for (var lus = 0; lus < aantalCarnivoren; lus++)
            {
                var toeTeVoegenCarnivoor = new Carnivoor();
                mijnMatrix.VoegItemToe(toeTeVoegenCarnivoor);
            }

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
                    input = Console.ReadLine();

                } while (input != "v" && input != "s");

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
                            if (geselecteerditem.Symbool == 'H' && matrixItemBuurman.Symbool == 'P' && geselecteerditem.IsVeranderd == false)
                            {
                                var geselecteerdeHerbivoor = (Herbivoor)geselecteerditem;
                                geselecteerdeHerbivoor.Levenskracht++;

                                matrixItemBuurman.IsVeranderd = true;
                                geselecteerditem.IsVeranderd = true;

                                mijnMatrix.Beweeg(geselecteerdeHerbivoor, matrixItemBuurman);
                            }

                            // Carnivoor eet herbivoor
                            if (geselecteerditem.Symbool == Parameter.CarnivoorTeken && matrixItemBuurman.Symbool == Parameter.HerbivoorTeken && geselecteerditem.IsVeranderd == false)
                            //if (geselecteerditem.Symbool == 'C' && matrixItemBuurman.Symbool == 'H' && geselecteerditem.IsVeranderd == false)
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
                            //if (geselecteerditem.Symbool == 'H' && matrixItemBuurman.Symbool == 'H')
                            {
                                toeTeVoegenBabies++;
                            }


                            // Carnivoor vecht met carnivoor
                            if (geselecteerditem.Symbool == Parameter.CarnivoorTeken && matrixItemBuurman.Symbool == Parameter.CarnivoorTeken && geselecteerditem.IsVeranderd == false)
                            //if (geselecteerditem.Symbool == 'C' && matrixItemBuurman.Symbool == 'C' && geselecteerditem.IsVeranderd == false)
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

                            // Herbivoren en carnivoren bewegen
                            if ((geselecteerditem.Symbool == Parameter.CarnivoorTeken || geselecteerditem.Symbool == Parameter.HerbivoorTeken) && matrixItemBuurman.Symbool == '.' && geselecteerditem.IsVeranderd == false)
                            //if ((geselecteerditem.Symbool == 'C' || geselecteerditem.Symbool == 'H') && matrixItemBuurman.Symbool == '.' && geselecteerditem.IsVeranderd == false)
                            {
                                // Controle welke vrij is
                                var matrixMogelijkePosities = mijnMatrix.geefLegePosities(geselecteerditem);

                                if (matrixMogelijkePosities.Count() > 0)
                                {
                                    var randomGeselecteerdItem = matrixMogelijkePosities[rnd.Next(0, matrixMogelijkePosities.Count())];
                                    mijnMatrix.Beweeg(geselecteerditem, randomGeselecteerdItem);
                                    randomGeselecteerdItem.IsVeranderd = true;
                                }
                                geselecteerditem.IsVeranderd = true;
                            }
                        }
                    }
                    // HH Babies toevoegen

                    // Nieuwe planten toevoegen
                    Console.Clear();
                    mijnMatrix.GeefWeer();
                }
            }
            while (input == "v");
        }
    }
}


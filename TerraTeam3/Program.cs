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
            var aantalPlanten = 4;
            var aantalHerbivoren = 4;
            var aantalCarnivoren = 4;

            Matrix mijnMatrix = new Matrix(6, 6);


            for (var lus = 0; lus <= aantalPlanten; lus++)
            {
                var toeTeVoegenPlant = new Plant();
                mijnMatrix.VoegItemToe(toeTeVoegenPlant);
            }

            for (var lus = 0; lus <= aantalHerbivoren; lus++)
            {
                var toeTeVoegenHerbivoor = new Herbivoor();
                mijnMatrix.VoegItemToe(toeTeVoegenHerbivoor);
            }

            for (var lus = 0; lus <= aantalCarnivoren; lus++)
            {
                var toeTeVoegenCarnivoor = new Carnivoor();
                mijnMatrix.VoegItemToe(toeTeVoegenCarnivoor);
            }

            mijnMatrix.GeefWeer();

            string input;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Geef een commando:");
                Console.WriteLine("- v + enter om de volgende dag te zien");
                Console.WriteLine("- s + enter om te stoppen");
                input = Console.ReadLine();

            } while (input != "v" && input != "s");


            if (input == "v")
            {
                var gesorteerdeMatrix = mijnMatrix.GeefGesorteerdeLijst();
                int toeTeVoegenBabies = 0;

                for (var x = 0; x < gesorteerdeMatrix.Count; x++)
                {
                    var geselecteerditem = gesorteerdeMatrix[x];


                    var matrixItemBuurman = mijnMatrix.GeefBuurmanRechts(geselecteerditem);

                    if (matrixItemBuurman != null)
                    {

                        // Herbivoor eet plant
                        if (geselecteerditem.Symbool == 'H' && matrixItemBuurman.Symbool == 'P')
                        {
                            var geselecteerdeHerbivoor = (Herbivoor)geselecteerditem;
                            geselecteerdeHerbivoor.Levenskracht++;

                            mijnMatrix.BeweegNaarRechts(geselecteerdeHerbivoor, matrixItemBuurman);
                        }

                        // Carnivoor eet herbivoor
                        if (geselecteerditem.Symbool == 'C' && matrixItemBuurman.Symbool == 'H')
                        {
                            var geselecteerdeCarnivoor = (Carnivoor)geselecteerditem;
                            var buurmanHerbivoor = (Herbivoor)geselecteerditem;
                            geselecteerdeCarnivoor.Levenskracht += buurmanHerbivoor.Levenskracht;

                            mijnMatrix.BeweegNaarRechts(geselecteerdeCarnivoor, buurmanHerbivoor);
                        }

                        // Herbivoor vrijt met herbivoor
                        if (geselecteerditem.Symbool == 'H' && matrixItemBuurman.Symbool == 'H')
                        {
                            toeTeVoegenBabies++;
                        }


                        // Carnivoor vecht met carnivoor
                        if (geselecteerditem.Symbool == 'C' && matrixItemBuurman.Symbool == 'C')
                        {
                            var speler1 = (Carnivoor)geselecteerditem;
                            var speler2 = (Carnivoor)matrixItemBuurman;

                            if (speler1.Levenskracht > speler2.Levenskracht)
                            {
                                speler1.Levenskracht += speler2.Levenskracht;
                                mijnMatrix.BeweegNaarRechts(speler1, speler2);
                            }
                            else if (speler1.Levenskracht < speler2.Levenskracht)
                            {
                                // SPELER 1 moet verdwijnen
                                speler2.Levenskracht += speler1.Levenskracht;
                            }
                        }
                    }

                }
                    mijnMatrix.GeefWeer();
            }
                    }
        }
    }

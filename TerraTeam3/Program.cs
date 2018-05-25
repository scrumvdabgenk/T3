﻿using System;
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
            var aantalPlanten = Parameter.AantalPlanten;
            var aantalHerbivoren = Parameter.AantalHerbivoren;
            var aantalCarnivoren = Parameter.AantalCarnivoren;
            int aantalPlantenBijvoegen;

            Matrix mijnMatrix = new Matrix();


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

                                mijnMatrix.BeweegNaarRechts(geselecteerdeHerbivoor, matrixItemBuurman);
                            }

                            // Carnivoor eet herbivoor
                            if (geselecteerditem.Symbool == 'C' && matrixItemBuurman.Symbool == 'H' && geselecteerditem.IsVeranderd == false)
                            {
                                var geselecteerdeCarnivoor = (Carnivoor)geselecteerditem;
                                var buurmanHerbivoor = (Herbivoor)matrixItemBuurman;

                                matrixItemBuurman.IsVeranderd = true;

                                geselecteerdeCarnivoor.Levenskracht += buurmanHerbivoor.Levenskracht;

                                mijnMatrix.BeweegNaarRechts(geselecteerdeCarnivoor, buurmanHerbivoor);
                            }

                            // Herbivoor vrijt met herbivoor
                            if (geselecteerditem.Symbool == 'H' && matrixItemBuurman.Symbool == 'H')
                            {
                                toeTeVoegenBabies++;
                            }


                            // Carnivoor vecht met carnivoor
                            if (geselecteerditem.Symbool == 'C' && matrixItemBuurman.Symbool == 'C' && geselecteerditem.IsVeranderd == false)
                            {
                                var speler1 = (Carnivoor)geselecteerditem;
                                var speler2 = (Carnivoor)matrixItemBuurman;

                                if (speler1.Levenskracht > speler2.Levenskracht)
                                {
                                    speler1.IsVeranderd = true;

                                    speler1.Levenskracht += speler2.Levenskracht;
                                    mijnMatrix.BeweegNaarRechts(speler1, speler2);
                                }
                                else if (speler1.Levenskracht < speler2.Levenskracht)
                                {
                                    speler2.Levenskracht += speler1.Levenskracht;
                                    mijnMatrix.VerwijderItem(speler1);
                                }
                            }

                            // Herbivoren en carnivoren bewegen
                            if ((geselecteerditem.Symbool == 'C' || geselecteerditem.Symbool == 'H') && matrixItemBuurman.Symbool == '.' && geselecteerditem.IsVeranderd == false)
                            {
                                // controle welke vrij is
                                var matrixItemMogelijkheden = mijnMatrix.geefLegePosities(geselecteerditem);



                            }
                        }
                        // TOETEVOEGEN BABIES TOEVOEGEN

                    }

                    aantalPlantenBijvoegen = Parameter.AantalPlantenBijvoegen;
                    for (var lus = 0; lus <= aantalPlanten; lus++)
                    {
                        var toeTeVoegenPlant = new Plant();
                        mijnMatrix.VoegItemToe(toeTeVoegenPlant);
                    }
                    Console.WriteLine("rb: aantal planten toegevoegd "+aantalPlantenBijvoegen);
                    mijnMatrix.GeefWeer();
                }
            }
            while (input == "v");
        }
    }
}


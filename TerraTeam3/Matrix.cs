﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public class Matrix
    {
        private int aantalRijen;
        private int aantalKolommen;
        private int aantalPosities;
        public List<MatrixItem> Items = new List<MatrixItem>();
        Random rnd = new Random();

        public Matrix(int aantalRijen, int aantalKolommen)
        {
            this.aantalRijen = aantalRijen;
            this.aantalKolommen = aantalKolommen;
            this.aantalPosities = this.aantalRijen * this.aantalKolommen;
            for (var x = 0; x < aantalRijen; x++)
            {
                for (var y = 0; y < aantalKolommen; y++)
                {
                    LeegItem leegItem = new LeegItem();
                    leegItem.PosX = x;
                    leegItem.PosY = y;
                    leegItem.Naam = "." + "_" + x + "_" + y;
                    VulMatrixToe(leegItem);

                }
            }
        }

        public void VoegItemToe(MatrixItem matrixItem)
        {
            List<MatrixItem> leegItems = (from item in Items
                                          where item.Symbool == '.'
                                          select item).ToList();

            var randomGeselecteerdItem = leegItems[rnd.Next(0, leegItems.Count())];

            matrixItem.PosX = randomGeselecteerdItem.PosX;
            matrixItem.PosY = randomGeselecteerdItem.PosY;

            Items.Remove(randomGeselecteerdItem);
            Items.Add(matrixItem);
        }

        public void VulMatrixToe(MatrixItem matrixItem)
        {
            Items.Add(matrixItem);
        }

        public void GeefWeer()
        {
            List<MatrixItem> weerTeGevenItems = (from item in Items
                                                 orderby item.PosX, item.PosY
                                                 select item).ToList();

            var kolomTeller = 0;

            foreach (var item in weerTeGevenItems)
            {
                kolomTeller++;

                Console.Write(item.Symbool + "  ");
                if (kolomTeller == aantalKolommen)
                {
                    Console.WriteLine();
                    kolomTeller = 0;
                }
            }
        }

        public MatrixItem GeefBuurmanRechts(MatrixItem startItem)
        {
            var volgendItem = (from item in Items
                               where item.PosY == startItem.PosY + 1 && item.PosX == startItem.PosX
                               select item).FirstOrDefault();
            return volgendItem;
        }

        public List<MatrixItem> GeefGesorteerdeLijst()
        {
            var lijstTerugTegeven = (from item in Items
                                     orderby item.PosX, item.PosY
                                     select item).ToList();
            return lijstTerugTegeven;
        }

        public void BeweegNaarRechts(MatrixItem startItem, MatrixItem eindItem)
        {
            LeegItem nieuwLeegItem = new LeegItem();
            nieuwLeegItem.PosX = startItem.PosX;
            nieuwLeegItem.PosY = startItem.PosY;

            startItem.PosX = eindItem.PosX;
            startItem.PosY = eindItem.PosY;
            
            Items.Remove(eindItem);
            Items.Add(nieuwLeegItem);                        
        }
    }
}

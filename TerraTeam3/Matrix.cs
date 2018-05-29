using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public class Matrix
    {
        //private int aantalRijen;
        //private int aantalKolommen;
        //private int aantalPosities;
        public List<MatrixItem> Items = new List<MatrixItem>();
        Random rnd = new Random();

        public Matrix()
        {
            //this.aantalRijen = aantalRijen;
            //this.aantalKolommen = aantalKolommen;
            //this.aantalPosities = this.aantalRijen * this.aantalKolommen;
            for (var x = 0; x < Parameter.AantalRijen; x++)
            {
                for (var y = 0; y < Parameter.AantalKolommen; y++)
                {
                    LeegItem leegItem = new LeegItem();
                    leegItem.PosX = x;
                    leegItem.PosY = y;                  
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

                int levenskracht = 0;
                if (item.Symbool == 'H')
                {
                    Herbivoor geselecteerdItem = (Herbivoor)item;
                    levenskracht = geselecteerdItem.Levenskracht;
                }

                if (item.Symbool == 'C')
                {
                    Carnivoor geselecteerdItem = (Carnivoor)item;
                    levenskracht = geselecteerdItem.Levenskracht;
                }

                //if (item.Symbool == 'P')  TEST KLEUREN MAANDAG
                //                {
                //                    Console.ForegroundColor = ConsoleColor.Green;
                //                }
                //if (item.Symbool=='C')
                //                {
                //                    Console.ForegroundColor = ConsoleColor.Red;
                //                }
                //                if (item.Symbool == 'H')
                //                {
                //                    Console.ForegroundColor = ConsoleColor.Blue;
                //                }
                Console.ForegroundColor = item.Kleur;
                Console.Write(item.Symbool + "("+levenskracht+")  ");
                Console.ForegroundColor = ConsoleColor.White;
                if (kolomTeller == Parameter.AantalKolommen)
                {
                    Console.WriteLine();
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


        public List<MatrixItem> geefLegePosities(MatrixItem startItem)
        {
            var vrijePLaats = (from item in Items
                               where (item.PosY == startItem.PosY - 1 && item.PosX == startItem.PosX) && item.Symbool == '.' ||
                               (item.PosY == startItem.PosY && item.PosX == startItem.PosX - 1) && item.Symbool == '.' ||
                               (item.PosY == startItem.PosY && item.PosX == startItem.PosX + 1) && item.Symbool == '.' ||
                               (item.PosY == startItem.PosY +1 && item.PosX == startItem.PosX) && item.Symbool == '.'
                               select item).ToList();
            return vrijePLaats;

        }

        public List<MatrixItem> GeefGesorteerdeLijst()
        {
            var lijstTerugTegeven = (from item in Items
                                     orderby item.PosX, item.PosY
                                     select item).ToList();
            return lijstTerugTegeven;
        }

        public void Beweeg(MatrixItem startItem, MatrixItem eindItem)
        {
            LeegItem nieuwLeegItem = new LeegItem();
            nieuwLeegItem.PosX = startItem.PosX;
            nieuwLeegItem.PosY = startItem.PosY;

            startItem.PosX = eindItem.PosX;
            startItem.PosY = eindItem.PosY;

            Items.Remove(eindItem);
            Items.Add(nieuwLeegItem);
        }

        public void VerwijderItem(MatrixItem matrixItem)
        {
            LeegItem nieuwLeegItem = new LeegItem();
            nieuwLeegItem.PosX = matrixItem.PosX;
            nieuwLeegItem.PosY = matrixItem.PosY;

            Items.Remove(matrixItem);
            Items.Add(nieuwLeegItem);
        }

        public void ResetIsVeranderd()
        {
            foreach (MatrixItem item in Items)
            {
                item.IsVeranderd = false;
            }
        }



        
    }
}

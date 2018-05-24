using System;
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

            Random rnd = new Random();

            var randomGeselecteerdItem = leegItems[rnd.Next(leegItems.Count())];

            matrixItem.PosX = randomGeselecteerdItem.PosX;
            matrixItem.PosY = randomGeselecteerdItem.PosY;

            Items.Remove(randomGeselecteerdItem);
            Items.Add(matrixItem);

        }

        public void VulMatrixToe(MatrixItem matrixItem)
        {
            Items.Add(matrixItem);
        }

        public void geefPosRechts(MatrixItem item)
        {
            if (item.PosX < aantalKolommen)
            {
                int huidigeX = item.PosX;
                int huidigeY = item.PosY;
                int xRechts = huidigeX + 1;
                int yRechts = huidigeY;
            }
        }
    }
}

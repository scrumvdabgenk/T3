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
        private List<MatrixItem> Items;
        public Matrix(int aantalRijen, int aantalKolommen)
        {
            this.aantalRijen = aantalRijen;
            this.aantalKolommen = aantalKolommen;
            this.aantalPosities = this.aantalRijen * this.aantalKolommen;
        }

        public void VoegItemToe (MatrixItem matrixItem)
        {
            Items.Add(matrixItem);
        }
    }
}

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
            var aantalPlanten = 6;
            var aantalHerbivoren = 6;
            var aantalCarnivoren = 6;

            Matrix mijnMatrix = new Matrix(6, 6);

            for (var lus = 0;lus<=aantalPlanten;lus++ )
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


            foreach (MatrixItem mijnItem in mijnMatrix.Items) 
            {
                Console.WriteLine(mijnItem.Naam+ " - "+mijnItem.PosX.ToString() + " - " + mijnItem.PosY.ToString());
            }
        }
    }
}

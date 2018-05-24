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
                Plant toeTeVoegenPlant = new Plant();
                mijnMatrix.VoegItemToe(toeTeVoegenPlant); 
            }
            for (var lus = 0; lus <= aantalHerbivoren; lus++)
            {
                Plant toeTeVoegenHerbivoor = new Plant();
                mijnMatrix.VoegItemToe(toeTeVoegenHerbivoor);
            }
            for (var lus = 0; lus <= aantalCarnivoren; lus++)
            {
                Plant toeTeVoegenCarnivoor = new Plant();
                mijnMatrix.VoegItemToe(toeTeVoegenCarnivoor);
            }

        }
    }
}

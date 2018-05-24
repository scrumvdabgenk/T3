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

            Matrix mijnMatrix = new Matrix(12, 12);


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


            // mijnMatrix.GeefWeer();

            //for (var x = 0; x < aantalRijen; x++)
            //{
            //    for (var y = 0; y < aantalKolommen; y++)
            //    {
            //        var geselecteerditem(x,y);

            //        if (geselecteerditem.symbool == "h" && matrix.objectRechts(geselecteerditem).symbool == "p")
            //        {
            //            eet();
            //        }

            //        if (geselecteerditem.symbool == "c" && matrix.objectRechts(geselecteerditem).symbool == "c")
            //        {
            //            vecht();
            //        }

            //    }
            //}

        }        }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    [Serializable]
    public class Plant:MatrixItem
    {
        //public Plant(string naam, ConsoleColor plantKleur)
        //{
        //    this.Naam = naam;
        //    this.Symbool = 'P';
        //}
        public Plant()
        {
            this.Symbool = Parameter.PlantTeken;
        }
        public override ConsoleColor Kleur
        {
            get
            { return Parameter.PlantKleur; }
        }
    }
}

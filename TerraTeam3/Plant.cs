using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public class Plant:MatrixItem
    {
        //public Plant(string naam, ConsoleColor plantKleur)
        //{
        //    this.Naam = naam;
        //    this.Symbool = 'P';
        //}
        public Plant()
        {
            this.Symbool = 'P';
        }
        public override ConsoleColor Kleur
        {
            get
            { return ConsoleColor.Green; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public class LeegItem: MatrixItem
    {
        //public LeegItem(string naam, ConsoleColor leegItemKleur)
        //{
        //    this.Naam = naam;
        //}
        public LeegItem()
        {
            this.Symbool = '.';
        }
        public override ConsoleColor Kleur
        {
            get
            { return ConsoleColor.Gray; }
        }
    }
}

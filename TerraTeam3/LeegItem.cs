using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    [Serializable]
    public class LeegItem: MatrixItem
    {
        //public LeegItem(string naam, ConsoleColor leegItemKleur)
        //{
        //    this.Naam = naam;
        //}
        public LeegItem()
        {
            this.Symbool = Parameter.LeegItemTeken;
        }
        public override ConsoleColor Kleur
        {
            get
            { return Parameter.LeegItemKleur; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public class Carnivoor:Fauna
    {
        //public Carnivoor(string naam, ConsoleColor carnivoorKleur): base()
        //{
        //    this.Naam = naam;
        //    this.Symbool = 'C';
            
        //}
        //public Carnivoor():base()
        public Carnivoor()
        {
            this.Symbool = 'C';
        }
        public override ConsoleColor Kleur
        {
            get
            {
                if (Levenskracht < 3)
                { return ConsoleColor.Red; }
                else
                { return ConsoleColor.DarkRed; }
            }
        }
    }
}

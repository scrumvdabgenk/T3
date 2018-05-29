using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public class Carnivoor : Fauna
    {
        public Carnivoor(string naam) : base()
        {
            this.Naam = naam;
            
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

        public Carnivoor() : base()
        {
            this.Symbool = 'C';
            this.Levenskracht = Parameter.StartLevenskracht;
        }
    }
}

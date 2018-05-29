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
                { return Parameter.CarnivoorStandaardKleur; }
                else
                { return Parameter.CarnivoorSterkKleur; }
            }
        }

        public Carnivoor() : base()
        {
            this.Symbool = Parameter.CarnivoorTeken;
            this.Levenskracht = Parameter.StartLevenskracht;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    [Serializable]
    public class Herbivoor : Fauna
    {
        public Herbivoor(string naam)
        {
            this.Naam = naam;            
        }

        public override ConsoleColor Kleur
        {
            get
            {
                if (Levenskracht < 3)
                { return Parameter.HerbivoorStandaardKleur; }
                else
                { return Parameter.HerbivoorSterkKleur; }
            }
        }

        public Herbivoor() : base()
        {
            this.Symbool = Parameter.HerbivoorTeken;
            this.Levenskracht = Parameter.StartLevenskracht;
        }
    }
}

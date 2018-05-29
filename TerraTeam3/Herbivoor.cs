using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public class Herbivoor : Fauna
    {
        public Herbivoor(string naam) : base()
        {
            this.Naam = naam;
            
        }

        public Herbivoor() : base()
        {
            this.Symbool = 'H';
            this.Levenskracht = Parameter.StartLevenskracht;
        }

    }
}

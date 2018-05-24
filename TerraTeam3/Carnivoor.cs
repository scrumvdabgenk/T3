using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public class Carnivoor:Fauna
    {
        public Carnivoor(string naam)
        {
            this.Naam = naam;
            this.Symbool = 'C';
            // this.Levenskracht = levenskracht;    STARTWAARDE TE CHECKEN MET KLANT
        }
        public Carnivoor()
        {
            this.Symbool = 'C';
            // this.Levenskracht = levenskracht;    STARTWAARDE TE CHECKEN MET KLANT
        }

    }
}

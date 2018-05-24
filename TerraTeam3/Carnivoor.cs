using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public class Carnivoor:Fauna
    {
        public Carnivoor(string naam): base()
        {
            this.Naam = naam;
            this.Symbool = 'C';
            
        }
        public Carnivoor():base()
        {
            this.Symbool = 'C';
            
        }

    }
}

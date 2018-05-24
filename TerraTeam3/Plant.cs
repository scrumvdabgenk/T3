using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public class Plant:MatrixItem
    {
        public Plant(string naam)
        {
            this.Naam = naam;
            this.Symbool = 'P';
        }
    }
}

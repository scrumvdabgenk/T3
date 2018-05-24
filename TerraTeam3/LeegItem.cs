using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public class LeegItem: MatrixItem
    {
        public LeegItem(string naam)
        {
            this.Naam = naam;
            this.Symbool = '.';
        }
        public LeegItem()
        {
            this.Symbool = '.';
        }

    }
}

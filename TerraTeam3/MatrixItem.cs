using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public abstract class MatrixItem
    {
        public string Naam { get; set; }
        public char Symbool { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

    }
}

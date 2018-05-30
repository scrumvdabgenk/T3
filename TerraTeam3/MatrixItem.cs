using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    [Serializable]
    public abstract class MatrixItem
    {
        public string Naam { get; set; }
        public char Symbool { get; set; }
        private int valuePosX;
        private int valuePosY;
        public bool IsVeranderd { get; set; } = false;

        public abstract ConsoleColor Kleur { get;}

        public int PosX
        {
            get
            {
                return valuePosX;
            }
            set
            {
                if (value < 0)
                {
                    PosX = 0;
                }
                else
                {
                    valuePosX = value;
                }
            }
        }

        public int PosY
        {
            get
            {
                return valuePosY;
            }
            set
            {
                if (value < 0)
                {
                    PosY = 0;
                }
                else
                {
                    valuePosY = value;
                }
            }
        }
    }
}

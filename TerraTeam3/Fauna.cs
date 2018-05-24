using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public abstract class Fauna:MatrixItem
    {
        private bool actieUitgevoerdValue;
        public int Levenskracht { get; set; }
        public bool ActieUitgevoerd { get { return actieUitgevoerdValue; } set { actieUitgevoerdValue = false; } } 
    }
}

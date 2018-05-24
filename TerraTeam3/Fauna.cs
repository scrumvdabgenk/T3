using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public abstract class Fauna:MatrixItem
    {
        public int Levenskracht { get; set; }
        public bool ActieUitgevoerd { get; set; }

        public Fauna()
        {
            this.Levenskracht = 0;
            this.ActieUitgevoerd = false;
        }
    }


}

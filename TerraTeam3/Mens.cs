using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    [Serializable]
    public class Mens : Fauna
    {
        public Mens()
        {
            this.Levenskracht = Parameter.StartLevenskracht;
            this.Symbool = Parameter.MensTeken;

        }

        public override ConsoleColor Kleur
        {
            get
            {
                if (Levenskracht < 3)
                { return Parameter.MensStandaardKleur; }
                else
                { return Parameter.MensSterkKleur; }
            }
        }

    }
}

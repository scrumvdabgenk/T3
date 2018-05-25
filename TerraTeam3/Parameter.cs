using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public static class Parameter
    {
        public static int AantalRijen { get; set; }
        public static int AantalKolommen { get; set; }
        public static int StartLevenskracht { get; set; }
        public static int MaxAantalPlantenBijvoegen { get; set; }
        public static int MaxAantalPlantenStart { get; set; }
        public static int MaxAantalHerbivoren { get; set; }
        public static int MaxAantalCarnivoren { get; set; }
        public static int AantalPosities { get; set; } 


        static Parameter()
        {
            AantalRijen = 6;
            AantalKolommen = 6;
            StartLevenskracht = 1;
            MaxAantalPlantenBijvoegen = AantalRijen * AantalKolommen / 10;
            MaxAantalPlantenStart = AantalKolommen * AantalRijen / 10;
            MaxAantalHerbivoren = AantalKolommen * AantalRijen / 10;
            MaxAantalCarnivoren = AantalKolommen * AantalRijen / 10;

        }

    }

    
}

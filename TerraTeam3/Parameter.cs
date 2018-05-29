using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    public static class Parameter
    {
        static Random rnd = new Random();
        public static int AantalRijen { get; set; }
        public static int AantalKolommen { get; set; }
        public static int StartLevenskracht { get; set; }
        public static int MaxAantalPlantenBijvoegen { get; set; }
        public static int MaxAantalPlantenStart { get; set; }
        public static int MaxAantalHerbivorenStart { get; set; }
        public static int MaxAantalCarnivorenStart { get; set; }
        public static int AantalPosities { get; set; } 
        public static int AantalPlanten
        {
            get
            {
                return rnd.Next(1, MaxAantalPlantenStart);
            }
        }
        public static int AantalHerbivoren
        {
            get
            {
                return rnd.Next(1, MaxAantalHerbivorenStart);
            }
        }
        public static int AantalCarnivoren
        {
            get
            {
                return rnd.Next(1, MaxAantalCarnivorenStart);
            }
        }
        public static int AantalPlantenBijvoegen
        {
            get
            {
                return rnd.Next(1, MaxAantalPlantenBijvoegen);
            }
        }
        public static int MinAantalLeeg {get;set;}
        


        static Parameter()
        {
            AantalRijen = 6;
            AantalKolommen = 6;
            StartLevenskracht = 1;
            MaxAantalPlantenBijvoegen = AantalRijen * AantalKolommen / 10;
            MaxAantalPlantenStart = AantalKolommen * AantalRijen / 10;
            MaxAantalHerbivorenStart = AantalKolommen * AantalRijen / 10;
            MaxAantalCarnivorenStart = AantalKolommen * AantalRijen / 10;
            MinAantalLeeg = AantalKolommen * AantalRijen / 10;
        }

    }

    
}

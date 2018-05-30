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
        public static int MaxAantalMensenStart { get; set; }
        public static int AantalPosities { get; set; }
        public static ConsoleColor PlantKleur { get; set; }
        public static ConsoleColor LeegItemKleur { get; set; }
        public static ConsoleColor HerbivoorStandaardKleur { get; set; }
        public static ConsoleColor HerbivoorSterkKleur { get; set; }
        public static ConsoleColor CarnivoorStandaardKleur { get; set; }
        public static ConsoleColor CarnivoorSterkKleur { get; set; }
        public static ConsoleColor MensStandaardKleur { get; set; }
        public static ConsoleColor MensSterkKleur { get; set; }
        public static char MensTeken { get; set; }
        public static char PlantTeken { get; set; }
        public static char LeegItemTeken { get; set; }
        public static char HerbivoorTeken { get; set; }
        public static char CarnivoorTeken { get; set; }

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
                return 1;
                // return rnd.Next(1, MaxAantalHerbivorenStart);
            }
        }

        public static int AantalCarnivoren
        {
            get
            {
                return 5;
                // return rnd.Next(1, MaxAantalCarnivorenStart);
            }
        }

        public static int AantalMensen
        {
            get
            {
                //   return rnd.Next(1, MaxAantalMensenStart);
                return 5;
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
            MensTeken = 'M';
            LeegItemTeken = '.';
            PlantTeken = 'P';
            HerbivoorTeken = 'H';
            CarnivoorTeken = 'C';
            MensSterkKleur = ConsoleColor.DarkYellow;
            MensStandaardKleur = ConsoleColor.Yellow;
            CarnivoorStandaardKleur = ConsoleColor.DarkRed;
            CarnivoorSterkKleur = ConsoleColor.Red;
            HerbivoorSterkKleur = ConsoleColor.Magenta;
            HerbivoorStandaardKleur = ConsoleColor.DarkMagenta;
            LeegItemKleur = ConsoleColor.Gray;
            PlantKleur = ConsoleColor.Green;
            AantalRijen = 12;
            AantalKolommen = 12;
            StartLevenskracht = 1;
            MaxAantalPlantenBijvoegen = AantalRijen * AantalKolommen / 20;
            MaxAantalPlantenStart = AantalKolommen * AantalRijen / 15;
            MaxAantalHerbivorenStart = AantalKolommen * AantalRijen / 5;
            MaxAantalCarnivorenStart = AantalKolommen * AantalRijen / 5;
            MaxAantalMensenStart = AantalKolommen * AantalRijen / 5;
            MinAantalLeeg = AantalKolommen * AantalRijen / 15;
        }
    }
}

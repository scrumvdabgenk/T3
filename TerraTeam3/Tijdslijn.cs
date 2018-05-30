using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam3
{
    class Tijdslijn
    {
        public List<TijdLijnGegevens> Items = new List<TijdLijnGegevens>()
        {
            new TijdLijnGegevens {BeginTijdstip="b1", EindTijdstip="e1",Plant="plant1",Carnivoor="carnivoor1",Herbivoor="herbivoor1" },
            new TijdLijnGegevens {BeginTijdstip="b2", EindTijdstip="e2",Plant="plant2",Carnivoor="carnivoor2",Herbivoor="herbivoor2" },
            new TijdLijnGegevens {BeginTijdstip="b3", EindTijdstip="e3",Plant="plant3",Carnivoor="carnivoor3",Herbivoor="herbivoor3" },
            new TijdLijnGegevens {BeginTijdstip="b4", EindTijdstip="e4",Plant="plant4",Carnivoor="carnivoor4",Herbivoor="herbivoor4" },
            new TijdLijnGegevens {BeginTijdstip="b5", EindTijdstip="e5",Plant="plant5",Carnivoor="carnivoor5",Herbivoor="herbivoor5" }
        };

    }
}

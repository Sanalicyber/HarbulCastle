using System.Collections.Generic;

namespace SmugTowerDefense.Controllers.Deck
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
        }
    }
}
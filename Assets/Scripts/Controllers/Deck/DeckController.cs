using SmugTowerDefense.Controllers.PlayerComponents;

namespace SmugTowerDefense.Controllers.Deck
{
    public class DeckController
    {
        public ClientPlayer player;
        public Deck deck;

        public DeckController(ClientPlayer player)
        {
            this.player = player;
            deck = new Deck();
        }
    }
}
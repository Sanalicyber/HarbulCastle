using System.Collections.Generic;
using SmugTowerDefense.Controllers.PlayerComponents;
using SmugTowerDefense.Management;

namespace SmugTowerDefense.Controllers.Deck
{
    public class ServerDeck
    {
        public Deck deck;
        public List<Player> players;
        public int interval;

        public ServerDeck()
        {
            deck = new Deck();
            players = new List<Player>();
            interval = 0;
            SmugNetworkManager.OnClientConnected += OnClientConnected;
        }

        private void OnClientConnected(Player obj)
        {
            players.Add(obj);
        }
    }
}
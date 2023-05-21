using System;
using Mirror;
using SmugTowerDefense.Controllers.Deck;
using SmugTowerDefense.Controllers.PlayerComponents;

namespace SmugTowerDefense.Management
{
    public class SmugNetworkManager : NetworkManager
    {
        public ServerDeck serverDeck;
        public static event Action<Player> OnClientConnected; 

        #region Server

        public override void Awake()
        {
            serverDeck = new ServerDeck();
            base.Awake();
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            NetworkServer.RegisterHandler<ClientToServerUsernameMessage>(OnClientToServerUsernameMessage, false);
        }

        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            base.OnServerAddPlayer(conn);
        }

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            base.OnServerDisconnect(conn);
        }

        public override void OnStopServer()
        {
            base.OnStopServer();
        }

        private void OnClientToServerUsernameMessage(NetworkConnectionToClient conn, ClientToServerUsernameMessage message)
        {
            var player = conn.identity.GetPlayer();
            player.SetData(new ClientPlayer(message.Username, conn.connectionId));
            OnClientConnected?.Invoke(player);
        }

        #endregion

        #region Client

        public override void OnClientConnect()
        {
            base.OnClientConnect();
            NetworkClient.Send(new ClientToServerUsernameMessage("SanaliCyber"));
        }

        public override void OnStartClient()
        {
            base.OnStartClient();
        }

        public override void OnClientDisconnect()
        {
            base.OnClientDisconnect();
        }

        public override void OnStopClient()
        {
            base.OnStopClient();
        }

        #endregion
    }
}
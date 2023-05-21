using Mirror;

namespace SmugTowerDefense
{
    public struct ClientToServerUsernameMessage : NetworkMessage
    {
        public string Username { get; set; }

        public ClientToServerUsernameMessage(string username)
        {
            Username = username;
        }
    }
}
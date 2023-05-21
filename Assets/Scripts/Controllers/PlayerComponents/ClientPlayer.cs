namespace SmugTowerDefense.Controllers.PlayerComponents
{
    public class ClientPlayer
    {
        public string UserName { get; set; }
        public int ConnectionId { get; set; }

        public ClientPlayer()
        {
            
        }

        public ClientPlayer(string userName, int connectionId)
        {
            UserName = userName;
            ConnectionId = connectionId;
        }
    }
}
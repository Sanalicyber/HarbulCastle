using Mirror;
using SmugTowerDefense.Controllers.PlayerComponents;

namespace SmugTowerDefense
{
    public static class ExternalExtensions
    {
        public static Player GetPlayer(this NetworkIdentity networkIdentity)
        {
            return networkIdentity.GetComponent<Player>();
        }
    }
}
using Mirror;

namespace SmugTowerDefense.Controllers.PlayerComponents
{
    public class Player : NetworkBehaviour
    {
        public static Player LocalPlayer { get; private set; }
        public ClientPlayer data;

        public void SetData(ClientPlayer data)
        {
            this.data = data;
        }

        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();
            LocalPlayer = this;
        }
    }
}
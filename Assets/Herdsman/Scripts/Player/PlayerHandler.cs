using Common.GameEntities.Handler;
using Common.GameEntities.Models;
using Common.GameEntities.Spawner;
using Cysharp.Threading.Tasks;
using Player.Entity;

namespace Player
{
    public class PlayerHandler : GameEntityHandlerBase<PlayerMediator, PlayerView>
    {
        //Main player game logic
        //Subscribe to PlayerMediator events

        private const string playerAddressableName = "Player";
        private PlayerMediator playerMediator;

        public PlayerHandler(GameEntitySpawner<PlayerMediator, PlayerView> spawner) : base(spawner)
        {
        }

        public async UniTaskVoid CreatePlayer()
        {
            playerMediator = await CreateMediator(new SpawnData() { AddressableName = playerAddressableName });
        }

        public void DestroyPlayer()
        {
            if (playerMediator != null)
            {
                DestroyMediator(playerMediator);
            }
        }
    }
}

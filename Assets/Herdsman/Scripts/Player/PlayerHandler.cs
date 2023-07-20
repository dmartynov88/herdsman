using Common.GameEntities.Handler;
using Common.GameEntities.Models;
using Common.GameEntities.Spawner;
using Cysharp.Threading.Tasks;
using Player.Entity;
using Services.InputSystem;

namespace Player
{
    public class PlayerHandler : GameEntityHandlerBase<PlayerMediator, PlayerView>
    {
        //Main player game logic
        //Subscribe to PlayerMediator events

        private readonly InputService inputService;
        
        private const string playerAddressableName = "Player";
        private PlayerMediator playerMediator;

        public PlayerHandler(InputService inputService, GameEntitySpawner<PlayerMediator, PlayerView> spawner) : base(spawner)
        {
            this.inputService = inputService;
        }

        public async UniTaskVoid CreatePlayer()
        {
            playerMediator = await CreateMediator(new SpawnData() { AddressableName = playerAddressableName });
            inputService.RegisterPositionReceiver(playerMediator);
        }

        public void DestroyPlayer()
        {
            if (playerMediator != null)
            {
                inputService.ClearPositionReceiver();
                DestroyMediator(playerMediator);
            }
        }
    }
}

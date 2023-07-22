using Common.GameEntities.Handler;
using Common.GameEntities.Models;
using Common.GameEntities.Spawner;
using Cysharp.Threading.Tasks;
using Player.Entity;
using Services.InputSystem;

namespace Player.SinglePlayer
{
    public class PlayerSingleHandler : GameEntityHandlerBase<PlayerMediator, PlayerView>
    {
        //Main player game logic
        //Subscribe to PlayerMediator events

        private readonly InputService inputService;
        private PlayerMediator playerMediator;

        public PlayerSingleHandler(InputService inputService, GameEntitySpawner<PlayerMediator, PlayerView> spawner) : base(spawner)
        {
            this.inputService = inputService;
        }

        public async UniTask CreatePlayer(SpawnData spawnData)
        {
            playerMediator = await CreateMediator(0, spawnData);
            inputService.RegisterMovementController(playerMediator);
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

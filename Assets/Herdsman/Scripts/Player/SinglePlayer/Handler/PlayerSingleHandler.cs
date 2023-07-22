using Common.GameEntities.Handler;
using Common.GameEntities.Models;
using Common.GameEntities.Spawner;
using Cysharp.Threading.Tasks;
using Player.SinglePlayer.Entity;
using Services.InputSystem;

namespace Player.SinglePlayer
{
    public class PlayerSingleHandler : GameEntityHandlerBase<PlayerSingleMediator, PlayerSingleView>
    {
        //Main player game logic
        //Subscribe to PlayerMediator events

        private readonly InputService inputService;
        private PlayerSingleMediator playerSingleMediator;

        public PlayerSingleHandler(InputService inputService, GameEntitySpawner<PlayerSingleMediator, PlayerSingleView> spawner) : base(spawner)
        {
            this.inputService = inputService;
        }

        public async UniTask CreatePlayer(SpawnData spawnData)
        {
            playerSingleMediator = await CreateMediator(0, spawnData);
            inputService.RegisterMovementController(playerSingleMediator);
        }

        public void DestroyPlayer()
        {
            if (playerSingleMediator != null)
            {
                inputService.ClearPositionReceiver();
                DestroyMediator(playerSingleMediator);
            }
        }
    }
}

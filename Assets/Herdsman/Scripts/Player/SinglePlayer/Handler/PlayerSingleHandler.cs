using Common.GameEntities.Handler;
using Common.GameEntities.Models;
using Common.GameEntities.Spawner;
using Cysharp.Threading.Tasks;
using Player.SinglePlayer.Entity;
using Services.InputSystem;
using UnityEngine;

namespace Player.SinglePlayer
{
    public class PlayerSingleHandler : GameEntityHandlerBase<PlayerSingleMediator, PlayerView>
    {
        //Main player game logic
        //Subscribe to PlayerMediator events
        private readonly Color playerColor = Color.yellow;
        private readonly Color playerNpcOwnedColor = Color.red;

        private readonly InputService inputService;
        private PlayerSingleMediator playerSingleMediator;

        public PlayerSingleHandler(InputService inputService, GameEntitySpawner<PlayerSingleMediator, PlayerView> spawner) : base(spawner)
        {
            this.inputService = inputService;
        }

        public async UniTask CreatePlayer(SpawnData spawnData)
        {
            playerSingleMediator = await CreateMediator(0, spawnData);
            playerSingleMediator.SetColor(playerColor, playerNpcOwnedColor);
            inputService.MouseMovementReceived += OnMouseMovementReceived;
            //inputService.RegisterMovementController(playerSingleMediator);
        }

        private void OnMouseMovementReceived(Vector3 mousePosition)
        {
            playerSingleMediator.SetTargetPoint(mousePosition);
        }

        public void DestroyPlayer()
        {
            inputService.MouseMovementReceived -= OnMouseMovementReceived;
            if (playerSingleMediator != null)
            {
                DestroyMediator(playerSingleMediator);
            }
        }
    }
}

using Common.GameEntities.Handler;
using Common.GameEntities.Models;
using Common.GameEntities.Spawner;
using Cysharp.Threading.Tasks;
using Player.CoopPlayer.Entity;
using Player.SinglePlayer.Entity;
using Services.InputSystem;
using UnityEngine;

namespace Player.CoopPlayer
{
    public class PlayerCoopHandler : GameEntityHandlerBase<PlayerCoopMediator, PlayerView>
    {
        private readonly Color player1Color = Color.yellow;
        private readonly Color player1NpcOwnedColor = Color.red;
        
        private readonly Color player2Color = Color.blue;
        private readonly Color player2NpcOwnedColor = Color.cyan;
        
        private readonly InputService inputService;

        private PlayerCoopMediator player1Mediator;
        private PlayerCoopMediator player2Mediator;
        
        public PlayerCoopHandler(InputService inputService, GameEntitySpawner<PlayerCoopMediator, PlayerView> spawner) : base(spawner)
        {
            this.inputService = inputService;
        }
        
        public async UniTask CreatePlayers(SpawnData player1SpawnData, SpawnData player2SpawnData)
        {
            player1Mediator = await CreateMediator(0, player1SpawnData);
            player2Mediator = await CreateMediator(0, player2SpawnData);
            
            player1Mediator.SetCoopData(InputType.Mouse, player1Color, player1NpcOwnedColor);
            player2Mediator.SetCoopData(InputType.Keyboard, player2Color, player2NpcOwnedColor);
            
            inputService.MouseMovementReceived += OnMouseMovementReceived;
            inputService.KeyboardMovementReceived += OnKeyboardMovementReceived;
        }

        private void OnKeyboardMovementReceived(Vector3 keyboardInput)
        {
            player2Mediator.SetTargetPoint(keyboardInput);
        }

        private void OnMouseMovementReceived(Vector3 mousePosition)
        {
            player1Mediator.SetTargetPoint(mousePosition);
        }
        
        public void DestroyPlayers()
        {
            inputService.MouseMovementReceived -= OnMouseMovementReceived;
            inputService.KeyboardMovementReceived -= OnKeyboardMovementReceived;
            
            if (player1Mediator != null)
            {
                DestroyMediator(player1Mediator);
            }

            if (player2Mediator != null)
            {
                DestroyMediator(player2Mediator);
            }
        }
    }
}
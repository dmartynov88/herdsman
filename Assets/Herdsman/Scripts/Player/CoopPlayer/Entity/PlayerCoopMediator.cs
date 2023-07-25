using System;
using Common.GameEntities.Abstract;
using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;
using GameEntities.Movement;
using Player.SinglePlayer.Entity;
using Services.InputSystem;
using UnityEngine;

namespace Player.CoopPlayer.Entity
{
    public class PlayerCoopMediator : GameEntityMediatorBase<PlayerView>, ITargetPointReceiver
    {
        private Color playerColor;
        private Color ownedNpcColor;
        private InputType inputType = InputType.Mouse;
        public UniTask Initialize(PlayerView singleView, SpawnData spawnData)
        {
            return base.Initialize(0, singleView, spawnData);
        }

        public void SetCoopData(InputType inputType, Color playerColor, Color ownedNpcColor)
        {
            this.inputType = inputType;
            this.playerColor = playerColor;
            this.ownedNpcColor = ownedNpcColor;
            
            View.SetPlayerColor(playerColor, ownedNpcColor);
        }
        
        public void SetTargetPoint(Vector3 target)
        {
            switch (inputType)
            {
                case InputType.Mouse:
                    View.MoveTo(target);
                    break;
                case InputType.Keyboard:
                    View.MoveTo(View.Transform.position + target);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override void OnViewReady()
        {
            View.SetPlayerColor(playerColor, ownedNpcColor);
        }

        protected override void OnDestroy()
        {
            
        }
    }
}
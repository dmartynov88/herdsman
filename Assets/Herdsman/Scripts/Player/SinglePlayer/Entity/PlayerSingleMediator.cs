using Common.GameEntities.Abstract;
using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;
using GameEntities.Movement;
using UnityEngine;

namespace Player.SinglePlayer.Entity
{
    public class PlayerSingleMediator : GameEntityMediatorBase<PlayerView>, ITargetPointReceiver
    {
        //Class for player character logic
        
        private Color playerColor;
        private Color ownedNpcColor;

        public UniTask Initialize(PlayerView view, SpawnData spawnData)
        {
            return base.Initialize(0, view, spawnData);
        }
       
        public void SetColor(Color playerColor, Color ownedNpcColor)
        {
            this.playerColor = playerColor;
            this.ownedNpcColor = ownedNpcColor;
            
            View.SetPlayerColor(playerColor, ownedNpcColor);
        }
        
        public void SetTargetPoint(Vector3 target)
        {
            View.MoveTo(target);
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

using Common.GameEntities.Abstract;
using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;
using GameEntities.Movement;
using UnityEngine;

namespace Player.SinglePlayer.Entity
{
    public class PlayerSingleMediator : GameEntityMediatorBase<PlayerSingleView>, ITargetPointReceiver
    {
        //Class for player character logic
        
        public UniTask Initialize(PlayerSingleView singleView, SpawnData spawnData)
        {
            return base.Initialize(0, singleView, spawnData);
        }
       
        
        public void SetTargetPoint(Vector3 target)
        {
            View.MoveTo(target);
        }
        
        protected override void OnViewReady()
        {
            
        }

        protected override void OnDestroy()
        {
            
        }
    }
}

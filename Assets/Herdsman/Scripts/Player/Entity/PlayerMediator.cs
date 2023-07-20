using Common.GameEntities.Abstract;
using GameEntities.Movement;
using UnityEngine;

namespace Player.Entity
{
    public class PlayerMediator : GameEntityMediatorBase<PlayerView>, IPositionReceiver
    {
        //Class for player character logic

        protected override void OnViewReady()
        {
            //Add custom components to view
        }

        protected override void OnDestroy()
        {
            //Remove custom components from view
        }

        public void SetPosition(Vector3 position)
        {
            View.SetPosition(position);
        }
    }
}

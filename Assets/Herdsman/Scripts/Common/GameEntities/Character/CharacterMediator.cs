using Common.GameEntities.Abstract;
using GameEntities.Movement;
using UnityEngine;

namespace Common.GameEntities.Character
{
    public class CharacterMediator<TView> : GameEntityMediatorBase<TView>, IPositionReceiver
        where TView : CharacterView
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
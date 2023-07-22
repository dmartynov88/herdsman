using Common.GameEntities.Abstract;
using GameEntities.Movement;
using Herdsman.Scripts.Common.GameEntities.Character;
using UnityEngine;

namespace Common.GameEntities.Character
{
    public class CharacterMediator<TView> : GameEntityMediatorBase<TView>, IMovementController
        where TView : CharacterView
    {
        //ToDo common only model for send realtime entity data by network (id, pos, rot)
        //represents real state of entity's Transform, only for read by network system
        public CharacterModel CharacterModel { get; private set; }

        public Transform Transform => View.Transform;

        protected override void OnViewReady()
        {
            CharacterModel = new CharacterModel(EntityId, View.Transform);
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

        public void MoveTo(Vector3 target)
        {
            View.MoveTo(target);
        }

        public void Stop()
        {
            View.Stop();
        }
    }
}
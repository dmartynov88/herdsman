using Common.GameEntities.Abstract;
using GameEntities.Movement;
using UnityEngine;

namespace Common.GameEntities.Character
{
    public class CharacterView : GameEntityViewBase, IMovementController
    {
        //Overrides IMovementController to set visual effects if needed
        [field: SerializeField] private MovementControllerBase MovementController { get; set; }

        public override void ResetView()
        {
            MovementController.Stop();
            base.ResetView();
        }

        public void SetSpeed(float speed)
        {
            MovementController.SetSpeed(speed);
        }

        public void SetPosition(Vector3 position)
        {
            MovementController.SetPosition(position);
        }

        public void MoveTo(Vector3 target)
        {
            MovementController.MoveTo(target);
        }

        public void Stop()
        {
            MovementController.Stop();
        }
    }
}
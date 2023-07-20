using Common.GameEntities.Abstract;
using GameEntities.Movement;
using UnityEngine;

namespace Player.Entity
{
    public class PlayerView : GameEntityViewBase, IPositionReceiver
    {
        [field: SerializeField] private MovementControllerBase MovementController { get; set; }

        public override void ResetView()
        {
            MovementController.Stop();
            base.ResetView();
        }

        public void SetPosition(Vector3 position)
        {
            MovementController.MoveTo(position);
        }
    }
}

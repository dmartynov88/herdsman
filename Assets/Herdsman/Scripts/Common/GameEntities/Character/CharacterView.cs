using Common.GameEntities.Abstract;
using GameEntities.Movement;
using UnityEngine;

namespace Common.GameEntities.Character
{
    public class CharacterView : GameEntityViewBase, IPositionReceiver
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
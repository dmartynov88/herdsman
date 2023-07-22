using UnityEngine;

namespace GameEntities.Movement
{
    public interface IMovementController
    {
        Transform Transform { get; }
        void SetSpeed(float speed);
        void SetPosition(Vector3 position);
        void MoveTo(Vector3 target);
        void Stop();
    }

    public abstract class MovementControllerBase : MonoBehaviour, IMovementController
    {
        public abstract Transform Transform { get; }
        public abstract void SetSpeed(float speed);
        public abstract void SetPosition(Vector3 position);
        public abstract void MoveTo(Vector3 target);
        public abstract void Stop();
    }
}
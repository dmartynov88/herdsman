using UnityEngine;

namespace GameEntities.Movement
{
    public interface ITargetPointReceiver
    {
        void SetTargetPoint(Vector3 target);
    }
}
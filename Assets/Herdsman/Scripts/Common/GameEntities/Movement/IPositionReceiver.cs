using UnityEngine;

namespace GameEntities.Movement
{
    public interface IPositionReceiver
    {
        void SetPosition(Vector3 position);
    }
}
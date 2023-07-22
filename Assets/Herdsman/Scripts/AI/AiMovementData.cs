using System;
using UnityEngine;

namespace AI
{
    [Serializable]
    public class AiMovementData
    {
        public Vector3 RandomMovementPosition;
        public float MovementSpeed;
        public float StoppingDistance;
    }
}
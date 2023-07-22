using System;
using UnityEngine;

namespace NPC.AI
{
    [Serializable]
    public class AiMovementData
    {
        public Vector3 RandomMovementPosition;
        public float MovementSpeed;
        public float FollowSpeed;
        public float StoppingDistance;
        public float FollowDistance;
    }
}
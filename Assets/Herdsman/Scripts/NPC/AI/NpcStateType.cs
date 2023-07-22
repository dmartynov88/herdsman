using System;
using GameEntities.Movement;

namespace NPC.AI
{
    public enum NpcStateType
    {
        Idle = 0,
        Patrol = 1,
        Follow = 2,
        Destroy = 3 //ToDo
    }
}
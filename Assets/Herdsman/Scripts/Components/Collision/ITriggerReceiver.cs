using System;

namespace Herdsman.Scripts.Components.Collision
{
    public interface ITriggerReceiver
    {
        event Action<ITriggerDetector> Triggered;
        void OnCollision(ITriggerDetector triggeredView);
    }
}
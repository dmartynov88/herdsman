using System;

namespace Herdsman.Scripts.Components.Collision
{
    public interface ITriggerReceiver
    {
        event Action<ITriggerDetector> Triggered;
        event Action ExitTrigger;
        void OnCollision(ITriggerDetector triggeredView);
        void OnExitCollision();
    }
}
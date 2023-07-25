using System;
using UnityEngine;

namespace Herdsman.Scripts.Components.Collision
{
    public class TriggerReceiver : MonoBehaviour, ITriggerReceiver
    {
        public event Action<ITriggerDetector> Triggered;
        public event Action ExitTrigger;
       
        public void OnCollision(ITriggerDetector triggeredView)
        {
            Triggered?.Invoke(triggeredView);
        }

        public void OnExitCollision()
        {
            ExitTrigger?.Invoke();
        }
    }
}
using System;
using Common.GameEntities.Character;
using Herdsman.Scripts.Components.Collision;
using UnityEngine;

namespace NPC.SinglePlayer.Entity
{
    public class NpcSingleView : CharacterView
    {
        public event Action<ITriggerDetector> InteractableTriggered;
        
        [SerializeField] private TriggerReceiver playerTriggerDetector;

        public override void InitializeView()
        {
            base.InitializeView();
            playerTriggerDetector.Triggered += OnTriggered;
        }

        private void OnTriggered(ITriggerDetector triggerDetector)
        {
            InteractableTriggered?.Invoke(triggerDetector);
        }

        public override void ResetView()
        {
            playerTriggerDetector.Triggered -= OnTriggered;
            base.ResetView();
        }
    }
}

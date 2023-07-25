using System;
using Common.GameEntities.Character;
using Components.Color;
using Herdsman.Scripts.Components.Collision;
using UnityEngine;

namespace NPC.LocalMode.Entity
{
    public class NpcView : CharacterView
    {
        public event Action<ITriggerDetector> InteractableTriggered;
        
        [SerializeField] private TriggerReceiver playerTriggerDetector;
        private ColorChanger colorChanger;

        public override void InitializeView()
        {
            playerTriggerDetector.Triggered += OnTriggered;
            playerTriggerDetector.ExitTrigger += OnExitTrigger;
            colorChanger = GetComponentInChildren<ColorChanger>();
            colorChanger.ResetColor();
        }

        private void OnTriggered(ITriggerDetector triggerDetector)
        {
            InteractableTriggered?.Invoke(triggerDetector);
        }

        private void OnExitTrigger()
        {
            colorChanger.ResetColor();
        }
        
        public void SetColor(Color color)
        {
            colorChanger.SetColor(color);
        }

        public override void ResetView()
        {
            playerTriggerDetector.Triggered -= OnTriggered;
            colorChanger.ResetColor();
            base.ResetView();
        }
    }
}

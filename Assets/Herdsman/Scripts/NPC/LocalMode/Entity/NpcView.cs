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
            colorChanger = GetComponentInChildren<ColorChanger>();
            ResetColor();
        }

        private void OnTriggered(ITriggerDetector triggerDetector)
        {
            InteractableTriggered?.Invoke(triggerDetector);
        }

        public void SetColor(Color color)
        {
            colorChanger.SetColor(color);
        }

        public void ResetColor()
        {
            colorChanger.ResetColor();
        }

        public override void ResetView()
        {
            playerTriggerDetector.Triggered -= OnTriggered;
            ResetColor();
            base.ResetView();
        }
    }
}

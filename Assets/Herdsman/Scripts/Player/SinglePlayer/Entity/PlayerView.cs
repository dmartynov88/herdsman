using Common.GameEntities.Character;
using Components.Color;
using UnityEngine;

namespace Player.SinglePlayer.Entity
{
    public class PlayerView : CharacterView
    {
        [SerializeField] private PlayerTrigger playerTrigger;
        private ColorChanger colorChanger;
        
        public override void InitializeView()
        {
            colorChanger = GetComponentInChildren<ColorChanger>();
        }
        
        public void SetPlayerColor(Color playerColor, Color ownedNpcColor)
        {
            colorChanger.SetColor(playerColor);
            playerTrigger.SetColor(ownedNpcColor);
        }
    }
}

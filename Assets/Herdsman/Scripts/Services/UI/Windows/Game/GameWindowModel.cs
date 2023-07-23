using System;
using Common.UI.Abstract;
using Services.Player.Models;

namespace Services.UI.Windows.Game
{
    public class GameWindowModel : IWindowModel
    {
        //Simple realization
        
        public event Action ModelChanged;
        public int TotalScore { get; set; }

        public void SetData(PlayerData playerData)
        {
            TotalScore = playerData.TotalScore;
            ModelChanged?.Invoke();
        }
    }
}
using System;
using System.Collections.Generic;
using Services.Player.Models;

namespace Services.Player.Service
{
    public class CoopPlayerService
    {
        public event Action PlayerDataChanged;

        public Dictionary<int, PlayerData> PlayerDataById { get; }

        public CoopPlayerService()
        {
            PlayerDataById = new()
            {
                {0, new PlayerData()},
                {1, new PlayerData()}
            };
        }
        
        public void AddScore(int yardId)
        {
            PlayerDataById[yardId].TotalScore++;
            PlayerDataChanged?.Invoke();
        }

        public void ResetScore()
        {
            PlayerDataById[0].TotalScore = 0;
            PlayerDataById[1].TotalScore = 0;
        }
    }
}
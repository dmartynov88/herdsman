using Services.Player.Abstract;
using Services.Player.Models;
using UnityEngine;

namespace Services.Player.Providers
{
    public class PlayerPrefsDataProvider : IPlayerDataProvider, IPlayerDataSaver
    {
        private PlayerData playerData;
        
        public PlayerData GetPlayerData()
        {
            if (playerData == null)
            {
                CreateAndFillData();
            }

            return playerData;
        }
      
        public void SavePlayerData(PlayerData playerData)
        {
            this.playerData = playerData;
            PlayerPrefs.SetInt("TotalScore", playerData.TotalScore);
        }
        
        private void CreateAndFillData()
        {
            playerData = new PlayerData();
            playerData.TotalScore = PlayerPrefs.GetInt("TotalScore", 0);
        }

        
    }
}

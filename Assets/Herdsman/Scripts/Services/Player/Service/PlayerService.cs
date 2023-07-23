using System;
using Services.Player.Abstract;
using Services.Player.Models;

namespace Services.Player.Service
{
    //Super extra simple realization
    public class PlayerService
    {
        //Simple realization
        public event Action PlayerDataChanged;
        public PlayerData PlayerData => playerData;

        private readonly PlayerData playerData;

        private readonly IPlayerDataSaver dataSaver;

        public PlayerService(IPlayerDataProvider dataProvider, IPlayerDataSaver dataSaver)
        {
            playerData = dataProvider.GetPlayerData();
            this.dataSaver = dataSaver;
        }

        public void AddScore()
        {
            playerData.TotalScore++;
            dataSaver.SavePlayerData(playerData);
            PlayerDataChanged?.Invoke();
        }
    }
}

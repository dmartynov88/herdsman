using Services.Player.Models;

namespace Services.Player.Abstract
{
    public interface IPlayerDataSaver
    {
        void SavePlayerData(PlayerData playerData);
    }
}
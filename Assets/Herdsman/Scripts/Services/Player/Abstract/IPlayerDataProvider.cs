using Services.Player.Models;

namespace Services.Player.Abstract
{
    public interface IPlayerDataProvider
    {
        PlayerData GetPlayerData();
    }
}

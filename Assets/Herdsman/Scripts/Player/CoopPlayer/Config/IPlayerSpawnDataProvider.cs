using System.Collections.Generic;
using Common.GameEntities.Models;

namespace Player.CoopPlayer.Config
{

    public interface IPlayerSpawnDataProvider
    {
        List<SpawnData> GetPlayerSpawnData();
    }
}
using System.Collections.Generic;
using Common.GameEntities.Models;

namespace NPC.Config
{
    public interface INpcSpawnDataProvider
    {
        List<SpawnData> GetNpcSpawnData();
    }
}
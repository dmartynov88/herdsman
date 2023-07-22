using System.Collections.Generic;
using Common.GameEntities.Models;
using UnityEngine;

namespace NPC.Config
{
    [CreateAssetMenu(fileName = "NpcSpawnDataConfigSo", menuName = "Configs/NpcSpawnDataConfigSo")]
    public class NpcSpawnDataConfigSo : ScriptableObject, INpcSpawnDataProvider
    {
        [field: SerializeField] private List<SpawnData> NpcSpawnData { get; set; }

        public List<SpawnData> GetNpcSpawnData()
        {
            return NpcSpawnData;
        }
    }
}
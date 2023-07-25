using System.Collections.Generic;
using Common.GameEntities.Models;
using UnityEngine;

namespace Player.CoopPlayer.Config
{
    [CreateAssetMenu(fileName = "PlayerSpawnDataConfigSo", menuName = "Configs/PlayerSpawnDataConfigSo")]
    public class PlayerSpawnDataConfigSo : ScriptableObject, IPlayerSpawnDataProvider
    {
        [field: SerializeField] private List<SpawnData> PlayerSpawnData { get; set; }
        
        public List<SpawnData> GetPlayerSpawnData()
        {
            return PlayerSpawnData;
        }
    }
}
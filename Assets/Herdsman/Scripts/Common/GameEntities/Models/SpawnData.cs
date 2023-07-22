using System;
using UnityEngine;

namespace Common.GameEntities.Models
{
    [Serializable]
    public class SpawnData
    {
        [field:SerializeField] public string AddressableName { get; set; }
        [field:SerializeField] public Vector3 Position { get; set; }
    }
}

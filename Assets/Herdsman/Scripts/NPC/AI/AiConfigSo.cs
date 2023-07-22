using UnityEngine;

namespace NPC.AI
{
    [CreateAssetMenu(fileName = "AiConfigSo", menuName = "Configs/AiConfigSo")]
    public class AiConfigSo : ScriptableObject, IAiMovementDataProvider
    {
        [field: SerializeField] private AiMovementData aiMovementData { get; set; }
        public AiMovementData GetMovementData()
        {
            return aiMovementData;
        }
    }
}
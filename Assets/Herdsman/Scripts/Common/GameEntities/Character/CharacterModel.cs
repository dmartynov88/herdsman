using Common.GameEntities.Abstract;
using UnityEngine;

namespace Herdsman.Scripts.Common.GameEntities.Character
{
    public class CharacterModel : IGameEntityModel
    {
        public uint GameEntityId { get; }
        public string AddressableName { get; }
        public Vector3 Position => transform.localPosition;
        public Vector3 Rotation => transform.localEulerAngles;
        
        private readonly Transform transform;

        public CharacterModel(uint gameEntityId, string addressableName, Transform transform)
        {
            GameEntityId = gameEntityId;
            AddressableName = addressableName;
            this.transform = transform;
        }
    }
}
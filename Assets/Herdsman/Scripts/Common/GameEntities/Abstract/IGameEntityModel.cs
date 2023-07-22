using UnityEngine;

namespace Common.GameEntities.Abstract
{
    public interface IGameEntityModel
    {
        Vector3 Position { get; }
        Vector3 Rotation { get; }
    }
}

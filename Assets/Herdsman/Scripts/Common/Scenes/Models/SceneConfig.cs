using System;
using UnityEngine;

namespace Common.Scenes.Models
{
    [Serializable]
    public class SceneConfig
    {
        [field: SerializeField] public string SceneName { get; private set; }
    }
}
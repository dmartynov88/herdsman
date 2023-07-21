using Common.Scenes.Abstract;
using Common.Scenes.Models;
using UnityEngine;

namespace Common.Scenes.Config
{
    [CreateAssetMenu(fileName = "SceneConfigProviderSo", menuName = "Configs/SceneConfigProviderSo")]
    public class SceneConfigProviderSo : ScriptableObject, ISceneConfigProvider
    {
        [field: SerializeField] private SceneConfig SceneConfig { get; set; }

        public SceneConfig GetSceneConfig()
        {
            return SceneConfig;
        }
    }
}
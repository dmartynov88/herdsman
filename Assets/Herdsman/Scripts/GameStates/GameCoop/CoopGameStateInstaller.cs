using Adic.Container;
using Common.Dependecies.Abstract;
using Common.Scenes.Abstract;
using Common.Scenes.Config;
using NPC.Config;
using Player.CoopPlayer.Config;
using UnityEngine;

namespace Herdsman.Scripts.GameStates.GameCoop
{
    [CreateAssetMenu(fileName = "CoopGameStateInstaller", menuName = "Installers/GameStates/CoopGameStateInstaller")]
    public class CoopGameStateInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private SceneConfigProviderSo sceneConfigProviderSo;
        [SerializeField] private PlayerSpawnDataConfigSo playerSpawnDataConfigSo;
        [SerializeField] private NpcSpawnDataConfigSo npcSpawnDataConfigSo;
        
        public override void Install(IInjectionContainer container)
        {
            container.Bind<INpcSpawnDataProvider>().To(npcSpawnDataConfigSo).As("CoopNpcDataProvider");
            container.Bind<IPlayerSpawnDataProvider>().To(playerSpawnDataConfigSo);
            container.Bind<ISceneConfigProvider>().To(sceneConfigProviderSo).As("CoopGameSceneConfigProvider");
            container.Bind<CoopGameStateHandler>().ToSingleton();
            container.Bind<CoopGameState>().ToSingleton();
        }
    }
}
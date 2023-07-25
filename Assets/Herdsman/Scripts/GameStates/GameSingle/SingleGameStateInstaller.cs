using Adic.Container;
using Common.Dependecies.Abstract;
using Common.Scenes.Abstract;
using Common.Scenes.Config;
using NPC.Config;
using UnityEngine;

namespace GameStates.SingleGame
{
    
    
    [CreateAssetMenu(fileName = "SingleGameStateInstaller", menuName = "Installers/GameStates/SingleGameStateInstaller")]
    public class SingleGameStateInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private SceneConfigProviderSo sceneConfigProviderSo;
        [SerializeField] private NpcSpawnDataConfigSo npcSpawnDataConfigSo;
        
        public override void Install(IInjectionContainer container)
        {
            //One sceneConfigProvider for only one handler
            //Use specific inject attributes for inject specific providers for different scenes.

            container.Bind<INpcSpawnDataProvider>().To(npcSpawnDataConfigSo).As("SingleSpawnDataProvider");
            container.Bind<ISceneConfigProvider>().To(sceneConfigProviderSo).As("SingleGameSceneConfigProvider");
            container.Bind<GameFieldHandler>().ToSingleton();
            container.Bind<SingleGameStateHandler>().ToSingleton();
            container.Bind<SingleGameState>().ToSingleton();
        }
    }
}
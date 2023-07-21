using Adic.Container;
using Common.Dependecies.Abstract;
using Common.Scenes.Abstract;
using Common.Scenes.Config;
using UnityEngine;

namespace GameStates.Game
{
    [CreateAssetMenu(fileName = "GameStateInstaller", menuName = "Installers/GameStateInstaller")]
    public class GameStateInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private SceneConfigProviderSo sceneConfigProviderSo;
        
        public override void Install(IInjectionContainer container)
        {
            //One sceneConfigProvider for only one handler
            //Use specific inject attributes for inject specific providers for different scenes.
            container.Bind<ISceneConfigProvider>().To(sceneConfigProviderSo);
            container.Bind<GameFieldHandler>().ToSingleton();
            container.Bind<GameStateHandler>().ToSingleton();
            container.Bind<GameState>().ToSingleton();
        }
    }
}
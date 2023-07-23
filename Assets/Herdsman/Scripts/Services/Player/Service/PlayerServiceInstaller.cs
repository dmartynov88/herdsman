using Adic.Container;
using Common.Dependecies.Abstract;
using Services.Player.Providers;
using UnityEngine;

namespace Services.Player.Service
{
    [CreateAssetMenu(fileName = "PlayerServiceInstaller", menuName = "Installers/PlayerServiceInstaller")]
    public class PlayerServiceInstaller : ScriptableObjectInstaller
    {
        public override void Install(IInjectionContainer container)
        {
            //IPlayerDataProvider, IPlayerDataSaver
            var playerPrefsDataProvider = new PlayerPrefsDataProvider();
            container.Bind<PlayerService>().To(new PlayerService(playerPrefsDataProvider, playerPrefsDataProvider));
        }
    }
   
}

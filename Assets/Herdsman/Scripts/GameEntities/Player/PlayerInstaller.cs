using Adic.Container;
using Dependecies.Abstract;
using UnityEngine;

namespace GameEntities.Player
{
    [CreateAssetMenu(fileName = "PlayerInstaller", menuName = "Installers/PlayerInstaller")]
    public class PlayerInstaller: ScriptableObjectInstaller
    {
        [SerializeField] private PlayerViewPool poolPrefab;
        
        public override void Install(IInjectionContainer container)
        {
            var pool = GameObject.Instantiate(poolPrefab);
            var factory = new PlayerMediatorFactory();
            var spawner = new GameEntitySpawner<PlayerMediator, PlayerView>(pool, factory);
            var handler = new PlayerHandler(spawner);
            container.Bind<PlayerHandler>().To(handler);
        }
    }
}
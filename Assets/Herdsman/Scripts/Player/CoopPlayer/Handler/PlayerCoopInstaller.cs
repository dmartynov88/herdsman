using Adic.Container;
using Common.Dependecies.Abstract;
using Common.GameEntities.Spawner;
using Player.CoopPlayer.Entity;
using Player.SinglePlayer.Entity;
using UnityEngine;

namespace Player.CoopPlayer
{
    [CreateAssetMenu(fileName = "PlayerCoopInstaller", menuName = "Installers/CoopPlayer/PlayerCoopInstaller")]
    public class PlayerCoopInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PlayerViewPool poolPrefab;
        
        public override void Install(IInjectionContainer container)
        {
            var pool = Instantiate(poolPrefab);
            var factory = new PlayerMediatorCoopFactory();
            var spawner = new GameEntitySpawner<PlayerCoopMediator, PlayerView>(pool, factory);
            container.Bind<GameEntitySpawner<PlayerCoopMediator, PlayerView>>().To(spawner);
            container.Bind<PlayerCoopHandler>().ToSingleton();
        }
    }
}
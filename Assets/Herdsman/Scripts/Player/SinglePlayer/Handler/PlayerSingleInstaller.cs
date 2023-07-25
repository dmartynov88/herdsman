using Adic.Container;
using Common.Dependecies.Abstract;
using Common.GameEntities.Spawner;
using Player.SinglePlayer.Entity;
using UnityEngine;

namespace Player.SinglePlayer
{
    [CreateAssetMenu(fileName = "PlayerSingleInstaller", menuName = "Installers/SinglePlayer/PlayerSingleInstaller")]
    public class PlayerSingleInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PlayerViewPool poolPrefab;

        public override void Install(IInjectionContainer container)
        {
            var pool = Instantiate(poolPrefab);
            var factory = new PlayerMediatorSingleFactory();
            var spawner = new GameEntitySpawner<PlayerSingleMediator, PlayerView>(pool, factory);
            container.Bind<GameEntitySpawner<PlayerSingleMediator, PlayerView>>().To(spawner);
            container.Bind<PlayerSingleHandler>().ToSingleton();
        }
    }
}
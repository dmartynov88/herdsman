using Common.GameEntities.Handler;
using Common.GameEntities.Spawner;
using Player.Entity;

namespace Player
{
    public class PlayerHandler : GameEntityHandlerBase<PlayerMediator, PlayerView>
    {
        //Main player game logic
        //Subscribe to PlayerMediator events

        public PlayerHandler(GameEntitySpawner<PlayerMediator, PlayerView> spawner) : base(spawner)
        {
        }
    }
}

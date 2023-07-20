using Common.GameEntities.Handler;
using Common.GameEntities.Spawner;
using NPC.Entity;

namespace NPC
{
    public class NpcHandler : GameEntityHandlerBase<NpcMediator, NpcView>
    {
        //Main NPC game logic
        //Subscribe to NpcMediator events
        
        public NpcHandler(GameEntitySpawner<NpcMediator, NpcView> spawner) : base(spawner)
        {
        }
    }
}

using Common.GameEntities.Abstract;

namespace NPC.Entity
{
    public class NpcMediator : GameEntityMediatorBase<NpcView>
    {
        //Class for NPC character logic



        protected override void OnViewReady()
        {
            //Add custom components to view
        }

        protected override void OnDestroy()
        {
            //Remove custom components from view
        }
    }
}

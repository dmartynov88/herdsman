using Common.GameEntities.Abstract;

namespace Player.Entity
{
    public class PlayerMediator : GameEntityMediatorBase<PlayerView>
    {
        //Class for player character logic



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

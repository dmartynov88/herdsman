using Common.GameEntities.Abstract;

namespace Common.GameEntities.InteractableObject
{
    public class InteractableObjectMediator : GameEntityMediatorBase<InteractableObjectView>
    {
        //Class for base interactable object (loot, other scene objects for interact)
        //Object is static (doesn't move)
        
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
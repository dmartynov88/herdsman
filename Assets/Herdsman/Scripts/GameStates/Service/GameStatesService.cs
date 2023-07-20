using Common.States.Abstract;
using GameStates.Abstract;

namespace GameStates.Service
{
    public class GameStatesService : GameStatesServiceBase
    {
        
        public override void Initialize(IGameStatesProvider statetsProvider)
        {
            var mainStateId = (int)GameStateType.Main;
            AddState(mainStateId, statetsProvider.GetStateByTypeId(mainStateId));

            var gameStateId = (int)GameStateType.Game;
            AddState(gameStateId, statetsProvider.GetStateByTypeId(gameStateId));
            
            var resetStateId = (int)GameStateType.Reset;
            AddState(resetStateId, statetsProvider.GetStateByTypeId(resetStateId));
        }
    }
}
using Common.States.Abstract;
using GameStates.Abstract;

namespace GameStates.Service
{
    public class GameStatesService : GameStatesServiceBase
    {
        public override void Initialize(IGameStatesProvider statesProvider)
        {
            var mainStateId = (int)GameStateType.Main;
            AddState(mainStateId, statesProvider.GetStateByTypeId(mainStateId));

            var singleGameStateId = (int)GameStateType.SingleGame;
            AddState(singleGameStateId, statesProvider.GetStateByTypeId(singleGameStateId));
            
            var coopGameStateId = (int)GameStateType.CoopGame;
            AddState(coopGameStateId, statesProvider.GetStateByTypeId(coopGameStateId));
            
            var resetStateId = (int)GameStateType.Reset;
            AddState(resetStateId, statesProvider.GetStateByTypeId(resetStateId));
            
        }
    }
}
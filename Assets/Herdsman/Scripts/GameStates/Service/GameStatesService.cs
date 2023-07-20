using Common.States.Abstract;
using GameStates.Abstract;

namespace GameStates.Service
{
    public class GameStatesService : GameStatesServiceBase
    {
        public GameStatesService(IGameStateFactory statesFactory) : base(statesFactory)
        {
        }
        protected override void CreateGameStates()
        {
            
        }
    }
}
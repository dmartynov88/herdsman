using Common.States.Abstract;

namespace GameStates.SingleGame
{
    public sealed class SingleGameState : GameStateBase<SingleGameStateHandler>
    {
        public SingleGameState(SingleGameStateHandler stateHandler) : base(stateHandler)
        {
        }
    }
}
using Common.States.Abstract;

namespace GameStates.Reset
{
    public sealed class ResetGameState : GameStateBase<ResetStateHandler>
    {
        public ResetGameState(ResetStateHandler stateHandler) : base(stateHandler)
        {
        }
    }
}
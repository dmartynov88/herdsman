using Adic;
using Common.States.Abstract;

public sealed class ResetGameState : GameStateBase<ResetStateHandler>
{
    public ResetGameState(ResetStateHandler stateHandler) : base(stateHandler)
    {
    }
}
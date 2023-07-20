using Adic;
using Common.States.Abstract;

public sealed class ResetGameState : GameStateBase<ResetStateHandler>
{
    protected override ResetStateHandler StateHandler => stateHandler;
    [Inject] private ResetStateHandler stateHandler;
}
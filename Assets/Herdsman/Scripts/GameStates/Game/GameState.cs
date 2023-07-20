using Adic;
using Common.States.Abstract;

public sealed class GameState : GameStateBase<GameStateHandler>
{
    protected override GameStateHandler StateHandler => stateHandler;
    [Inject] private GameStateHandler stateHandler;
}
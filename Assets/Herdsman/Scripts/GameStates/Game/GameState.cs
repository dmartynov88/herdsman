using Common.States.Abstract;

public sealed class GameState : GameStateBase<GameStateHandler>
{
    public GameState(GameStateHandler stateHandler) : base(stateHandler)
    {
    }
}
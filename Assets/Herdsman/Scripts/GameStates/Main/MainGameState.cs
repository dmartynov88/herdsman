using Common.States.Abstract;

namespace GameStates.Main
{
    public sealed class MainGameState : GameStateBase<MainGameStateHandler>
    {
        public MainGameState(MainGameStateHandler stateHandler) : base(stateHandler)
        {

        }
    }
}
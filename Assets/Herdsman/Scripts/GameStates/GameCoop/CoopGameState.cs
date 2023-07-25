using Common.States.Abstract;

namespace Herdsman.Scripts.GameStates.GameCoop
{
    public sealed class CoopGameState : GameStateBase<CoopGameStateHandler>
    {
        public CoopGameState(CoopGameStateHandler stateHandler) : base(stateHandler)
        {
        }
    }
}
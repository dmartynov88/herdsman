using Adic;
using Cysharp.Threading.Tasks;

namespace Common.States.Abstract
{
    public abstract class GameStateBase<TStateHandler> : IGameState where TStateHandler : IGameStateHandler, new()
    {
        private readonly TStateHandler stateHandler;
        
        public GameStateBase(TStateHandler stateHandler)
        {
            this.stateHandler = stateHandler;
        }

        public virtual void Enter()
        {
            stateHandler.Start();
        }

        public virtual UniTask Exit()
        {
            return stateHandler.Finish();
        }
    }
}
using Adic;
using Cysharp.Threading.Tasks;

namespace Common.States.Abstract
{
    public class GameState<TStateHandler> : IGameState where TStateHandler : IGameStateHandler, new()
    {
        [Inject]
        private readonly TStateHandler stateHandler;
        
        public virtual UniTask Enter()
        {
            return stateHandler.Start();
        }

        public virtual UniTask Exit()
        {
            return stateHandler.Finish();
        }
    }
}
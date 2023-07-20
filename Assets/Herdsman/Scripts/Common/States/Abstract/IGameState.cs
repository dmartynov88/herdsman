using Cysharp.Threading.Tasks;

namespace Common.States.Abstract
{
    public interface IGameState
    {
        void Enter();
        UniTask Exit();
    }
}


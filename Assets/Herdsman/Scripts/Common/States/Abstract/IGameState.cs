using Cysharp.Threading.Tasks;

namespace Common.States.Abstract
{
    public interface IGameState
    {
        UniTask Enter();
        UniTask Exit();
    }
}


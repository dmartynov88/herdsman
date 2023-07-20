using Cysharp.Threading.Tasks;

namespace Common.States.Abstract
{
    public interface IGameStateHandler
    {
        void Start();
        UniTask Finish();
    }
}
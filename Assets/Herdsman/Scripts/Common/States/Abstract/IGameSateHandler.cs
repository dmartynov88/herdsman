using Cysharp.Threading.Tasks;

namespace Common.States.Abstract
{
    public interface IGameStateHandler
    {
        UniTask Start();
        UniTask Finish();
    }
}
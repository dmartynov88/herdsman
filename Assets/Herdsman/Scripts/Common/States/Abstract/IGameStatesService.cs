using Cysharp.Threading.Tasks;

namespace Common.States.Abstract
{
    public interface IGameStatesService
    {
        UniTask SwitchState(int gameStateTypeId);
        void Initialize(IGameStatesProvider statetsProvider);
    }
}

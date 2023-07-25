using System;
using Cysharp.Threading.Tasks;

namespace Common.States.Abstract
{
    public interface IGameStatesService : IDisposable
    { 
        UniTask SwitchState(int gameStateTypeId);
        void Initialize(IGameStatesProvider statetsProvider);
    }
}

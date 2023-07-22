using System;
using Cysharp.Threading.Tasks;

namespace Common.States.Abstract
{
    public interface IGameState : IDisposable
    {
        void Enter();
        UniTask Exit();
    }
}


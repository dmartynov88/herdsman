using System;
using Cysharp.Threading.Tasks;

namespace Common.States.Abstract
{
    public interface IGameStateHandler : IDisposable
    {
        void Start();
        UniTask Finish();
    }
}
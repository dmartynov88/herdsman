using System;
using System.Collections.Generic;
using Common.Service.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.States.Abstract
{
    //ToDo bind by IGameStatesService
    public abstract class GameStatesServiceBase : IGameStatesService
    {
        private readonly Dictionary<int, IGameState> states = new();

        private IGameState currentState;

        public abstract void Initialize(IGameStatesProvider statetsProvider);

        //ToDo add logic for specific transitions if needed
        public async UniTask SwitchState(int gameStateTypeId)
        {
            if (states.TryGetValue(gameStateTypeId, out IGameState nextState))
            {
                if (currentState != null)
                {
                    await currentState.Exit();
                }

                currentState = nextState;

                currentState.Enter();
            }
        }

        protected void AddState(int gameStateTypeId, IGameState state)
        {
            if (!states.TryAdd(gameStateTypeId, state))
            {
                throw new ArgumentException($"Can't add state {state.GetType()}");
            }
        }
    }
}

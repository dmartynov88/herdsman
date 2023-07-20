using System.Collections.Generic;
using Common.Service.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.States.Abstract
{
    //ToDo bind by IGameStatesService
    public abstract class GameStatesServiceBase : IGameStatesService, IService
    {
        private readonly Dictionary<int, IGameState> states = new();
        private readonly IGameStateFactory statesFactory;

        private IGameState currentState;


        protected GameStatesServiceBase(IGameStateFactory statesFactory)
        {
            this.statesFactory = statesFactory;
        }

        //create and cache game states

        public UniTask Initialize()
        {
            CreateGameStates();
            return UniTask.CompletedTask;
        }

        protected abstract void CreateGameStates();

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

                await currentState.Enter();
            }
        }
    }
}

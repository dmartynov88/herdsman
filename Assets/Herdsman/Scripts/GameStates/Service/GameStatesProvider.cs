using System;
using Common.States.Abstract;
using GameStates.Abstract;
using GameStates.Main;
using GameStates.Reset;
using GameStates.SingleGame;

namespace GameStates.Service
{
    public class GameStatesProvider : IGameStatesProvider
    {
        private readonly MainGameState mainGameState;
        private readonly SingleGameState singleGameState;
        private readonly ResetGameState resetGameState;

        public GameStatesProvider(MainGameState mainGameState, SingleGameState singleGameState, ResetGameState resetGameState)
        {
            this.mainGameState = mainGameState;
            this.singleGameState = singleGameState;
            this.resetGameState = resetGameState;
        }

        public IGameState GetStateByTypeId(int gameStateTypeId)
        {
            return (GameStateType)gameStateTypeId switch
            {
                GameStateType.Main => mainGameState,
                GameStateType.Game => singleGameState,
                GameStateType.Reset => resetGameState,
                _ => throw new ArgumentException($"Can't get state by GameStateType {(GameStateType)gameStateTypeId}")
            };
        }
    }
}
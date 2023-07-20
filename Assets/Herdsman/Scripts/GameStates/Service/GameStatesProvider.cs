using System;
using Common.States.Abstract;
using GameStates.Abstract;

namespace GameStates.Service
{
    public class GameStatesProvider : IGameStatesProvider
    {
        private readonly MainGameState mainGameState;
        private readonly GameState gameState;
        private readonly ResetGameState resetGameState;

        public GameStatesProvider(MainGameState mainGameState, GameState gameState, ResetGameState resetGameState)
        {
            this.mainGameState = mainGameState;
            this.gameState = gameState;
            this.resetGameState = resetGameState;
        }

        public IGameState GetStateByType(int gameStateTypeId)
        {
            return (GameStateType)gameStateTypeId switch
            {
                GameStateType.Main => mainGameState,
                GameStateType.Game => mainGameState,
                GameStateType.Reset => mainGameState,
                _ => throw new ArgumentException($"Can't get state by GameStateType {(GameStateType)gameStateTypeId}")
            };
        }
    }
}
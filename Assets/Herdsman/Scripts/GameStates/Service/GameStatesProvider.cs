using System;
using Common.States.Abstract;
using GameStates.Abstract;
using GameStates.Main;
using GameStates.Reset;
using GameStates.SingleGame;
using Herdsman.Scripts.GameStates.GameCoop;

namespace GameStates.Service
{
    public class GameStatesProvider : IGameStatesProvider
    {
        private readonly MainGameState mainGameState;
        private readonly SingleGameState singleGameState;
        private readonly CoopGameState coopGameState;
        private readonly ResetGameState resetGameState;

        public GameStatesProvider(MainGameState mainGameState, SingleGameState singleGameState, CoopGameState coopGameState, ResetGameState resetGameState)
        {
            this.mainGameState = mainGameState;
            this.singleGameState = singleGameState;
            this.coopGameState = coopGameState;
            this.resetGameState = resetGameState;
        }

        public IGameState GetStateByTypeId(int gameStateTypeId)
        {
            return (GameStateType)gameStateTypeId switch
            {
                GameStateType.Main => mainGameState,
                GameStateType.SingleGame => singleGameState,
                GameStateType.CoopGame => coopGameState,
                GameStateType.Reset => resetGameState,
                _ => throw new ArgumentException($"Can't get state by GameStateType {(GameStateType)gameStateTypeId}")
            };
        }
    }
}
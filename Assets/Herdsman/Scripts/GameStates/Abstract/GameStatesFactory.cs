using System;
using Common.States.Abstract;

namespace GameStates.Abstract
{
    public class GameStatesFactory : IGameStateFactory
    {
        public IGameState CreateState(int gameStateTypeId)
        {
            return (GameStateType)gameStateTypeId switch
            {
                GameStateType.Main => new GameState<MainGameStateHandler>(),
                GameStateType.Game => new GameState<GameStateHandler>(),
                GameStateType.Reset => new GameState<ResetStateHandler>(),
                _=> throw new ArgumentException("Unknown Game State type id!")
            };
        }
    }
}
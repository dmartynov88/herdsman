namespace Common.States.Abstract
{
    public interface IGameStatesProvider
    {
        IGameState GetStateByType(int gameStateTypeId);
    }
}
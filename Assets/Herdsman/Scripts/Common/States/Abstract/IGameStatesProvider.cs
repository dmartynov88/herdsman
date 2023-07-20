namespace Common.States.Abstract
{
    public interface IGameStatesProvider
    {
        IGameState GetStateByTypeId(int gameStateTypeId);
    }
}
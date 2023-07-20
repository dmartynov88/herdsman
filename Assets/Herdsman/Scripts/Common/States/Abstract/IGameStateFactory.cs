namespace Common.States.Abstract
{
    public interface IGameStateFactory
    {
        public IGameState CreateState(int gameStateTypeId);
    }
}

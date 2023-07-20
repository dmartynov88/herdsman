using Common.States.Abstract;
using Cysharp.Threading.Tasks;

public class GameStateHandler : IGameStateHandler
{
    public UniTask Start()
    {
        return UniTask.CompletedTask;
    }

    public UniTask Finish()
    {
        return UniTask.CompletedTask;
    }
}

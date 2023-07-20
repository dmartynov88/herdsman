using Common.States.Abstract;
using Cysharp.Threading.Tasks;

public class ResetStateHandler : IGameStateHandler
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

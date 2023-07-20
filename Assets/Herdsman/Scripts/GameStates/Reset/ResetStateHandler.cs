using Common.States.Abstract;
using Cysharp.Threading.Tasks;

public class ResetStateHandler : IGameStateHandler
{
    public void Start()
    {
        
    }

    public UniTask Finish()
    {
        return UniTask.CompletedTask;
    }
}
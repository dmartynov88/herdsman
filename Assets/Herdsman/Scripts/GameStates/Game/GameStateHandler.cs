using Common.States.Abstract;
using Cysharp.Threading.Tasks;

public class GameStateHandler : IGameStateHandler
{
    public void Start()
    {
        UnityEngine.Debug.Log($"Start Game");
    }

    public UniTask Finish()
    {
        return UniTask.CompletedTask;
    }
}
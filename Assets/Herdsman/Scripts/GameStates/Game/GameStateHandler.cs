using Adic;
using Common.States.Abstract;
using Cysharp.Threading.Tasks;
using Player;

public class GameStateHandler : IGameStateHandler
{
    [Inject] private PlayerHandler PlayerHandler { get; set; }

    public void Start()
    {
        UnityEngine.Debug.Log($"Start Game");
        PlayerHandler.CreatePlayer().Forget();
    }

    public UniTask Finish()
    {
        PlayerHandler.DestroyPlayer();
        return UniTask.CompletedTask;
    }
}
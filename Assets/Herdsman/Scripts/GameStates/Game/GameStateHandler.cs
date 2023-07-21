using Adic;
using Common.Scenes.Abstract;
using Common.States.Abstract;
using Cysharp.Threading.Tasks;
using Player;

public class GameStateHandler : IGameStateHandler
{
    //One sceneConfigProvider for one handler
    //Use specific inject attributes for inject specific providers for different scenes.
    [Inject] private ISceneConfigProvider sceneConfigProvider;
    [Inject] private GameFieldHandler gameFieldHandler;
    [Inject] private PlayerHandler PlayerHandler { get; set; }


    //Load Field scene
    //Game UI
    //Create player
    //Create NPCs

    public void Start()
    {
        UnityEngine.Debug.Log($"Start Game");
        
        Initialize().Forget();
    }

    private async UniTaskVoid Initialize()
    {
        await gameFieldHandler.LoadGameField(sceneConfigProvider.GetSceneConfig());
        await PlayerHandler.CreatePlayer();
    }

    public UniTask Finish()
    {
        PlayerHandler.DestroyPlayer();
        return UniTask.CompletedTask;
    }
}
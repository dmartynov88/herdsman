using Adic;
using Common.States.Abstract;
using Cysharp.Threading.Tasks;
using GameStates.Abstract;

public class MainGameStateHandler : IGameStateHandler
{
    [Inject] private IGameStatesService GameStatesService { get; set; }

    public void Start()
    {
        GameStatesService.SwitchState((int)GameStateType.Game);
    }

    public UniTask Finish()
    {
        return UniTask.CompletedTask;
    }
}
using Adic;
using Common.GameEntities.Models;
using Common.Scenes.Abstract;
using Common.States.Abstract;
using Common.UI.Config;
using Cysharp.Threading.Tasks;
using GameStates.Abstract;
using NPC.Config;
using NPC.SinglePlayer;
using Player.SinglePlayer;
using Services.UI.Service;
using Services.UI.Windows.Game;

namespace GameStates.SingleGame
{
    public class SingleGameStateHandler : IGameStateHandler
    {
        //One sceneConfigProvider for one handler
        [Inject("SingleGameSceneConfigProvider")] private ISceneConfigProvider sceneConfigProvider { get; set; }
        [Inject("SingleSpawnDataProvider")] private INpcSpawnDataProvider NpcSpawnDataProvider { get; set; }
        [Inject] private GameFieldHandler gameFieldHandler;
        [Inject] private PlayerSingleHandler PlayerSingleHandler { get; set; }
        [Inject] private NpcSingleHandler NpcSingleHandler { get; set; }
        [Inject] private UiService UiService { get; set; }
        [Inject] private IGameStatesService GameStatesService { get; set; }

        private readonly SpawnData playerSpawnData = new () { AddressableName = "Player" };
        
        private GameWindowShowParameters uiShowParameters;
        
        //Load Field scene
        //Game UI

        public void Start()
        {
            UnityEngine.Debug.Log($"Start Game");

            Initialize().Forget();
        }

        private async UniTaskVoid Initialize()
        {
            await gameFieldHandler.LoadGameField(sceneConfigProvider.GetSceneConfig());
            await PlayerSingleHandler.CreatePlayer(playerSpawnData);
            
            //set from npc start points provider
            await NpcSingleHandler.CreateNpcs(NpcSpawnDataProvider.GetNpcSpawnData());
            
            //Simple realization
            uiShowParameters = new GameWindowShowParameters();
            uiShowParameters.RestartGamePressed = SwitchToReset;
            
            await UiService.ShowWindow(WindowType.GameSingle, uiShowParameters);
        }

        private void SwitchToReset()
        {
            uiShowParameters.RestartGamePressed = null;
            uiShowParameters = null;
            SwitchToResetUniTask().Forget();
        }

        private async UniTaskVoid SwitchToResetUniTask()
        {
            //Simple realization without windows queue and preloader, etc.
            UiService.HideWindow();
            GameStatesService.SwitchState((int)GameStateType.Reset);
        }
        
        public UniTask Finish()
        {
            NpcSingleHandler.DestroyNpcs();
            PlayerSingleHandler.DestroyPlayer();
            return gameFieldHandler.UnloadGameField();
        }

        public void Dispose()
        {
        }
    }
}

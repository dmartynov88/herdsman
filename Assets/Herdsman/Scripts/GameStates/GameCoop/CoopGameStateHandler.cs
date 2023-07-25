using Adic;
using Common.GameEntities.Models;
using Common.Scenes.Abstract;
using Common.States.Abstract;
using Common.UI.Config;
using Cysharp.Threading.Tasks;
using GameStates.Abstract;
using Herdsman.Scripts.NPC.LocalMode.CoopHandler;
using NPC.Config;
using Player.CoopPlayer;
using Player.CoopPlayer.Config;
using Services.UI.Service;
using Services.UI.Windows.Game;

namespace Herdsman.Scripts.GameStates.GameCoop
{
    public class CoopGameStateHandler : IGameStateHandler
    {
        [Inject("CoopGameSceneConfigProvider")] private ISceneConfigProvider sceneConfigProvider { get; set; }
        [Inject("CoopNpcDataProvider")] private INpcSpawnDataProvider NpcSpawnDataProvider { get; set; }
        [Inject] private GameFieldHandler gameFieldHandler;
        [Inject] private PlayerCoopHandler PlayerCoopHandler { get; set; }
        [Inject] private IPlayerSpawnDataProvider PlayerSpawnDataProvider { get; set; }
        [Inject] private NpcCoopHandler NpcCoopHandler { get; set; }
        [Inject] private UiService UiService { get; set; }
        [Inject] private IGameStatesService GameStatesService { get; set; }
        
        private GameWindowShowParameters uiShowParameters;
        
        public void Start()
        {
            Initialize().Forget();
        }
        
        private async UniTaskVoid Initialize()
        {
            await gameFieldHandler.LoadGameField(sceneConfigProvider.GetSceneConfig());

            await PlayerCoopHandler.CreatePlayers(
                new SpawnData{ AddressableName = "Player", Position = PlayerSpawnDataProvider.GetPlayerSpawnData()[0].Position },
                new SpawnData{ AddressableName = "Player", Position = PlayerSpawnDataProvider.GetPlayerSpawnData()[1].Position });
            
            await NpcCoopHandler.CreateNpcs(NpcSpawnDataProvider.GetNpcSpawnData());
            
            uiShowParameters = new GameWindowShowParameters
            {
                RestartGamePressed = SwitchToReset
            };

            await UiService.ShowWindow(WindowType.GameCoop, uiShowParameters);
        }
        
        private void SwitchToReset()
        {
            uiShowParameters.RestartGamePressed = null;
            uiShowParameters = null;
            SwitchToResetUniTask().Forget();
        }
        
        private async UniTaskVoid SwitchToResetUniTask()
        {
            await UiService.HideWindow();
            GameStatesService.SwitchState((int)GameStateType.Reset);
        }

        public UniTask Finish()
        {
            NpcCoopHandler.DestroyNpcs();
            PlayerCoopHandler.DestroyPlayers();
            return gameFieldHandler.UnloadGameField();
        }
        
        public void Dispose()
        {
        }
    }
}
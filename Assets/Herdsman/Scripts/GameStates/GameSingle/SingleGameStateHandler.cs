using System.Collections.Generic;
using Adic;
using Common.GameEntities.Models;
using Common.Scenes.Abstract;
using Common.States.Abstract;
using Cysharp.Threading.Tasks;
using NPC.Config;
using NPC.SinglePlayer;
using Player.SinglePlayer;
using UnityEngine;

namespace GameStates.SingleGame
{
    public class SingleGameStateHandler : IGameStateHandler
    {
        //One sceneConfigProvider for one handler
        //Use specific inject attributes for inject specific providers for different scenes.
        [Inject] private ISceneConfigProvider sceneConfigProvider;
        [Inject] private GameFieldHandler gameFieldHandler;
        [Inject] private PlayerSingleHandler PlayerSingleHandler { get; set; }
        [Inject] private INpcSpawnDataProvider NpcSpawnDataProvider { get; set; }
        [Inject] private NpcSingleHandler NpcSingleHandler { get; set; }

        private readonly SpawnData playerSpawnData = new SpawnData() { AddressableName = "Player" };
        
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
        }

        public UniTask Finish()
        {
            NpcSingleHandler.DestroyNpcs();
            PlayerSingleHandler.DestroyPlayer();
            return UniTask.CompletedTask;
        }

        public void Dispose()
        {
            NpcSingleHandler.DestroyNpcs();
            PlayerSingleHandler.DestroyPlayer();
        }
    }
}

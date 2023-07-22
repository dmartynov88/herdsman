using System.Collections.Generic;
using Adic;
using Common.GameEntities.Models;
using Common.Scenes.Abstract;
using Common.States.Abstract;
using Cysharp.Threading.Tasks;
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
        [Inject] private NpcSingleHandler Handler { get; set; }


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
            await PlayerSingleHandler.CreatePlayer(new SpawnData() { AddressableName = "Player" });
            await Handler.CreateNpcs(new List<SpawnData>()
            {
                new SpawnData() { AddressableName = "Npc", Position = Vector3.left * 2 },
                new SpawnData() { AddressableName = "Npc", Position = Vector3.right * 2 }
            });
        }

        public UniTask Finish()
        {
            PlayerSingleHandler.DestroyPlayer();
            return UniTask.CompletedTask;
        }
    }
}

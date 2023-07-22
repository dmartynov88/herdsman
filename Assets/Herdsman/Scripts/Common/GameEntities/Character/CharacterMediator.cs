using Common.GameEntities.Abstract;
using Common.GameEntities.Models;
using Cysharp.Threading.Tasks;
using Herdsman.Scripts.Common.GameEntities.Character;
using UnityEngine;

namespace Common.GameEntities.Character
{
    public abstract class CharacterMediator<TView> : GameEntityMediatorBase<TView>
        where TView : CharacterView
    {
        //ToDo common model for send entity data by network (id, name, pos, rot)
        //represents real state of entity's Transform, only for read by network system
        public CharacterModel CharacterModel { get; private set; }

        protected override async UniTask Initialize(uint entityId, TView view, SpawnData spawnData)
        {
            await base.Initialize(entityId, view, spawnData);
            CharacterModel = new CharacterModel(EntityId, spawnData.AddressableName, View.Transform);
        }
    }
}
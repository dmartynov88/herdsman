using System;
using UnityEngine;

namespace Common.GameEntities.Abstract
{
    public interface IGameEntityView
    {
        Transform Transform { get; }
        public bool HasGraphics { get; }
        void CacheViewObject(GameObject viewObject);
        void InitializeView();
        void ResetView();
    }

    public abstract class GameEntityViewBase : MonoBehaviour, IGameEntityView
    {
        public Transform Transform { get; private set; }
        public bool HasGraphics { get; private set; }
        
        private GameObject viewObject;

        private void Awake()
        {
            Transform = transform;
        }
        

        public void CacheViewObject(GameObject viewObject)
        {
            this.viewObject = viewObject;
            HasGraphics = true;
        }
        
        //Subscribe and cache to view components
        public abstract void InitializeView();

        //Unsubscribe from view components
        public abstract void ResetView();
    }
}

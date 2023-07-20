using System;
using UnityEngine;

namespace Common.GameEntities.Abstract
{
    public interface IGameEntityView
    {
        Transform Transform { get; }
        public bool HasGraphics { get; }
        void CacheViewObject(GameObject viewObject);
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
            InitializeView();
            HasGraphics = true;
        }
        
        //Subscribe and cache to view components
        protected virtual void InitializeView()
        {
            
        }

        //Unsubscribe from view components
        public virtual void ResetView()
        {
            
        }
    }
}

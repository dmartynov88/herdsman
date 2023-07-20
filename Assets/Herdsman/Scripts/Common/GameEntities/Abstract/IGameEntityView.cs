using System;
using UnityEngine;

namespace Common.GameEntities.Abstract
{
    public interface IGameEntityView
    {
        Transform Transform { get; }
        public bool HasGraphics { get; }
        void SetViewObject(GameObject viewObject);
        void ResetView();
    }

    public abstract class GameEntityViewBase : MonoBehaviour, IGameEntityView
    {
        public Transform Transform { get; private set; }
        public bool HasGraphics { get; private set; }

        private void Awake()
        {
            Transform = transform;
        }

        public virtual void SetViewObject(GameObject viewObject)
        {
            if (viewObject != null)
            {
                transform.SetParent(Transform, false);
                InitializeView();
                HasGraphics = true;
            }
            else
            {
                throw new ArgumentException("View game object is null!");
            }
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

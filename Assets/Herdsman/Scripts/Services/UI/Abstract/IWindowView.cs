using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Services.UI.Abstract
{
    public interface IWindowView
    {
        Transform Transform { get; }
    }

    public abstract class WindowViewBase : MonoBehaviour, IWindowView
    {
        public Transform Transform { get; private set; }

        private void Awake()
        {
            Transform = transform;
        }

        public abstract UniTask InitializeView();
    }
}
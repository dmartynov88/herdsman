using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.UI.Abstract
{
    public interface IWindowView
    {
        Transform Transform { get; }
    }

    public abstract class WindowViewBase<TModel> : MonoBehaviour, IWindowView
    where TModel : IWindowModel
    {
        public Transform Transform { get; private set; }

        private void Awake()
        {
            Transform = transform;
        }

        public abstract UniTask InitializeView(TModel model);

        public virtual void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}
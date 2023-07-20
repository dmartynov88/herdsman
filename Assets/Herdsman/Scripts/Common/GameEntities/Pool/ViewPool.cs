using System.Collections.Generic;
using Common.GameEntities.Abstract;
using UnityEngine;

//Simple stupid pool for test

namespace Common.GameEntities.Pool
{
    public class ViewPool<TView> : MonoBehaviour
        where TView : IGameEntityView
    {
        [SerializeField] private Transform viewPrefab;
        [SerializeField] private Transform poolParent;
        [SerializeField] private Transform activeParent;
        [SerializeField] private uint startCount;
        
        private List<TView> pool;
        
        private void Awake()
        {
            pool = new List<TView>();
            for (int i = 0; i < startCount; i++)
            {
                TView entity = CreateView(new Vector3(0, -1000, 0));
                entity.Transform.SetParent(poolParent);
                pool.Add(entity);
            }
        }

        public TView Get(Vector3 position)
        {
            TView view;
            if (pool.Count > 0)
            {
                view = pool[0] ?? CreateView(position);
                pool.RemoveAt(0);
            }
            else
            {
                view = CreateView(position);
            }

            if (view != null)
            {
                view.Transform.position = position;
                view.Transform.SetParent(activeParent, true);
            }

            return view;
        }

        public void ReturnToPool(TView view)
        {
            if (view != null)
            {
                view.ResetView();
                view.Transform.SetParent(poolParent);
                view.Transform.position = new Vector3(0, -1000, 0);
                pool.Add(view);
            }
        }

        private TView CreateView(Vector3 position)
        {
            var view = Instantiate(viewPrefab, position, Quaternion.identity);
            return view.GetComponent<TView>();
        }
    }
}
﻿using System;
using Adic;
using Cysharp.Threading.Tasks;
using Services.UI.Abstract;
using UnityEngine;

namespace ervices.UI.Service
{
    public class UiService : MonoBehaviour
    {
        [SerializeField] private Transform windowsRoot;
        [Inject] private IWindowMediatorFactory mediatorFactory;

        public async UniTask<IWindowMediator> ShowWindow(WindowType windowType)
        {
            var result = await mediatorFactory.CreateMediator(windowType, windowsRoot);
            
            //Show

            return result;
        }
    }
}
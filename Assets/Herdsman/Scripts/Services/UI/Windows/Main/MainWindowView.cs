using System;
using Cysharp.Threading.Tasks;
using Common.UI.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Services.UI.Windows.Main
{
    public class MainWindowView : WindowViewBase<MainWindowModel>
    {
        public event Action StartCoopGameClicked;
        public event Action StartSingleGameClicked;
        
        [SerializeField] private Button startSingleGameBnt;
        [SerializeField] private Button startCoopGameBnt;
        
        public override UniTask InitializeView(MainWindowModel model)
        {
            //ToDo += -= on set active?
            startSingleGameBnt.onClick.AddListener(OnStartSingleGameClicked);
            startCoopGameBnt.onClick.AddListener(OnStartCoopGameClicked);
            return base.InitializeView(model);
        }

        private void OnStartSingleGameClicked()
        {
            StartSingleGameClicked?.Invoke();
        }
        
        private void OnStartCoopGameClicked()
        {
            StartCoopGameClicked?.Invoke();
        }
    }
}
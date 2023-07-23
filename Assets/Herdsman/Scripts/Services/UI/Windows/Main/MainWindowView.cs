using System;
using Cysharp.Threading.Tasks;
using Common.UI.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Services.UI.Windows.Main
{
    public class MainWindowView : WindowViewBase<MainWindowModel>
    {
        public event Action StartGameClicked;
        
        [SerializeField] private Button startGameBnt;
        
        public override UniTask InitializeView(MainWindowModel model)
        {
            //ToDo += -= on set active?
            startGameBnt.onClick.AddListener(OnStarnGameClicked);
            return base.InitializeView(model);
        }

        private void OnStarnGameClicked()
        {
            StartGameClicked?.Invoke();
        }
    }
}
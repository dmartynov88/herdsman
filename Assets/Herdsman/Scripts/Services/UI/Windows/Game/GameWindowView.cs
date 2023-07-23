using System;
using Common.UI.Abstract;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Services.UI.Windows.Game
{
    public class GameWindowView : WindowViewBase<GameWindowModel>
    {
        public event Action RestartGameClicked;

        //ToDo localization key
        private const string score_text = "Total Score: ";
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private Button restartGameBnt;

        public override UniTask InitializeView(GameWindowModel model)
        {
            restartGameBnt.onClick.AddListener(OnStarnGameClicked);
            return base.InitializeView(model);
        }

        public override void SetActive(bool isActive)
        {
            if (isActive)
            {
                Model.ModelChanged += OnModelChanged;
            }
            
            base.SetActive(isActive);
        }

        private void OnModelChanged()
        {
            //ToDo optimize
            scoreText.text = score_text + Model.TotalScore;
        }

        private void OnDisable()
        {
            Model.ModelChanged -= OnModelChanged;
        }
        
        private void OnStarnGameClicked()
        {
            RestartGameClicked?.Invoke();
        }
    }
}
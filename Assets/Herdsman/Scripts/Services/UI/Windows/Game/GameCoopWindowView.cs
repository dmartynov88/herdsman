using System;
using System.Text;
using Common.UI.Abstract;
using Cysharp.Threading.Tasks;
using Services.UI.Windows.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCoopWindowView : WindowViewBase<CoopGameWindowModel>
{
    public event Action RestartGameClicked;
    private const string score_text_format = "Player {0}: {1}";
    
    [SerializeField] private TMP_Text player1scoreText;
    [SerializeField] private TMP_Text player2scoreText;
    [SerializeField] private Button restartGameBnt;
    
    public override UniTask InitializeView(CoopGameWindowModel model)
    {
        restartGameBnt.onClick.AddListener(OnStartGameClicked);
        return base.InitializeView(model);
    }

    public override void SetActive(bool isActive)
    {
        if (isActive)
        {
            OnModelChanged();
            Model.ModelChanged += OnModelChanged;
        }
            
        base.SetActive(isActive);
    }

    private void OnModelChanged()
    {
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        player1scoreText.text = sb1.AppendFormat(score_text_format, 1, Model.Player1Score).ToString();
        player2scoreText.text = sb2.AppendFormat(score_text_format, 2, Model.Player2Score).ToString();
    }

    private void OnDisable()
    {
        Model.ModelChanged -= OnModelChanged;
    }
        
    private void OnStartGameClicked()
    {
        RestartGameClicked?.Invoke();
    }
}

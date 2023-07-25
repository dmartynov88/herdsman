using System;
using Common.UI.Abstract;
using Cysharp.Threading.Tasks;
using Services.UI.Windows.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCoopWindowView : WindowViewBase<CoopGameWindowModel>
{
    public event Action RestartGameClicked;
    private const string score_text = "Player {0}: ";
    
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
        //ToDo optimize
        player1scoreText.text = score_text + Model.Player1Score;
        player2scoreText.text = score_text + Model.Player2Score;
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

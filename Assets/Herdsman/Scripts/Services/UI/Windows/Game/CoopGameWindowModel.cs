using System;
using Common.UI.Abstract;

namespace Services.UI.Windows.Game
{
    public class CoopGameWindowModel : IWindowModel
    {
        public event Action ModelChanged;
        public int Player1Score { get; private set; }
        public int Player2Score { get; private set; }
        

        public void SetData(int player1Score, int player2Score)
        {
            Player1Score = player1Score;
            Player2Score = player2Score;
            ModelChanged?.Invoke();
        }
    }
}
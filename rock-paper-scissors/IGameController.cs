using System;

namespace rock_paper_scissors
{
  public interface IGameController
  {
    void CalculateScore(Player player1, Player player2, out Player winner);
    GameOption ConvertKeyToGameOption(char key);
    void SetGameOption(Player player);
    bool ValidateKeyPressed(ConsoleKeyInfo keyPressed, out GameOption gameOption);
    bool WonTheGame(GameOption choiceSelected1, GameOption choiceSelected2);
  }
}
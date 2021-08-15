using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace rock_paper_scissors.Tests
{
  [TestClass()]
  public class GameControllerTests
  {
    IGameController gameController = new GameController();

    [TestMethod()]
    public void CalculateScoreTest()
    {
      Player player1 = new Player()
      {
        ChoiceSelected = GameOption.Rock,
        GamesWon = 0
      };

      Player player2 = new Player()
      {
        ChoiceSelected = GameOption.Scissors,
        GamesWon = 0
      };

      gameController.CalculateScore(player1, player2, out Player winner);

      Assert.AreEqual(player1.GamesWon, 1);
      Assert.AreEqual(player2.GamesWon, 0);
    }

    [TestMethod()]
    public void WonTheGameTest()
    {
      bool won = gameController.WonTheGame(GameOption.Scissors, GameOption.Rock);

      Assert.IsFalse(won);
    }

    [TestMethod()]
    public void SetGameOptionTest()
    {
      Player player = new Player()
      {
        AutoSelectGameOption = true
      };

      gameController.SetGameOption(player);

      Assert.IsTrue(player.ChoiceSelected != GameOption.NotSelected);
    }

    [TestMethod()]
    public void ValidateKeyPressedTest()
    {
      ConsoleKeyInfo keyPressed = new ConsoleKeyInfo('R', ConsoleKey.R, false, false, false);

      bool isValidOption = gameController.ValidateKeyPressed(keyPressed, out GameOption gameOption);

      Assert.IsTrue(isValidOption);
    }

    [TestMethod()]
    public void ConvertKeyToGameOptionTest()
    {
      GameOption gameOption = gameController.ConvertKeyToGameOption('S');

      Assert.AreEqual(gameOption, GameOption.Scissors);
    }
  }
}
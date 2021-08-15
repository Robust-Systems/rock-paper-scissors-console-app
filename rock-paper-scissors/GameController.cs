using System;
using System.Linq;

namespace rock_paper_scissors
{
  public class GameController : IGameController
  {
    private Player HumanPlayer;

    private Player RandomComputerPlayer;

    const int NumberOfGamestoPlay = 3;

    private int CurrentGameNumber;

    private readonly Random rnd = new Random();

    public GameController()
    {

    }

    public void PlayGames()
    {
      Initialise();

      while (CurrentGameNumber < NumberOfGamestoPlay)
      {
        PlayGame();

        CurrentGameNumber++;
      }

      DisplayScore();
    }

    private void DisplayScore()
    {
      Console.WriteLine($"{HumanPlayer.Name} won: {HumanPlayer.GamesWon} games.");
      Console.WriteLine($"{RandomComputerPlayer.Name} won: {RandomComputerPlayer.GamesWon} games.");
    }

    private void PlayGame()
    {
      SetGameOption(HumanPlayer);

      SetGameOption(RandomComputerPlayer);

      CalculateScore(HumanPlayer, RandomComputerPlayer, out Player winner);

      if (winner is null)
      {
        Console.WriteLine($"The game was a draw.{Environment.NewLine}");
      }
      else
      {
        Console.WriteLine($"{winner.Name} won the game.{Environment.NewLine}");
      }
    }

    public void CalculateScore(Player player1, Player player2, out Player winner)
    {
      winner = null;

      if (WonTheGame(player1.ChoiceSelected, player2.ChoiceSelected))
      {
        player1.GamesWon++;
        winner = player1;
      }

      if (WonTheGame(player2.ChoiceSelected, player1.ChoiceSelected))
      {
        player2.GamesWon++;
        winner = player2;
      }
    }

    public bool WonTheGame(GameOption choiceSelected1, GameOption choiceSelected2)
    {
      if (choiceSelected1 == GameOption.Rock && choiceSelected2 == GameOption.Scissors)
      {
        return true;
      }
      else if (choiceSelected1 == GameOption.Scissors && choiceSelected2 == GameOption.Paper)
      {
        return true;
      }
      else if (choiceSelected1 == GameOption.Paper && choiceSelected2 == GameOption.Rock)
      {
        return true;
      }

      return false;
    }

    public void SetGameOption(Player player)
    {
      if (player.AutoSelectGameOption)
      {
        player.ChoiceSelected = (GameOption)rnd.Next(1, 3);
        Console.WriteLine($"{Environment.NewLine}{player.Name} selected option: {player.ChoiceSelected}{Environment.NewLine}");
        return;
      }

      Console.WriteLine("Please select an option:");
      Console.WriteLine("[R]ock");
      Console.WriteLine("[P]aper");
      Console.WriteLine("[S]cissors");
      ConsoleKeyInfo keyPressed;

      GameOption optionSelected;
      do
      {
        keyPressed = Console.ReadKey();
        Console.WriteLine();
      } while (!ValidateKeyPressed(keyPressed, out optionSelected));

      player.ChoiceSelected = optionSelected;

      Console.WriteLine($"{player.Name} selected option: {player.ChoiceSelected}");
    }

    public bool ValidateKeyPressed(ConsoleKeyInfo keyPressed, out GameOption gameOption)
    {
      char[] validValues = new char[] { 'R', 'r', 'P', 'p', 'S', 's' };

      if (!validValues.Contains((char)keyPressed.Key))
      {
        gameOption = GameOption.NotSelected;
        return false;
      }

      gameOption = ConvertKeyToGameOption((char)keyPressed.Key);

      return true;
    }

    public GameOption ConvertKeyToGameOption(char key)
    {
      switch (key)
      {
        case 'R':
        case 'r':
          {
            return GameOption.Rock;
          }
        case 'P':
        case 'p':
          {
            return GameOption.Paper;
          }
        case 'S':
        case 's':
          {
            return GameOption.Scissors;
          }
        default:
          return GameOption.NotSelected;
      }
    }

    private void Initialise()
    {
      HumanPlayer = new Player()
      {
        Name = "You",
        ChoiceSelected = GameOption.NotSelected,
        GamesWon = 0
      };

      RandomComputerPlayer = new Player()
      {
        Name = "Random Computer Player",
        ChoiceSelected = GameOption.NotSelected,
        GamesWon = 0,
        AutoSelectGameOption = true
      };

      CurrentGameNumber = 0;
    }
  }
}

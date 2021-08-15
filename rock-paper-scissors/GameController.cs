using System;
using System.Linq;

namespace rock_paper_scissors
{
  class GameController
  {
    private Player HumanPlayer;

    private Player RandomComputerPlayer;

    const int NumberOfGamestoPlay = 3;

    private int CurrentGameNumber;

    private Random rnd = new Random();

    public GameController()
    {
      Initialise();

      PlayGames();
    }

    private void PlayGames()
    {
      while (CurrentGameNumber < NumberOfGamestoPlay)
      {
        PlayGame();
        CurrentGameNumber++;
      }
    }

    private void PlayGame()
    {
      SetGameOption(HumanPlayer);
      SetGameOption(RandomComputerPlayer);
    }

    private void SetGameOption(Player player)
    {
      if (player.AutoSelectGameOption)
      {
        player.ChoiceSelected = (GameOption)rnd.Next(1, 3);
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

      Console.WriteLine($"{Environment.NewLine}Option selected: {optionSelected}{Environment.NewLine}");
    }

    private bool ValidateKeyPressed(ConsoleKeyInfo keyPressed, out GameOption gameOption)
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

    private GameOption ConvertKeyToGameOption(char key)
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

using System;

namespace rock_paper_scissors
{
  class Program
  {
    static void Main(string[] args)
    {
      GameController gameController = new GameController();

      gameController.PlayGames();

      Console.WriteLine($"{Environment.NewLine}The end. Press any key to exit. . .");
      Console.ReadKey();
    }
  }
}

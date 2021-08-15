using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rock_paper_scissors
{
  class Program
  {
    static void Main(string[] args)
    {
      GameController gameController = new GameController();

      gameController.PlayGames();

      Console.WriteLine("The end");
    }
  }
}

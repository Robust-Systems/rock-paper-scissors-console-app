namespace rock_paper_scissors
{
  public class Player
  {
    public string Name { get; set; }

    public GameOption ChoiceSelected { get; set; }

    public int GamesWon { get; set; }

    public bool AutoSelectGameOption { get; set; } = false;
  }
}

namespace Robot.Core.Commands
{
  using System;

  public class LeftCommand : IBoardCommand
  {
    public bool Test(string input)
    {
      return input.Equals("left", StringComparison.InvariantCultureIgnoreCase);
    }

    public string Handle(IBoard board, string command)
    {
      if (board.IsInitialised)
        board.SetDirection(-90);

      return string.Empty;
    }
  }
}
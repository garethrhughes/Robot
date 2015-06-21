namespace Robot.Core.Commands
{
  using System;

  public class RightCommand : IBoardCommand
  {
    public bool Test(string input)
    {
      return input.Equals("right", StringComparison.InvariantCultureIgnoreCase);
    }

    public string Handle(IBoard board, string command)
    {
      if (board.IsInitialised)
        board.SetDirection(90);

      return string.Empty;
    }
  }
}
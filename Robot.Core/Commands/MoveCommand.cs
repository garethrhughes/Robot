namespace Robot.Core.Commands
{
  using System;

  public class MoveCommand : IBoardCommand
  {
    public bool Test(string input)
    {
      return input.Equals("move", StringComparison.InvariantCultureIgnoreCase);
    }

    public string Handle(IBoard board, string command)
    {
      if (board.IsInitialised)
        board.Move();

      return string.Empty;
    }
  }
}
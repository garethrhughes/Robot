namespace Robot.Core.Commands
{
  using System;

  public class ReportCommand : IBoardCommand
  {
    public bool Test(string input)
    {
      return input.Equals("report", StringComparison.InvariantCultureIgnoreCase);
    }

    public string Handle(IBoard board, string command)
    {
      if (board.IsInitialised)
        return string.Format("{0},{1},{2}", board.Position.X, board.Position.Y, directionString(board.Direction));

      return string.Empty;
    }

    private string directionString(int direction)
    {
      switch (direction)
      {
        case 0:
          return "NORTH";
        case 90:
          return "EAST";
        case 180:
          return "SOUTH";
        case 270:
          return "WEST";
        default:
          throw new Exception("Invalid match");
      }
    }
  }
}
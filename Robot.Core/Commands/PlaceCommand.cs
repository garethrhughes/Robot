namespace Robot.Core.Commands
{
  using System;
  using System.Text.RegularExpressions;

  public class PlaceCommand : IBoardCommand
  {
    private readonly Regex _commandRegex = new Regex(@"^place ([0-9]+),([0-9]+),(north|south|east|west){1}$",
      RegexOptions.IgnoreCase);

    public bool Test(string input)
    {
      return _commandRegex.IsMatch(input);
    }

    public string Handle(IBoard board, string command)
    {
      var matches = _commandRegex.Matches(command)[0].Groups;

      var x = int.Parse(matches[1].Value);
      var y = int.Parse(matches[2].Value);
      var direction = parseDirection(matches[3].Value);

      board.Setup(new Position {X = x, Y = y}, direction);

      return string.Empty;
    }

    private int parseDirection(string value)
    {
      switch (value.ToLowerInvariant())
      {
        case "north":
          return 0;
        case "east":
          return 90;
        case "south":
          return 180;
        case "west":
          return 270;

        default:
          throw new Exception("Invalid match");
      }
    }
  }
}
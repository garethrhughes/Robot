namespace Robot.Core
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
  using Commands;

  public class Game
  {
    private readonly Board _board;
    private readonly IEnumerable<IBoardCommand> _commands;

    public Game()
    {
      var type = typeof (IBoardCommand);
      var types = Assembly.GetAssembly(type).GetTypes()
        .Where(x => x.IsClass && type.IsAssignableFrom(x));

      _commands = types.Select(t => Activator.CreateInstance(t) as IBoardCommand);
      _board = new Board();
    }

    public bool CanHandleCommand(string command)
    {
      return _commands.Any(c => c.Test(command));
    }

    public string HandleCommand(string command)
    {
      var handler = _commands.FirstOrDefault(c => c.Test(command));
      return handler != null ? handler.Handle(_board, command) : string.Empty;
    }
  }
}
namespace Robot
{
  using System;
  using Core;

  internal class Program
  {
    private static void Main(string[] args)
    {
      var game = new Game();

      while (true)
      {
        var input = (Console.ReadLine() ?? "").Trim();
        if (!game.CanHandleCommand(input))
        {
          Console.WriteLine("Invalid command, available PLACE X,Y,DIR|LEFT|RIGHT|MOVE|REPORT");
        }
        else
        {
          var result = game.HandleCommand(input);
          if (!string.IsNullOrWhiteSpace(result))
          {
            Console.WriteLine(result);
          }
        }
      }
    }
  }
}
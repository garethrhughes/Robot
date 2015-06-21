namespace Robot.Core.Commands
{
  internal interface IBoardCommand
  {
    bool Test(string input);

    string Handle(IBoard board, string command);
  }
}
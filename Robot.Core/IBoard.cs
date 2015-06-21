namespace Robot.Core
{
  public interface IBoard
  {
    void Setup(Position position, int direction);
    void Move();
    bool IsInitialised { get; }
    int Direction { get; }
    void SetDirection(int directionChange);
    Position Position { get; }
  }
}
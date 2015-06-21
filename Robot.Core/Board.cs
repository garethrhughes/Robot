namespace Robot.Core
{
  using System;

  public class Board : IBoard
  {
    private byte[,] _board;

    private int _direction;

    public Board()
    {
      SetupBoard();
    }

    public bool IsInitialised { get; set; }

    public Position Position
    {
      get
      {
        for (var i = 0; i < _board.GetLength(0); i ++)
        {
          for (var j = 0; j < _board.GetLength(1); j ++)
          {
            if (_board[i, j] == 1)
            {
              return new Position {X = i, Y = j};
            }
          }
        }

        return new Position {X = 0, Y = 0};
      }
    }

    public int Direction
    {
      get { return _direction; }
    }

    public void SetDirection(int directionChange)
    {
      if (!IsInitialised) return;

      _direction += directionChange;

      if (_direction < 0)
      {
        _direction = 270;
      }

      if (_direction == 360)
      {
        _direction = 0;
      }
    }

    public void Move()
    {
      if (!IsInitialised) return;

      switch (_direction)
      {
        case 0:
          MoveNorth();
          break;
        case 90:
          MoveEast();
          break;
        case 180:
          MoveSouth();
          break;
        case 270:
          MoveWest();
          break;

        default:
          throw new Exception("Internal error");
      }
    }

    public void Setup(Position position, int direction)
    {
      if (position.X >= _board.GetLowerBound(0) &&
          position.X <= _board.GetUpperBound(0) &&
          position.Y >= _board.GetLowerBound(1) &&
          position.Y <= _board.GetUpperBound(1))
      {
        SetupBoard();
        IsInitialised = true;
        _direction = direction;
        _board[position.X, position.Y] = 1;
      }
    }

    private void SetupBoard()
    {
      _board = new byte[,]
      {
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0}
      };
    }

    private void MoveWest()
    {
      var currentPosition = Position;

      if (currentPosition.X - 1 >= _board.GetLowerBound(0))
      {
        _board[currentPosition.X, currentPosition.Y] = 0;
        _board[currentPosition.X - 1, currentPosition.Y] = 1;
      }
    }

    private void MoveSouth()
    {
      var currentPosition = Position;

      if (currentPosition.Y - 1 >= _board.GetLowerBound(1))
      {
        _board[currentPosition.X, currentPosition.Y] = 0;
        _board[currentPosition.X, currentPosition.Y - 1] = 1;
      }
    }

    private void MoveEast()
    {
      var currentPosition = Position;

      if (currentPosition.X + 1 <= _board.GetUpperBound(0))
      {
        _board[currentPosition.X, currentPosition.Y] = 0;
        _board[currentPosition.X + 1, currentPosition.Y] = 1;
      }
    }

    private void MoveNorth()
    {
      var currentPosition = Position;

      if (currentPosition.Y + 1 <= _board.GetUpperBound(1))
      {
        _board[currentPosition.X, currentPosition.Y] = 0;
        _board[currentPosition.X, currentPosition.Y + 1] = 1;
      }
    }
  }
}
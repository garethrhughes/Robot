namespace Robot.Core.Tests
{
  using NUnit.Framework;

  [TestFixture]
  public class BoardTest
  {
    [Test]
    public void ShouldCorrectlyHandleDirectionChanges()
    {
      var board = new Board();
      board.Setup(new Position {X = 0, Y = 0}, 0);
      board.SetDirection(-90);
      Assert.That(board.Direction, Is.EqualTo(270));

      board.SetDirection(90);
      Assert.That(board.Direction, Is.EqualTo(0));

      board.SetDirection(90);
      Assert.That(board.Direction, Is.EqualTo(90));

      board.SetDirection(90);
      Assert.That(board.Direction, Is.EqualTo(180));

      board.SetDirection(90);
      Assert.That(board.Direction, Is.EqualTo(270));

      board.SetDirection(90);
      Assert.That(board.Direction, Is.EqualTo(0));
    }

    [Test]
    [TestCase(0, 0, 0, true)]
    [TestCase(2, 3, 90, true)]
    [TestCase(6, 0, 0, false)]
    [TestCase(0, 6, 0, false)]
    public void ShouldCorrectlySetupBoard(int x, int y, int direction, bool initialised)
    {
      var board = new Board();

      board.Setup(new Position {X = x, Y = y}, direction);

      Assert.That(board.IsInitialised, Is.EqualTo(initialised));
      if (initialised)
      {
        Assert.That(board.Position.X, Is.EqualTo(x));
        Assert.That(board.Position.Y, Is.EqualTo(y));
      }
    }

    [Test]
    [TestCase(0, 0, 0, 0, 1)]
    [TestCase(0, 0, 90, 1, 0)]
    [TestCase(0, 1, 180, 0, 0)]
    [TestCase(1, 0, 270, 0, 0)]
    public void ShouldHandleMoveCorrectly(int x, int y, int direction, int expectedX, int expectedY)
    {
      var board = new Board();
      board.Setup(new Position {X = x, Y = y}, direction);

      board.Move();

      Assert.That(board.Position.X, Is.EqualTo(expectedX));
      Assert.That(board.Position.Y, Is.EqualTo(expectedY));
    }
  }
}
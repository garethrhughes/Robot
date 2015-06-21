namespace Robot.Core.Tests
{
  using Commands;
  using FluentAssertions.Common;
  using NSubstitute;
  using NUnit.Framework;

  [TestFixture]
  public class PlaceCommandTest
  {
    [Test]
    [TestCase("PLACE 0,0,NORTH", true)]
    [TestCase("PLACE 0,0,north", true)]
    [TestCase("PLACE 0,0,northsd", false)]
    [TestCase("PLACE 0,0,SOUTH", true)]
    [TestCase("PLACE 0,0,EAST", true)]
    [TestCase("PLACE 0,0,WEST", true)]
    [TestCase("PLACE 9,12,WEST", true)]
    [TestCase("PLACE a,0,WEST", false)]
    [TestCase("PLACE 0,0,W", false)]
    [TestCase("PLACE", false)]
    [TestCase("", false)]
    public void ShouldHandleRequestTests(string input, bool result)
    {
      var command = new PlaceCommand();
      Assert.That(command.Test(input).IsSameOrEqualTo(result));
    }

    [Test]
    [TestCase("PLACE 0,1,WEST", 0, 1, 270)]
    [TestCase("PLACE 1,1,NORTH", 1, 1, 0)]
    [TestCase("PLACE 2,1,EAST", 2, 1, 90)]
    [TestCase("PLACE 1,3,SOUTH", 1, 3, 180)]
    public void ShouldCallSetupOnBoard(string start, int x, int y, int direction)
    {
      var command = new PlaceCommand();
      var board = Substitute.For<IBoard>();

      command.Handle(board, start);

      board.Received().Setup(Arg.Is<Position>(p => p.X == x && p.Y == y), direction);
    }
  }
}
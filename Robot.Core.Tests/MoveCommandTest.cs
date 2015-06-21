namespace Robot.Core.Tests
{
  using Commands;
  using FluentAssertions.Common;
  using NSubstitute;
  using NUnit.Framework;

  [TestFixture]
  public class MoveCommandTest
  {
    [Test]
    [TestCase("MOVE", true)]
    [TestCase("mov", false)]
    [TestCase("", false)]
    public void ShouldHandleRequestTest(string input, bool result)
    {
      var command = new MoveCommand();
      Assert.That(command.Test(input).IsSameOrEqualTo(result));
    }

    [Test]
    public void ShouldCallCorrectCommandOnBoard()
    {
      var command = new MoveCommand(); 
      var board = Substitute.For<IBoard>();
      board.IsInitialised.Returns(true);

      command.Handle(board, "MOVE");

      board.Received().Move();
    }
  }
}
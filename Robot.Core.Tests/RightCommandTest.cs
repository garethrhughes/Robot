
namespace Robot.Core.Tests
{
  using Commands;
  using FluentAssertions.Common;
  using NSubstitute;
  using NUnit.Framework;

  [TestFixture]
  public class RightCommandTest
  {
    [Test]
    [TestCase("RIGHT", true)]
    [TestCase("righ", false)]
    [TestCase("", false)]
    public void ShouldHandleRequestTest(string input, bool result)
    {
      var command = new RightCommand();
      Assert.That(command.Test(input).IsSameOrEqualTo(result));
    }

    [Test]
    public void ShouldCallCorrectDirectionOnBoard()
    {
      var command = new RightCommand(); 
      var board = Substitute.For<IBoard>();
      board.IsInitialised.Returns(true);

      command.Handle(board, "RIGHT");

      board.Received().SetDirection(90);
    }
  }
}
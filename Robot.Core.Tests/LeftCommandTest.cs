namespace Robot.Core.Tests
{
  using Commands;
  using FluentAssertions.Common;
  using NSubstitute;
  using NUnit.Framework;

  [TestFixture]
  public class LeftCommandTest
  {
    [Test]
    [TestCase("LEFT", true)]
    [TestCase("LEF", false)]
    [TestCase("", false)]
    public void ShouldHandleRequestTest(string input, bool result)
    {
      var command = new LeftCommand();
      Assert.That(command.Test(input).IsSameOrEqualTo(result));
    }

    [Test]
    public void ShouldCallCorrectDirectionOnBoard()
    {
      var command = new LeftCommand();
      var board = Substitute.For<IBoard>();
      board.IsInitialised.Returns(true);

      command.Handle(board, "LEFT");

      board.Received().SetDirection(-90);
    }
  }
}
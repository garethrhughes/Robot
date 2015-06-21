namespace Robot.Core.Tests
{
  using Commands;
  using FluentAssertions.Common;
  using NSubstitute;
  using NUnit.Framework;

  [TestFixture]
  public class ReportCommandTest
  {
    [Test]
    [TestCase("REPORT", true)]
    [TestCase("re", false)]
    [TestCase("", false)]
    public void ShouldHandleRequestTest(string input, bool result)
    {
      var command = new ReportCommand();
      Assert.That(command.Test(input).IsSameOrEqualTo(result));
    }

    [Test]
    [TestCase(1, 1, 0, "1,1,NORTH")]
    [TestCase(1, 3, 90, "1,3,EAST")]
    [TestCase(2, 1, 180, "2,1,SOUTH")]
    [TestCase(1, 2, 270, "1,2,WEST")]
    public void ShouldGetCorrectReportOutput(int x, int y, int direction, string output)
    {
      var command = new ReportCommand();
      var board = Substitute.For<IBoard>();
      board.IsInitialised.Returns(true);
      board.Position.Returns(new Position {X = x, Y = y});
      board.Direction.Returns(direction);

      var result = command.Handle(board, "REPORT");

      Assert.That(result, Is.EqualTo(output));
    }
  }
}
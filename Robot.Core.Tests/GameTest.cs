namespace Robot.Core.Tests
{
  using NUnit.Framework;

  [TestFixture]
  public class GameTest
  {
    [Test]
    public void ShouldHandleExample1()
    {
      var tabletop = new Game();
      tabletop.HandleCommand("PLACE 0,0,NORTH");
      tabletop.HandleCommand("MOVE");
      var result = tabletop.HandleCommand("REPORT");

      Assert.That(result, Is.EqualTo("0,1,NORTH"));
    }

    [Test]
    public void ShouldHandleExample2()
    {
      var tabletop = new Game();
      tabletop.HandleCommand("PLACE 0,0,NORTH");
      tabletop.HandleCommand("LEFT");
      var result = tabletop.HandleCommand("REPORT");

      Assert.That(result, Is.EqualTo("0,0,WEST"));
    }

    [Test]
    public void ShouldHandleExample3()
    {
      var tabletop = new Game();
      tabletop.HandleCommand("PLACE 1,2,EAST");
      tabletop.HandleCommand("MOVE");
      tabletop.HandleCommand("MOVE");
      tabletop.HandleCommand("LEFT");
      tabletop.HandleCommand("MOVE");
      var result = tabletop.HandleCommand("REPORT");

      Assert.That(result, Is.EqualTo("3,3,NORTH"));
    }

    [Test]
    [TestCase("PLACE 0,0,NORTH", "0,4,NORTH")]
    [TestCase("PLACE 0,0,SOUTH", "0,0,SOUTH")]
    [TestCase("PLACE 0,0,EAST", "4,0,EAST")]
    [TestCase("PLACE 0,0,WEST", "0,0,WEST")]
    public void ShouldNotGoOutOfBounds(string start, string end)
    {
      var tabletop = new Game();
      tabletop.HandleCommand(start);
      tabletop.HandleCommand("MOVE");
      tabletop.HandleCommand("MOVE");
      tabletop.HandleCommand("MOVE");
      tabletop.HandleCommand("MOVE");
      tabletop.HandleCommand("MOVE");
      var result = tabletop.HandleCommand("REPORT");

      Assert.That(result, Is.EqualTo(end));
    }
  }
}
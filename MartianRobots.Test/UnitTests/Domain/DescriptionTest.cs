using MartianRobots.Abstractions.Help;
using MartianRobots.Domain.Enums;
using MartianRobots.Domain.Models;

namespace MartianRobots.Test.UnitTests.Domain;

[TestFixture]
public class DescriptionTest
{
    [Test]
    public void CheckDescription()
    {
        var robot1 = new Robot(string.Empty, Coordinates.Zero, Direction.North, new List<Instructions>());
        var robot2 = new Robot(string.Empty, Coordinates.Zero, Direction.East, new List<Instructions>());
        var robot3 = new Robot(string.Empty, Coordinates.Zero, Direction.West, new List<Instructions>());
        var robot4 = new Robot(string.Empty, Coordinates.Zero, Direction.South, new List<Instructions>());

        Assert.That("N", Is.EqualTo(robot1.Direction.GetDescription()));
        Assert.That("E", Is.EqualTo(robot2.Direction.GetDescription()));
        Assert.That("W", Is.EqualTo(robot3.Direction.GetDescription()));
        Assert.That("S", Is.EqualTo(robot4.Direction.GetDescription()));
    }
}

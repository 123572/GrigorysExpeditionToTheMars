using MartianRobots.Abstractions.Map;
using MartianRobots.Application.BL.Commands.TurnLeft;
using MartianRobots.Application.BL.Commands.TurnRight;
using MartianRobots.Domain.Enums;
using MartianRobots.Domain.Models;
using Moq;

namespace MartianRobots.Test.UnitTests.Application.Actions;

[TestFixture]
public class TurnLeftCommandHandlerTest
{
    [Test]
    public void RobotHaveToTurnLeft()
    {
        var map = new Mock<IMap>();
        var robot = new Robot(string.Empty, Coordinates.Zero, Direction.North, new List<Instructions>());

        var handler = new TurnLeftCommandHandler();
        handler.Handle(new TurnLeftCommand { Map = map.Object, Robot = robot }, CancellationToken.None);

        map.Verify(mock => mock.TurnLeft(It.IsAny<Direction>()), Times.Once());
    }

    [Test]
    public void IgnoreBecauseLost()
    {
        var map = new Mock<IMap>();

        var robot = new Robot(string.Empty, Coordinates.Zero, Direction.North, new List<Instructions>());
        robot.IsLost = true;

        var handler = new TurnLeftCommandHandler();
        handler.Handle(new TurnLeftCommand { Map = map.Object, Robot = robot }, CancellationToken.None);

        map.Verify(mock => mock.TurnLeft(It.IsAny<Direction>()), Times.Never());
    }
}

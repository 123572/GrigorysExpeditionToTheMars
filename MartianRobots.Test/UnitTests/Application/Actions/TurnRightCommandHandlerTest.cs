using MartianRobots.Abstractions.Map;
using MartianRobots.Application.BL.Commands.TurnRight;
using MartianRobots.Domain.Enums;
using MartianRobots.Domain.Models;
using Moq;

namespace MartianRobots.Test.UnitTests.Application.Actions;

[TestFixture]
public class TurnRightCommandHandlerTest
{
    [Test]
    public void RobotHaveToTurnRight()
    {
        var map = new Mock<IMap>();
        var robot = new Robot(string.Empty, Coordinates.Zero, Direction.North, new List<Instructions>());

        var handler = new TurnRightCommandHandler();
        handler.Handle(new TurnRightCommand { Map = map.Object, Robot = robot }, CancellationToken.None);

        map.Verify(mock => mock.TurnRight(It.IsAny<Direction>()), Times.Once());
    }

    [Test]
    public void IgnoreBecauseLost()
    {
        var map = new Mock<IMap>();

        var robot = new Robot(string.Empty, Coordinates.Zero, Direction.North, new List<Instructions>());
        robot.IsLost = true;

        var handler = new TurnRightCommandHandler();
        handler.Handle(new TurnRightCommand { Map = map.Object, Robot = robot }, CancellationToken.None);

        map.Verify(mock => mock.TurnRight(It.IsAny<Direction>()), Times.Never());
    }
}

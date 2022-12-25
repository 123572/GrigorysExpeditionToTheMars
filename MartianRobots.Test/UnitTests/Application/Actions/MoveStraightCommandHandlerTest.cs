using MartianRobots.Abstractions.Map;
using MartianRobots.Application.BL.Commands.MoveStraight;
using MartianRobots.Domain.Enums;
using MartianRobots.Domain.Models;
using Moq;

namespace MartianRobots.Test.UnitTests.Application.Actions;

[TestFixture]
public class MoveStraightCommandHandlerTest
{
    [Test]
    public void ShouldIgnoreIfRobotIsLost()
    {
        var map = new Mock<IMap>();
        var robot = new Robot(string.Empty, Coordinates.Zero, Direction.North, new List<Instructions>());

        robot.IsLost = true;

        var handler = new MoveStraightCommandHandler();

        handler.Handle(new MoveStraightCommand() { Map = map.Object, Robot = robot}, CancellationToken.None);

        // Assert
        map.Verify(mock => mock.TurnLeft(It.IsAny<Direction>()), Times.Never());
    }

    [Test]
    public void ShouldMoveRobot()
    {
        // Arrange
        var map = new Mock<IMap>();
        var initialPosition = Coordinates.Zero;
        var robot = new Robot(string.Empty, Coordinates.Zero, Direction.North, new List<Instructions>());
        var destination = new Coordinates(0, 1);

        map.Setup(m => m.GetNextCoordinates(It.IsAny<Coordinates>(), It.IsAny<Direction>()))
            .Returns(() => destination);

        map.Setup(m => m.GetAvoidingMarks())
            .Returns(() => new List<Coordinates> { robot.Coordinates } );

        var handler = new MoveStraightCommandHandler();
        handler.Handle(new MoveStraightCommand() { Map = map.Object, Robot = robot }, CancellationToken.None);

        Assert.That(destination, Is.EqualTo(robot.Coordinates));
    }

    [Test]
    public void ShouldMarkLostLandmark()
    {
        // Arrange
        var map = new Mock<IMap>();
        var initialPosition = Coordinates.Zero;
        var robot = new Robot(string.Empty, Coordinates.Zero, Direction.North, new List<Instructions>());
        var destination = new Coordinates(0, 1);

        map.Setup(m => m.GetNextCoordinates(It.IsAny<Coordinates>(), It.IsAny<Direction>()))
            .Returns(() => destination);

        map.Setup(m => m.GetAvoidingMarks())
            .Returns(() => new List<Coordinates> { robot.Coordinates });

        map.Setup(m => m.IsOutOfBounds(It.IsAny<Coordinates>()))
            .Returns(() => true);

        var handler = new MoveStraightCommandHandler();
        handler.Handle(new MoveStraightCommand() { Map = map.Object, Robot = robot }, CancellationToken.None);

        Assert.IsTrue(robot.IsLost);
        map.Verify(mock => mock.AddMark(It.IsAny<Coordinates>(), It.IsAny<Mark>()), Times.Once());
    }
}

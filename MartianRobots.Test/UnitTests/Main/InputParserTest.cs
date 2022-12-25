using MartianRobots.Domain.Enums;
using MartianRobots.Domain.Models;
using MartianRobots.Help;

namespace MartianRobots.Test.UnitTests.Main;

[TestFixture]
public class InputParserTest
{
    [Test]
    public void CheckInputDataParsing()
    {

        var robotInstructionPairs = new Dictionary<string, string>
        {
            { "3 2 N", "FRL" }
        };

        var beginCoords = InputParser.GetBeginCoordinates(robotInstructionPairs.First().Key);

        var instructions = InputParser.GetInstructions(robotInstructionPairs.First().Value);

        Assert.That(beginCoords.Item1.X, Is.EqualTo(3));
        Assert.That(beginCoords.Item1.Y, Is.EqualTo(2));
        Assert.That(beginCoords.Item2, Is.EqualTo(Direction.North));

        Assert.IsTrue(instructions[0] == Instructions.Forward);
        Assert.IsTrue(instructions[1] == Instructions.TurnRight);
        Assert.IsTrue(instructions[2] == Instructions.TurnLeft);
    }
}

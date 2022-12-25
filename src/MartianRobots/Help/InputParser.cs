using MartianRobots.Domain.Enums;
using MartianRobots.Domain.Models;

namespace MartianRobots.Help;

public static class InputParser
{
    public static (Coordinates, Direction) GetBeginCoordinates(string input)
    {
        var inputArr = input.Split(' ');

        var coordinates = new Coordinates(int.Parse(inputArr[0]), int.Parse(inputArr[1]));

        var direction = inputArr[2].ToLower() switch
        {
            "n" => Direction.North,
            "e" => Direction.East,
            "s" => Direction.South,
            "w" => Direction.West,
            _ => throw new NotImplementedException()
        };

        return (coordinates, direction);
    }

    public static List<Instructions> GetInstructions(string input)
    {
        var response = new List<Instructions>();

        foreach (var val in input.ToCharArray())
            response.Add(val switch
            {
                'R' => Instructions.TurnRight,
                'F' => Instructions.Forward,
                'L' => Instructions.TurnLeft,
                _ => throw new NotImplementedException(),
            });

        return response;
    }
}

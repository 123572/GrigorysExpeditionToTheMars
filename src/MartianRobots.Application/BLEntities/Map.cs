using MartianRobots.Abstractions.Map;
using MartianRobots.Domain.Enums;
using MartianRobots.Domain.Models;

namespace MartianRobots.Application.BLEntities;

/// <summary>
/// Map behaviour
/// </summary>
public class Map : IMap
{
    /// <summary>
    /// Top right coordinates
    /// </summary>
    public Coordinates TopRight { get; private set; }

    /// <summary>
    /// Marks with provide special points on map (robot disappear, for example)
    /// </summary>
    private readonly IList<Coordinates> landmarks = new List<Coordinates>();

    public void AddMark(Coordinates coordinates, Mark mark)
    {
        if (!landmarks.Contains(coordinates))
        {
            landmarks.Add(coordinates);
        }
    }

    public List<Coordinates> GetAvoidingMarks()
    {
        return (List<Coordinates>)landmarks;
    }

    public Coordinates GetNextCoordinates(Coordinates coordinates, Direction direction)
    {
        // North is Y+1
        // X axis is from W to E
        // Y axis is from N to S

        var dep = 1;

        var xAmmount = direction == Direction.East || direction == Direction.West ? dep : 0;
        var yAmmount = direction == Direction.North || direction == Direction.South ? dep : 0;

        // South or west are decrement coords
        if (direction == Direction.South)
            yAmmount *= -1;

        if (direction == Direction.West)
            xAmmount *= -1;

        return coordinates + new Coordinates(xAmmount, yAmmount);
    }

    /// <summary>
    /// Returns if coordinates are out of bounds
    /// </summary>
    public bool IsOutOfBounds(Coordinates coordinates)
    {
        if (coordinates.X < coordinates.X || coordinates.X > TopRight.X) return true;
        if (coordinates.Y < coordinates.Y || coordinates.Y > TopRight.Y) return true;
        return false;
    }

    /// <summary>
    /// Configure current map
    /// </summary>
    public void SetupSettings(MapSettings settings)
    {
        TopRight = new Coordinates(settings.Height - 1, settings.Width - 1);
    }

    public Direction TurnLeft(Direction direction)
    {
        return Turn(direction, -1);
    }

    public Direction TurnRight(Direction direction)
    {
        return Turn(direction, 1);
    }

    private Direction Turn(Direction direction, int way)
    {
        // get min and max from possible directions
        var min = (int)Enum.GetValues(typeof(Direction)).Cast<Direction>().Min();
        var max = (int)Enum.GetValues(typeof(Direction)).Cast<Direction>().Max();

        // depending on directon set new direction
        var next = (int)direction + way;
        if (next > max) next = min;
        if (next < min) next = max;

        return (Direction)next;
    }
}

using MartianRobots.Domain.Enums;
using MartianRobots.Domain.Models;

namespace MartianRobots.Abstractions.Map;

public interface IMap
{        
    /// <summary>
    /// Configures the planet map.
    /// </summary>
    public void SetupSettings(MapSettings settings);

    /// <summary>
    /// Adds a mark to the surface.
    /// </summary>
    public void AddMark(Coordinates coordinates, Mark mark);

    /// <summary>
    /// Get surface's avoiding marks
    /// </summary>
    public List<Coordinates> GetAvoidingMarks();

    /// <summary>
    /// Calculate the next coordinates
    /// </summary>
    public Coordinates GetNextCoordinates(Coordinates coordinates, Direction direction);

    /// <summary>
    /// Calculate next direction to left
    /// </summary>
    public Direction TurnLeft(Direction direction);

    /// <summary>
    /// Calculate next direction to right
    /// </summary>
    public Direction TurnRight(Direction direction);

    /// <summary>
    /// Check if out of bounds
    /// </summary>
    public bool IsOutOfBounds(Coordinates coordinates);
}

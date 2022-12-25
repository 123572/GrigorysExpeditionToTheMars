using MartianRobots.Domain.Enums;

namespace MartianRobots.Domain.Models;

public class Robot
{
    /// <summary>
    /// Robot name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Current coordinates
    /// </summary>
    public Coordinates Coordinates { get; set; }

    /// <summary>
    /// Current orientation
    /// </summary>
    public Direction Direction { get; set; }

    /// <summary>
    /// Current instructions
    /// </summary>
    public List<Instructions> Instructions { get; set; }

    /// <summary>
    /// Current robot is lost
    /// </summary>
    public bool IsLost { get; set; }

    /// <summary>
    /// Robot is lost like string
    /// </summary>
    public string IsLostString => IsLost ? "LOST" : string.Empty;

    public Robot(string name, Coordinates coordinates, Direction direction, List<Instructions> instructions)
    {
        Name = name;
        Coordinates = coordinates;
        Direction = direction;
        Instructions = instructions;
    }
}

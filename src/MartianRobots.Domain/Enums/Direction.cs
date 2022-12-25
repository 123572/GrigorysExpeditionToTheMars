using System.ComponentModel;

namespace MartianRobots.Domain.Enums;

public enum Direction
{
    /// <summary>
    /// North
    /// </summary>
    [Description("N")]
    North = 0,

    /// <summary>
    /// East
    /// </summary>
    [Description("E")]
    East = 1,

    /// <summary>
    /// South
    /// </summary>
    [Description("S")]
    South = 2,

    /// <summary>
    /// West
    /// </summary>
    [Description("W")]
    West = 3
}

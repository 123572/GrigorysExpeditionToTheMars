using MartianRobots.Domain.Models;

namespace MartianRobots.Abstractions.Map;

public class MapSettings
{
    /// <summary>
    /// Zero coordinates of the map.
    /// </summary>
    public Coordinates ZeroCoordinates { get; set; }

    /// <summary>
    /// Total height of the map.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Total width of the map.
    /// </summary>
    public int Width { get; set; }
}

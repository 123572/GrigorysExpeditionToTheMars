namespace MartianRobots.Domain.Models;

public class Coordinates : IEquatable<Coordinates>
{
    /// <summary>
    /// Coordinate max limit
    /// </summary>
    public const int Max = 50;

    /// <summary>
    /// Zero coordinates (beginning) 0,0
    /// </summary>
    public static Coordinates Zero => new Coordinates(0, 0);

    /// <summary>
    /// X coordinate.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Y coordinate.
    /// </summary>
    public int Y { get; set; }

    public Coordinates(int x, int y)
    {
        CheckOverlimit(x, nameof(x));
        CheckOverlimit(y, nameof(y));
        X = x;
        Y = y;
    }

    private void CheckOverlimit(int coord, string coordinate)
    {
        if (coord > Max) throw new ArgumentException($"Coordinate {coordinate} is overlimit. Max limit is {Max}");
    }

    /// <summary>
    /// Sum operator
    /// </summary>
    public static Coordinates operator +(Coordinates a, Coordinates b) => new Coordinates(a.X + b.X, a.Y + b.Y);

    /// <summary>
    /// Equals operator
    /// </summary>
    public static bool operator ==(Coordinates a, Coordinates b) => a.Equals(b);

    /// <summary>
    /// Not equals operator
    /// </summary>
    public static bool operator !=(Coordinates a, Coordinates b) => !a.Equals(b);

    /// <summary>
    /// Need to do for better life
    /// </summary>
    public bool Equals(Coordinates coordinates)
    {
        return X.Equals(coordinates.X)
            && Y.Equals(coordinates.Y);
    }

    /// <summary>
    /// Need to do for better life
    /// </summary>
    public override int GetHashCode()
    {
        return X.GetHashCode()
                ^ Y.GetHashCode();
    }

    /// <summary>
    /// Need to do for better life
    /// </summary>
    public override bool Equals(object obj)
    {
        if (obj is Coordinates instance)
            return Equals(instance);
        else
            return false;
    }

    /// <summary>
    /// For string interpolation
    /// </summary>
    public override string ToString()
    {
        return $"{X} {Y}";
    }
}

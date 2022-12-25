namespace MartianRobots.Abstractions.Robot;

public record ActionResult
{
    /// <summary>
    /// Simple communication message
    /// </summary>
    public string Message { get; set; }
}

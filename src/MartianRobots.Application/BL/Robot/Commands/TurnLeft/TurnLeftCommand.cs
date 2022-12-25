using MartianRobots.Abstractions.Map;
using MartianRobots.Abstractions.Robot;
using MartianRobots.Domain.Models;
using MediatR;

namespace MartianRobots.Application.BL.Commands.TurnLeft;

public class TurnLeftCommand : IRequest<ActionResult>
{
    /// <summary>
    /// Concrete robot object
    /// </summary>
    public Robot Robot { get; set; }

    /// <summary>
    /// Concrete map object
    /// </summary>
    public IMap Map { get; set; }
}

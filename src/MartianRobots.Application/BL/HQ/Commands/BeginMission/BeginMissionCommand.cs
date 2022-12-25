using MartianRobots.Abstractions.Map;
using MartianRobots.Abstractions.Robot;
using MartianRobots.Domain.Models;
using MediatR;

namespace MartianRobots.Application.BL.HQ.Commands.BeginMission;

public class BeginMissionCommand : IRequest<ActionResult>
{
    /// <summary>
    /// Communication with Earth
    /// </summary>
    public Action<string> Communicator { get; set; }

    /// <summary>
    /// Map object
    /// </summary>
    public IMap Map { get; set; }

    /// <summary>
    /// List of sended robots
    /// </summary>
    public List<Robot> Robots { get; set; }
}

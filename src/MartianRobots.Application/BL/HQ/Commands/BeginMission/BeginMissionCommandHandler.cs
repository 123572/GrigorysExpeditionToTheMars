using MartianRobots.Abstractions.Help;
using MartianRobots.Abstractions.Map;
using MartianRobots.Abstractions.Robot;
using MartianRobots.Application.BL.Commands.MoveStraight;
using MartianRobots.Application.BL.Commands.TurnLeft;
using MartianRobots.Application.BL.Commands.TurnRight;
using MartianRobots.Domain.Models;
using MediatR;

namespace MartianRobots.Application.BL.HQ.Commands.BeginMission;

public class BeginMissionCommandHandler : IRequestHandler<BeginMissionCommand, ActionResult>
{

    private const string startMessage = "Robot's movement have begun";
    private const string separator = "================================================";
    private const string finishMessage = "Mission has completed!";
    private const string movementMessage = "Robot {0} beginning movement";


    private readonly IMediator _mediatr;

    private Action<string> _communicator;

    private IMap _map;

    private List<Robot> _robots;


    public BeginMissionCommandHandler(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    public async Task<ActionResult> Handle(BeginMissionCommand request, CancellationToken cancellationToken)
    {
        setup(request);

        ActionResult robotActioinResult = new ActionResult { Message = startMessage };
        _communicator(robotActioinResult.Message);

        foreach (var robot in _robots)
        {

            _communicator(separator);
            _communicator(string.Format(movementMessage, robot.Name));

            foreach (var instruction in robot.Instructions)
            {
                robotActioinResult = instruction switch
                {
                    Domain.Enums.Instructions.Forward => await _mediatr.Send(new MoveStraightCommand { Map = _map, Robot = robot }),
                    Domain.Enums.Instructions.TurnLeft => await _mediatr.Send(new TurnLeftCommand { Map = _map, Robot = robot }),
                    Domain.Enums.Instructions.TurnRight => await _mediatr.Send(new TurnRightCommand { Map = _map, Robot = robot }),
                    _ => throw new NotImplementedException()
                };

                // sending message to The Earth
                _communicator(robotActioinResult.Message);

            }   
        }

        _communicator(separator);
        foreach (var robot in _robots) _communicator($"{robot.Coordinates} {robot.Direction.GetDescription()} {robot.IsLostString}");
        _communicator(separator);

        return new ActionResult { Message = finishMessage };
    }

    private void setup(BeginMissionCommand request)
    {
        _map = request.Map;
        _robots = request.Robots;
        _communicator = request.Communicator;
    }
}

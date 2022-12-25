using MartianRobots.Abstractions.Robot;
using MediatR;

namespace MartianRobots.Application.BL.Commands.TurnLeft;

public class TurnLeftCommandHandler : IRequestHandler<TurnLeftCommand, ActionResult>
{

    private const string okResultMessage = "Robot turned left";
    private const string errResultMessage = "Robot has lost";

    public Task<ActionResult> Handle(TurnLeftCommand command, CancellationToken cancellationToken)
    {

        if(command.Robot.IsLost) return Task.FromResult(new ActionResult { Message = errResultMessage });

        command.Robot.Direction = command.Map.TurnLeft(command.Robot.Direction);

        return Task.FromResult(new ActionResult { Message = okResultMessage });

    }
}

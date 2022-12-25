using MartianRobots.Abstractions.Robot;
using MediatR;

namespace MartianRobots.Application.BL.Commands.TurnRight;

public class TurnRightCommandHandler : IRequestHandler<TurnRightCommand, ActionResult>
{

    private const string resultMessage = "Robot turned right";
    private const string errResultMessage = "Robot has lost";

    public Task<ActionResult> Handle(TurnRightCommand command, CancellationToken cancellationToken)
    {

        if (command.Robot.IsLost) return Task.FromResult(new ActionResult { Message = errResultMessage });

        command.Robot.Direction = command.Map.TurnRight(command.Robot.Direction);

        return Task.FromResult(new ActionResult { Message = resultMessage });

    }
}

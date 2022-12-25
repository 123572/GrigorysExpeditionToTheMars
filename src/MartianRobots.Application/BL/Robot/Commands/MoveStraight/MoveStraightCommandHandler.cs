using MartianRobots.Abstractions.Robot;
using MediatR;

namespace MartianRobots.Application.BL.Commands.MoveStraight;

public class MoveStraightCommandHandler : IRequestHandler<MoveStraightCommand, ActionResult>
{

    private const string lostMessage = "Robot is lost";
    private const string avoidMessage = "Lost cell has avoided";
    private const string finishMessage = "Forward movement has completed";

    public Task<ActionResult> Handle(MoveStraightCommand command, CancellationToken cancellationToken)
    {

        if (command.Robot.IsLost) return Task.FromResult(new ActionResult { Message = lostMessage });

        var nextPosition = command.Map.GetNextCoordinates(command.Robot.Coordinates, command.Robot.Direction);

        var avoidingMarks = command.Map.GetAvoidingMarks();

        var nextIsLost = avoidingMarks != null
                && avoidingMarks.Any(m => m == nextPosition);

        if (nextIsLost) 
            return Task.FromResult(new ActionResult() { Message = avoidMessage });

        if (command.Map.IsOutOfBounds(nextPosition))
        {
            // Next position is out of bounds and robot will be lost
            command.Map.AddMark(nextPosition, Domain.Enums.Mark.Avoid);

            command.Robot.IsLost = true;
        }
        else
        {
            command.Robot.Coordinates = nextPosition;
        }

        return Task.FromResult(new ActionResult { Message = finishMessage });

    }
}

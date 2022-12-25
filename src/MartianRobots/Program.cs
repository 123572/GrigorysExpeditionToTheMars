using MartianRobots.Abstractions.Map;
using MartianRobots.Application.BL.HQ.Commands.BeginMission;
using MartianRobots.Application.BLEntities;
using MartianRobots.Domain.Models;
using MartianRobots.Help;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

const string APPLICATION_MODULE_NAME = "MartianRobots.Application";
var applicationAssembly = AppDomain.CurrentDomain.Load(APPLICATION_MODULE_NAME);

var serviceCollection = new ServiceCollection()
    .AddMediatR(applicationAssembly)
    .BuildServiceProvider();

var mediator = serviceCollection.GetRequiredService<IMediator>();

const int marsHeight = 6;
const int marsWidth = 4;

var mapSettings = new MapSettings { Height = marsHeight, Width = marsWidth, ZeroCoordinates = Coordinates.Zero };

var marsMap = new Map();
marsMap.SetupSettings(mapSettings);

var robotInstructionPairs = new Dictionary<string, string> {
    { "1 1 E", "RFRFRFRF" },
    { "3 2 N", "FRRFLLFFRRFLL" },
    { "0 3 W", "LLFFFLFLFL" }
};

var robots = new List<Robot>();

foreach (var inputData in robotInstructionPairs)
{
    var beginCoords = InputParser.GetBeginCoordinates(inputData.Key);
    var instructions = InputParser.GetInstructions(inputData.Value);

    robots.Add(new Robot(Guid.NewGuid().ToString(), beginCoords.Item1, beginCoords.Item2, instructions));
}

//launch mission
var result = await mediator.Send(new BeginMissionCommand() { Map = marsMap, Robots = robots, Communicator = (string message) => Console.WriteLine(message) });

Console.WriteLine(result.Message);
Console.ReadKey();
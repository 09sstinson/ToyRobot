using Microsoft.Extensions.DependencyInjection;
using ToyRobot.IO;
using ToyRobot.Models;
using ToyRobot.Services;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IInputGetter, ConsoleInputGetter>()
    .AddSingleton<IOutputWriter, ConsoleWriter>()
    .AddSingleton<IBoard, Board>()
    .AddSingleton<IRobot, Robot>()
    .AddSingleton<CommandExecutor>()
    .AddSingleton<GameRunner>()
    .AddSingleton<InputParser>()
    .BuildServiceProvider();

serviceProvider.GetService<GameRunner>().Run();

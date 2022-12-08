using ToyRobot.Exceptions;
using ToyRobot.Models;

namespace ToyRobot.IO
{
    public class InputParser
    {
        public Command ParseInput(string input)
        {
            input = input.Trim();

            if (input.StartsWith("PLACE", StringComparison.InvariantCultureIgnoreCase))
            {
                return ParsePlaceCommand(input);
            }

            return input.ToUpperInvariant() switch
            {
                "MOVE" => new Command() { Type = CommandType.Move },
                "REPORT" => new Command() { Type = CommandType.Report },
                "LEFT" => new Command() { Type = CommandType.Left },
                "RIGHT" => new Command() { Type = CommandType.Right },
                _ => throw new UnrecognisedCommandException(),
            };
        }

        private static Command ParsePlaceCommand(string input)
        {
            var inputComponents = GetInputComponents(input);

            var xCoordinate = ParseInt(inputComponents[1]);
            var yCoordinate = ParseInt(inputComponents[2]);

            return new Command()
            {
                Type = CommandType.Place,
                Arguments = new CommandArguments(new Position(xCoordinate, yCoordinate), ParseDirection(inputComponents[3]))
            };
        }

        private static string[] GetInputComponents(string input)
        {
            var commandComponents = input
                .Replace(',', ' ')
                .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (commandComponents.Length != 4)
            {
                throw new UnrecognisedCommandException();
            }

            return commandComponents;
        }

        private static int ParseInt(string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch
            {
                throw new ParsingException(input, typeof(int));
            }
        }

        private static Direction ParseDirection(string input)
        {
            try
            {
                return (Direction)Enum.Parse(typeof(Direction), input.ToUpperInvariant());
            }
            catch
            {
                throw new ParsingException(input, typeof(Direction));
            }
        }
    }
}

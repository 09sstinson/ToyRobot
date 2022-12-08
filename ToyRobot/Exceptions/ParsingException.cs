namespace ToyRobot.Exceptions
{
    public class ParsingException : ToyRobotException
    {
        public ParsingException(string input, Type type) : base($"Unable to parse {input} as {type.Name}.")
        {
        }
    }
}

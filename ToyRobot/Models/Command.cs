namespace ToyRobot.Models
{
    public class Command
    {
        public CommandType Type { get; set; }

        public CommandArguments Arguments { get; set; }
    }

    public record CommandArguments(Position Position, Direction Direction) { }

    public enum CommandType
    {
        Move,
        Right,
        Left,
        Report,
        Place
    }
}

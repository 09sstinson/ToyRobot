namespace ToyRobot.Exceptions
{
    public class UnrecognisedCommandException : ToyRobotException
    {
        public UnrecognisedCommandException() : base("Command not recognised.")
        {
        }
    }
}

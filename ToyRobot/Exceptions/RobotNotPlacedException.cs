namespace ToyRobot.Exceptions
{
    public class RobotNotPlacedException : ToyRobotException
    {
        public RobotNotPlacedException() : base("You must place the robot on the board before executing other commands.")
        {
        }
    }
}

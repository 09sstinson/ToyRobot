namespace ToyRobot.Exceptions
{
    public class OutsideOfBoardException : ToyRobotException
    {
        public OutsideOfBoardException() : base("That is not allowed since it would cause the robot to fall off the board.")
        {
        }
    }
}

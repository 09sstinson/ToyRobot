namespace ToyRobot.IO
{
    public class ConsoleInputGetter : IInputGetter
    {
        public string GetNextInput()
        {
            return Console.ReadLine();
        }
    }
}

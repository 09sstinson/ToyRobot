using ToyRobot.IO;
internal class ConsoleWriter : IOutputWriter
{
    public void WriteOutput(string output)
    {
        Console.WriteLine(output);
    }
}
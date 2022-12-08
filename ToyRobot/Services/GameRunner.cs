using System;
using System.Collections.Generic;
using System.Linq;
using ToyRobot.Exceptions;
using ToyRobot.IO;

namespace ToyRobot.Services
{
    public class GameRunner
    {

        private readonly CommandExecutor _gameManager;
        private readonly InputParser _inputParser;
        private readonly IInputGetter _inputGetter;
        private readonly IOutputWriter _outputWriter;
        public GameRunner(CommandExecutor gameManager, InputParser inputParser, IInputGetter inputGetter, IOutputWriter outputWriter)
        {
            _gameManager = gameManager;
            _inputParser = inputParser;
            _inputGetter = inputGetter;
            _outputWriter = outputWriter;
        }

        public void Run()
        {
            while (true)
            {
                PerformGameLoop();
            }
        }

        public void PerformGameLoop()
        {
            try
            {
                var input = _inputGetter.GetNextInput();

                if(input == null || input.Trim() == string.Empty)
                {
                    return;
                }

                var command = _inputParser.ParseInput(input);

                _gameManager.ExecuteCommand(command);
            }
            catch (ToyRobotException ex)
            {
                _outputWriter.WriteOutput(ex.Message);
            }
            catch
            {
                _outputWriter.WriteOutput("Something went wrong, please try again");
            }
        }
    }
}

using ToyRobot.Exceptions;
using ToyRobot.IO;
using ToyRobot.Models;

namespace ToyRobot.Services
{
    public class CommandExecutor
    {
        public readonly IRobot _robot;
        public readonly IBoard _board;
        private readonly IOutputWriter _outputWriter;

        public CommandExecutor(IOutputWriter outputWriter, IRobot robot, IBoard board)
        {
            _outputWriter = outputWriter;
            _robot = robot;
            _board = board;
        }

        public void ExecuteCommand(Command command)
        {
            if (_robot.Position is null && command.Type != CommandType.Place)
            {
                throw new RobotNotPlacedException();
            }

            switch (command.Type)
            {
                case CommandType.Move:
                    ExecuteMoveCommand();
                    break;
                case CommandType.Right:
                    _robot.Rotate(clockwise: true);
                    break;
                case CommandType.Left:
                    _robot.Rotate(clockwise: false);
                    break;
                case CommandType.Report:
                    _outputWriter.WriteOutput($"{_robot.Position.X}, {_robot.Position.Y}, {_robot.Direction}");
                    break;
                case CommandType.Place:
                    ExecutePlaceCommand(command);
                    break;
                default: throw new UnrecognisedCommandException();
            }
        }

        private void ExecuteMoveCommand()
        {
            var positionAfterMove = _robot.GetPositionAfterMove();

            if (_board.IsOnBoard(positionAfterMove))
            {
                _robot.Move();
            }
            else
            {
                throw new OutsideOfBoardException();
            }
        }

        private void ExecutePlaceCommand(Command command)
        {
            if (!_board.IsOnBoard(command?.Arguments?.Position))
            {
                throw new OutsideOfBoardException();
            }

            _robot.Place(command.Arguments.Direction, command.Arguments.Position);
        }
    }
}

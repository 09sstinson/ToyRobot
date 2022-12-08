using Moq;
using ToyRobot.Exceptions;
using ToyRobot.IO;
using ToyRobot.Models;
using ToyRobot.Services;

namespace ToyRobot.UnitTests
{
    public class CommandExecutorTests
    {
        private readonly Mock<IOutputWriter> _outputWriter = new();
        private readonly Mock<IRobot> _robot = new();
        private readonly Mock<IBoard> _board = new();
        private readonly Position _startingPosition = new(0,0);
        private readonly CommandExecutor _sut;

        public CommandExecutorTests()
        {
            _sut = new CommandExecutor(_outputWriter.Object, _robot.Object, _board.Object);
        }

        [Fact]
        public void ThrowsNotPlacedExceptionWhenRobotNotPlaced()
        {
            _robot.Setup(x => x.Position).Returns((Position)null).Verifiable();

            Assert.Throws<RobotNotPlacedException>(() => _sut.ExecuteCommand(new Command()));

            VerifyOnlySetup();
        }

        [Fact]
        public void ExecutesCommandWhenOnBoard()
        {
            _robot.SetupGet(x => x.Position).Returns(_startingPosition).Verifiable();
            _robot.Setup(x => x.Rotate(false)).Verifiable();

            _sut.ExecuteCommand(new Command() { Type = CommandType.Left });

            VerifyOnlySetup();
        }

        private void VerifyOnlySetup()
        {
            Mock.Verify(_robot);
            Mock.Verify(_board);
            _robot.VerifyNoOtherCalls();
            _board.VerifyNoOtherCalls();
        }
    }
}

using Moq;
using ToyRobot.IO;
using ToyRobot.Services;
using ToyRobot.Models;

namespace ToyRobot.IntegrationTests
{
    public class GameRunnerTests {

        private readonly Mock<IOutputWriter> _outputWriter = new();
        private readonly CommandExecutor _gameManager;
        private readonly List<string> _outputCapture = new();

        public GameRunnerTests()
        {
            _gameManager = new CommandExecutor(_outputWriter.Object, new Robot(), new Board());
            _outputWriter.Setup(h => h.WriteOutput(Capture.In(_outputCapture)));
        }

        [Fact]  
        public void PlacesCorrectly()
        {
            var inputs = new List<string>()
            {
                "place 1,2,north",
                "report",
            };

            var sut = GetSut(inputs);

            inputs.ForEach(x => sut.PerformGameLoop());

            Assert.Single(_outputCapture);
            Assert.Equal("1, 2, NORTH", _outputCapture.Single());
        }

        [Fact]
        public void WritesHelpfulMessageWhenNotPlaced()
        {
            var inputs = new List<string>()
            {
                "move",
            };

            var sut = GetSut(inputs);

            inputs.ForEach(x => sut.PerformGameLoop());

            Assert.Single(_outputCapture);
            Assert.Equal("You must place the robot on the board before executing other commands.", _outputCapture.Single());
        }

        [Fact]
        public void WritesHelpfulMessageWhenCannotParseInt()
        {
            var inputs = new List<string>()
            {
                "place 1,test,North",
            };

            var sut = GetSut(inputs);

            inputs.ForEach(x => sut.PerformGameLoop());

            Assert.Single(_outputCapture);
            Assert.Equal("Unable to parse test as Int32.", _outputCapture.Single());
        }

        [Fact]
        public void WritesHelpfulMessageWhenParseCommandHasExtraParameters()
        {
            var inputs = new List<string>()
            {
                "place 1,test,North, random extra stuff",
            };

            var sut = GetSut(inputs);

            inputs.ForEach(x => sut.PerformGameLoop());

            Assert.Single(_outputCapture);
            Assert.Equal("Command not recognised.", _outputCapture.Single());
        }

        [Fact]
        public void WritesHelpfulMessageWhenDoesntRecogniseCommand()
        {
            var inputs = new List<string>()
            {
                "notarealcommand",
            };

            var sut = GetSut(inputs);

            inputs.ForEach(x => sut.PerformGameLoop());

            Assert.Single(_outputCapture);
            Assert.Equal("Command not recognised.", _outputCapture.Single());
        }

        [Fact]
        public void WritesHelpfulErrorWhenPlacingOutsideBoard()
        {
            var inputs = new List<string>()
            {
                "place 6,6,north",
            };

            var sut = GetSut(inputs);

            inputs.ForEach(x => sut.PerformGameLoop());

            Assert.Single(_outputCapture);
            Assert.Equal("That is not allowed since it would cause the robot to fall off the board.", _outputCapture.Single());
        }

        [Fact]
        public void WritesHelpfulMessageWhenTryingToMoveOffBoard()
        {
            var inputs = new List<string>()
            {
                "place 4,4,north",
                "move",
            };

            var sut = GetSut(inputs);

            inputs.ForEach(x => sut.PerformGameLoop());

            Assert.Single(_outputCapture);
            Assert.Equal("That is not allowed since it would cause the robot to fall off the board.", _outputCapture.Single());
        }

        [Fact]
        public void MovesCorrectly()
        {
            var inputs = new List<string>()
            {
                "place 1,2,north",
                "move",
                "report",
            };

            var sut = GetSut(inputs);

            inputs.ForEach(x => sut.PerformGameLoop());

            Assert.Single(_outputCapture);
            Assert.Equal("1, 3, NORTH", _outputCapture.Single());
        }

        [Fact]
        public void HandlesMultipleReportsCorrectly()
        {
            var inputs = new List<string>()
            {
                "place 1,2,north",
                "move",
                "report",
                "right",
                "report"
            };

            var sut = GetSut(inputs);

            inputs.ForEach(x => sut.PerformGameLoop());

            Assert.Equal(2, _outputCapture.Count);
            Assert.Equal(new List<string>() { "1, 3, NORTH", "1, 3, EAST" }, _outputCapture);
        }

        [Fact]
        public void HandlesMultipleOperationsCorrectly()
        {
            var inputs = new List<string>()
            {
                "place 1,2,north",
                "move",
                "move",
                "right",
                "move",
                "report",
                "place 2,2,south",
                "move",
                "report",
            };

            var sut = GetSut(inputs);

            inputs.ForEach(x => sut.PerformGameLoop());

            Assert.Equal(2, _outputCapture.Count);
            Assert.Equal(new List<string>() { "2, 4, EAST", "2, 1, SOUTH" }, _outputCapture);
        }

        private GameRunner GetSut(List<string> inputs)
        {
            return new GameRunner(_gameManager, new InputParser(), new InputGetterFake(inputs.GetEnumerator()), _outputWriter.Object);
        }
    }

    public class InputGetterFake : IInputGetter
    {
        private readonly IEnumerator<string> _inputs;
        public InputGetterFake(IEnumerator<string> inputs) {
            _inputs = inputs;
        }
        public string GetNextInput()
        {
            _inputs.MoveNext();
            return _inputs.Current;
        }
    }
}
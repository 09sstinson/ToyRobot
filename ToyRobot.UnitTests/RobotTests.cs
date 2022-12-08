using ToyRobot.Models;
using Xunit.Abstractions;

namespace ToyRobot.UnitTests
{
    public class RobotTests
    {
        private readonly Position _startingPosition = new(2, 4);
        private readonly Robot _sut = new();

        [Fact]
        public void MovesForwardCorrectly()
        {
            _sut.Place(Direction.WEST, _startingPosition);
            _sut.Move();

            Assert.Equal(new Position(1, 4), _sut.Position);
            Assert.Equal(Direction.WEST, _sut.Direction);
        }

        [Fact]
        public void GetsCorrectPositionAfterMove()
        {
            _sut.Place(Direction.EAST, _startingPosition);
            var positionAfterMove = _sut.GetPositionAfterMove();

            Assert.Equal(new Position(3, 4), positionAfterMove);
        }

        [Theory]
        [InlineData(Direction.NORTH, Direction.EAST)]
        [InlineData(Direction.EAST, Direction.SOUTH)]
        [InlineData(Direction.SOUTH, Direction.WEST)]
        [InlineData(Direction.WEST, Direction.NORTH)]
        public void RotatesClockwiseCorrectly(Direction startDirection, Direction endDirection)
        {
            _sut.Place(startDirection, _startingPosition);
            _sut.Rotate(clockwise: true);

            Assert.Equal(_startingPosition, _sut.Position);
            Assert.Equal(endDirection, _sut.Direction);
        }

        [Theory]
        [InlineData(Direction.NORTH, Direction.WEST)]
        [InlineData(Direction.EAST, Direction.NORTH)]
        [InlineData(Direction.SOUTH, Direction.EAST)]
        [InlineData(Direction.WEST, Direction.SOUTH)]
        public void RotatesAntiClockwiseCorrectly(Direction startDirection, Direction endDirection)
        {
            _sut.Place(startDirection, _startingPosition);
            _sut.Rotate(clockwise: false);

            Assert.Equal(_startingPosition, _sut.Position);
            Assert.Equal(endDirection, _sut.Direction);
        }
    }
}
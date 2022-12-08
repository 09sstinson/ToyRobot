using ToyRobot.Models;

namespace ToyRobot.UnitTests
{
    public class BoardTests
    {
        private readonly Board _sut = new();

        [Theory, MemberData(nameof(PositionsOnBoard))]
        public void ReturnsTrueWhenPositionIsOnBoard(Position position)
        {
            var isOnBoard = _sut.IsOnBoard(position);

            Assert.True(isOnBoard);
        }

        [Theory, MemberData(nameof(PositionsOffBoard))]
        public void ReturnsFalseWhenPositionIsOffBoard(Position position)
        {
            var isOnBoard = _sut.IsOnBoard(position);

            Assert.False(isOnBoard);
        }

        public static IEnumerable<object[]> PositionsOnBoard =>
        new List<object[]>
        {
                new object[] { new Position(2,4)},
                new object[] { new Position(0,0)},
        };

        public static IEnumerable<object[]> PositionsOffBoard =>
        new List<object[]>
        {
                new object[] { new Position(1,5)},
                new object[] { new Position(5,6)},
                new object[] { new Position(-1,-1)},
        };
    }
}
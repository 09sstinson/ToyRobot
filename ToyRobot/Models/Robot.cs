namespace ToyRobot.Models
{
    public class Robot : IRobot
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }

        public void Rotate(bool clockwise)
        {
            Direction = Direction switch
            {
                Direction.NORTH => clockwise ? Direction.EAST : Direction.WEST,
                Direction.EAST => clockwise ? Direction.SOUTH : Direction.NORTH,
                Direction.SOUTH => clockwise ? Direction.WEST : Direction.EAST,
                Direction.WEST => clockwise ? Direction.NORTH : Direction.SOUTH,
                _ => throw new ArgumentException(nameof(Direction)),
            };
        }

        public Position GetPositionAfterMove()
        {

            return Direction switch
            {
                Direction.NORTH => Position with { Y = Position.Y + 1 },
                Direction.EAST => Position with { X = Position.X + 1 },
                Direction.SOUTH => Position with { Y = Position.Y - 1 },
                Direction.WEST => Position with { X = Position.X - 1 },
                _ => throw new ArgumentException(nameof(Direction)),
            };
        }

        public void Move()
        {
            Position = GetPositionAfterMove();
        }

        public void Place(Direction direction, Position position)
        {
            Direction = direction;
            Position = position;
        }
    }
}

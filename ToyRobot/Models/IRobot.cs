namespace ToyRobot.Models
{
    public interface IRobot
    {
        Direction Direction { get; }
        Position Position { get; }
        Position GetPositionAfterMove();
        void Move();
        void Place(Direction direction, Position position);
        void Rotate(bool clockwise);
    }
}
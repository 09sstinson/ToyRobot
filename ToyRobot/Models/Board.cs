namespace ToyRobot.Models
{
    public class Board : IBoard
    {
        private const int _size = 5;

        public bool IsOnBoard(Position position)
        {
            if (position == null)
            {
                return false;
            }

            return position.X < _size && position.X >= 0 && position.Y < _size && position.Y >= 0;
        }
    }
}

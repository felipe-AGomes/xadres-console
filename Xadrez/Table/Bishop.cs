using Table.Enums;

namespace Table
{
    internal class Bishop : Piece
    {
        public Bishop(Colors color, int x, int y) : base('B', color, x, y)
        {
        }

        public override bool[,] PossibleMovements(Board board)
        {
            throw new NotImplementedException();
        }
    }
}

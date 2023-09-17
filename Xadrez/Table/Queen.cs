using Table.Enums;

namespace Table
{
    internal class Queen : Piece
    {
        public Queen(Colors color, int x, int y) : base('Q', color, x, y)
        {
        }

        public override bool[,] PossibleMovements(Board board)
        {
            throw new NotImplementedException();
        }
    }
}

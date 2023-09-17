using Table.Enums;

namespace Table
{
    internal class Rook : Piece
    {
        public Rook(Colors color, int x, int y) : base('T', color, x, y)
        {
        }

        public override bool[,] PossibleMovements(Board board)
        {
            throw new NotImplementedException();
        }
    }
}

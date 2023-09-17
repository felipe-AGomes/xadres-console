using Table.Enums;

namespace Table
{
    internal class Knight : Piece
    {
        public Knight(Colors color, int x, int y) : base('C', color, x, y)
        {
        }

        public override bool[,] PossibleMovements(Board board)
        {
            throw new NotImplementedException();
        }
    }
}

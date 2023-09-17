using Table.Enums;

namespace Table
{
    internal class Pawn : Piece
    {
        public Pawn(Colors color, int x, int y) : base('P', color, x, y)
        {
        }

        public override bool[,] PossibleMovements(Board board)
        {
            throw new NotImplementedException();
        }
    }
}

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
            bool[,] possibleMovements = new bool[board.Columns, board.Rows];
            Position newPosition;
            if (Color == Colors.White)
            {
                // top
                newPosition = new Position { X = Position.X, Y = Position.Y - 1 };
                if (CanMove(board, newPosition))
                {
                    possibleMovements[newPosition.Y, newPosition.X] = true;
                }
            }
            else
            {
                // bottom
                newPosition = new Position { X = Position.X, Y = Position.Y + 1 };
                if (CanMove(board, newPosition))
                {
                    possibleMovements[newPosition.Y, newPosition.X] = true;
                }
            }
            return possibleMovements;
        }
    }
}

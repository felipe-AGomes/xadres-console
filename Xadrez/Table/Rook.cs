using Table.Enums;

namespace Table
{
    internal class Rook : Piece
    {
        public Rook(Colors color, int x, int y) : base('T', color, x, y)
        {
        }

        private bool CanMove(Board board, Position newPosition)
        {
            return board.SelectPiece(newPosition.X, newPosition.Y) == null || board.SelectPiece(newPosition.X, newPosition.Y).Color != Color;
        }

        public override bool[,] PossibleMovements(Board board)
        {
            bool[,] possibleMovements = new bool[board.Columns, board.Rows];
            Position newPosition;
            // right
            newPosition = new Position { X = Position.X + 1, Y = Position.Y };
            while (newPosition.X < board.Columns)
            {
                if (CanMove(board, newPosition))
                {
                    possibleMovements[newPosition.Y, newPosition.X] = true;
                }
                newPosition.X++;
            }
            // bottom
            newPosition = new Position { X = Position.X, Y = Position.Y + 1 };
            while (newPosition.Y < board.Rows)
            {
                if (CanMove(board, newPosition))
                {
                    possibleMovements[newPosition.Y, newPosition.X] = true;
                }
                newPosition.Y++;
            }
            // left
            newPosition = new Position { X = Position.X - 1, Y = Position.Y };
            while (newPosition.X >= 0)
            {
                if (CanMove(board, newPosition))
                {
                    possibleMovements[newPosition.Y, newPosition.X] = true;
                }
                newPosition.X--;
            }
            // top
            newPosition = new Position { X = Position.X, Y = Position.Y - 1 };
            while (newPosition.Y >= 0)
            {
                if (CanMove(board, newPosition))
                {
                    possibleMovements[newPosition.Y, newPosition.X] = true;
                }
                newPosition.Y--;
            }
            return possibleMovements;
        }
    }
}

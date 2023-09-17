using Table.Enums;

namespace Table
{
    internal class King : Piece
    {
        public King(Colors color, int x, int y) : base('K', color, x, y)
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
            if (CanMove(board, newPosition))
            {
                possibleMovements[newPosition.Y, newPosition.X] = true;
            }
            // bottom-right
            newPosition = new Position { X = Position.X + 1, Y = Position.Y + 1 };
            if (CanMove(board, newPosition))
            {
                possibleMovements[newPosition.Y, newPosition.X] = true;
            }
            // bottom
            newPosition = new Position { X = Position.X, Y = Position.Y + 1 };
            if (CanMove(board, newPosition))
            {
                possibleMovements[newPosition.Y, newPosition.X] = true;
            }
            // bottom-left
            newPosition = new Position { X = Position.X - 1, Y = Position.Y + 1 };
            if (CanMove(board, newPosition))
            {
                possibleMovements[newPosition.Y, newPosition.X] = true;
            }
            // left
            newPosition = new Position { X = Position.X - 1, Y = Position.Y };
            if (CanMove(board, newPosition))
            {
                possibleMovements[newPosition.Y, newPosition.X] = true;
            }
            // left-top
            newPosition = new Position { X = Position.X - 1, Y = Position.Y - 1 };
            if (CanMove(board, newPosition))
            {
                possibleMovements[newPosition.Y, newPosition.X] = true;
            }
            // top
            newPosition = new Position { X = Position.X, Y = Position.Y - 1 };
            if (CanMove(board, newPosition))
            {
                possibleMovements[newPosition.Y, newPosition.X] = true;
            }
            // top-right
            newPosition = new Position { X = Position.X + 1, Y = Position.Y - 1 };
            if (CanMove(board, newPosition))
            {
                possibleMovements[newPosition.Y, newPosition.X] = true;
            }
            return possibleMovements;
        }
    }
}

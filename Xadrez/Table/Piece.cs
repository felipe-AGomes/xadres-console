using System.Drawing;
using Table.Enums;

namespace Table
{
    internal abstract class Piece
    {
        public char Name { get; }
        public Position Position { get; set; }
        public Colors Color {  get; private set; }
        public Piece(char name, Colors color, int x, int y)
        {
            Position = new Position(x, y);
            Color = color;
            Name = name;
        }

        protected bool CanMove(Board board, Position newPosition)
        {
            return board.SelectPiece(newPosition.X, newPosition.Y) == null || board.SelectPiece(newPosition.X, newPosition.Y).Color != Color;
        }

        public abstract bool[,] PossibleMovements(Board board);
    }
}

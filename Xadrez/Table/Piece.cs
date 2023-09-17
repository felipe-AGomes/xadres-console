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

        public abstract bool[,] PossibleMovements(Board board);
    }
}

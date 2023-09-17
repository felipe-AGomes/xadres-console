using Logic;
using System.Data.Common;
using Table.Enums;

namespace Table
{
    internal class Board
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        private Piece[,] Table { get; set; }
        public GameController Chess { get; set; }
        public bool[,] PossibleMoviments { get; private set; }

        public Board(GameController chess, int rows, int columns)
        {
            Table = new Piece[rows, columns];
            Chess = chess;
            Columns = columns;
            Rows = rows;
            PossibleMoviments = new bool[rows, columns];
        }

        public void AddPiece(Piece piece)
        {
            Table[piece.Position.Y, piece.Position.X] = piece;
        }

        public Piece RemovePiece(int column, int row)
        {
            Piece removedPiece = Table[row, column];
            removedPiece.Position = null;
            Table[row, column] = null;
            return removedPiece;
        }

        public Piece RemovePiece(Position position)
        {
            Piece removedPiece = Table[position.Y, position.X];

            Table[position.Y, position.X] = null;
            return removedPiece;
        }

        public Piece SelectPiece(int column, int row)
        {
            return Table[row, column];
        }

        public Piece SelectPiece(Position position)
        {
            return Table[position.Y, position.X];
        }

        public bool HasPiece(int column, int row)
        {
            if (SelectPiece(column, row) != null)
            {
                return true;
            }
            return false;
        }

        public bool HasPiece(Position position)
        {
            if (SelectPiece(position) != null)
            {
                return true;
            }
            return false;
        }

        public bool IsPossibleToMove(Position position)
        {
            return PossibleMoviments[position.Y, position.X];
        }

        public Piece MovePiece(Position origin, Position destiny)
        {
            if (!HasPiece(origin) || !IsPossibleToMove(destiny))
            {
                return null;
            }
            Piece removedPiece = null;
            if (HasPiece(destiny))
            {
                removedPiece = RemovePiece(destiny);
            }

            Piece piece = RemovePiece(origin);
            piece.Position = destiny;
            AddPiece(piece);
            return removedPiece;
        }

        public void AddPossibleMovements(bool[,] possibleMoviments)
        {
            PossibleMoviments = possibleMoviments;
        }

        public void ResetPossibleMovements()
        {
            PossibleMoviments = new bool[Rows, Columns];
        }

        public King SelectKing(Colors Player)
        {
            foreach (Piece piece in Table)
            {
                if (piece is King && piece.Color == Player)
                {
                    return (King)piece;
                }
            }
            return null;
        }

        public bool[,] AllPossibleMovementsTo(Colors Player)
        {
            bool[,] allPossiblemovements = new bool[Rows, Columns];

            foreach (Piece piece in Table)
            {
                if (piece != null)
                {
                    bool[,] possivleMovements = piece.PossibleMovements(this);

                    for (int y = 0; y < Rows; y++)
                    {
                        for (int x = 0; x < Columns; x++)
                        {
                            if (!allPossiblemovements[y, x] && possivleMovements[y, x])
                            {
                                allPossiblemovements[y, x] = true;
                            }
                        }
                    }
                }
            }
            return allPossiblemovements;
        }
    }
}

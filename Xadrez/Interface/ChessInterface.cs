using Table;
using Table.Enums;

namespace Interface
{
    internal static class ChessInterface
    {
        public static void DrawBoard(Board board)
        {
            Console.Clear();
            for (int row = 0; row < board.Rows; row++)
            {
                Console.Write($"{board.Rows - row} |");
                for (int column = 0; column < board.Columns; column++)
                {
                    Position position = new Position { X = column, Y = row};
                    if (board.HasPiece(position))
                    {
                        Piece selectedPiece = board.SelectPiece(position);
                        DrawPiece(board, selectedPiece);
                    }
                    else
                    {
                        DrawEmptyPosition(board, position);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("   ------------------------");
            Console.WriteLine("    A  B  C  D  E  F  G  H");
            Console.WriteLine();
        }

        public static void DrawCapturedPieces(List<Piece> capturedPieces)
        {
            List<Piece> whitePieces = new();
            List<Piece> blackPieces = new();
            foreach (Piece piece in capturedPieces)
            {
                if (piece.Color == Colors.White)
                {
                    whitePieces.Add(piece);
                }
                else
                {
                    blackPieces.Add(piece);
                }
            }
            Console.Write("White Pieces Captured: ");
            CapturedPieces(whitePieces);
            Console.Write("Black Pieces Captured: ");
            CapturedPieces(blackPieces);
            Console.WriteLine();
        }

        private static void CapturedPieces(List<Piece> pieces)
        {
            Console.Write("[ ");

            foreach (Piece piece in pieces)
            {
                Console.Write("" + piece.Name);
            }

            Console.Write(" ]\n");
        }

        private static void DrawEmptyPosition(Board board, Position position)
        {
            ConsoleColor defaultFontColor = Console.ForegroundColor;
            if (board.IsPossibleToMove(position))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("[-]");
                Console.ForegroundColor = defaultFontColor;
            }
            else
            {
                Console.Write(" - ");
            }
        }

        private static void DrawPiece(Board board, Piece piece)
        {
            if (piece.Color == Colors.White)
            {
                WhitePiece(board, piece);
            }
            else
            {
                BlackPiece(board, piece);
            }
        }

        private static void WhitePiece(Board board, Piece piece)
        {
            ConsoleColor defaultBackgroudColor = Console.BackgroundColor;
            if (board.IsPossibleToMove(piece.Position))
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Write($" {piece.Name} ");
                Console.BackgroundColor = defaultBackgroudColor;
            }
            else
            {
                Console.Write($" {piece.Name} ");
            }
        }

        private static void BlackPiece(Board board, Piece piece)
        {
            ConsoleColor defaultFontColor = Console.ForegroundColor;
            ConsoleColor defaultBackgroudColor = Console.BackgroundColor;
            if (board.IsPossibleToMove(piece.Position))
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" {piece.Name} ");
                Console.BackgroundColor = defaultBackgroudColor;
                Console.ForegroundColor = defaultFontColor;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" {piece.Name} ");
                Console.ForegroundColor = defaultFontColor;
            }
        }

        public static void OriginRequest(Colors playerMove)
        {
            Console.WriteLine("Vez do jogador: " + playerMove);
            Console.Write("Origem (Ex: 3/D): ");
        }

        public static void DestinyRequest(Colors playerMove)
        {
            Console.WriteLine("Vez do jogador: " + playerMove);
            Console.Write("Destino (Ex: 3/D): ");
        }

        public static Position PositionRequest()
        {
            string[] pieceResponse = Console.ReadLine().Split("/");
            int x = char.Parse(pieceResponse[1]) - 'A';
            int y = 8 - int.Parse(pieceResponse[0]);
            return new Position(x, y);
        }
    }

}

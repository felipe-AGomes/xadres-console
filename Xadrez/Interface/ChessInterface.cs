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
                    ConsoleColor defaultFontColor = Console.ForegroundColor;
                    ConsoleColor defaultBackgroudColor = Console.BackgroundColor;
                    if (board.HasPiece(column, row))
                    {
                        Piece selectedPiece = board.SelectPiece(column, row);
                        if (selectedPiece.Color == Colors.White)
                        {
                            if (board.IsPossibleToMove(new Position { X = column, Y = row }))
                            {
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                Console.Write($" {selectedPiece.Name} ");
                                Console.BackgroundColor = defaultBackgroudColor;
                            }
                            else
                            {
                                Console.Write($" {selectedPiece.Name} ");
                            }
                        }
                        else
                        {
                            if (board.IsPossibleToMove(new Position { X = column, Y = row }))
                            {
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($" {selectedPiece.Name} ");
                                Console.BackgroundColor = defaultBackgroudColor;
                                Console.ForegroundColor = defaultFontColor;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($" {selectedPiece.Name} ");
                                Console.ForegroundColor = defaultFontColor;
                            }
                        }
                    }
                    else
                    {
                        if (board.IsPossibleToMove(new Position { X = column, Y = row }))
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
                }
                Console.WriteLine();
            }
            Console.WriteLine("   ------------------------");
            Console.WriteLine("    A  B  C  D  E  F  G  H");
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

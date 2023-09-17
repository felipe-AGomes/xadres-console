using Interface;
using Table;
using Table.Enums;

namespace Logic
{
    internal class GameController
    {
        protected Board Board { get; private set; }
        protected bool EndGame { get; private set; } = false;
        public Colors PlayerMove { get; private set; } = Colors.White;
        public List<Piece> CapturedPieces = new();

        public GameController()
        {
            Board = new(this, 8, 8);
        }

        public void StartGame()
        {
            OrganizePawn();
            OrganizeBackrow();
            DrawTable();
            while (!EndGame)
            {
                NextPlayer();
            }

        }

        private void OrganizePawn()
        {
            Board.AddPiece(new King(Colors.Black, 3, 1));
            Board.AddPiece(new Rook(Colors.White, 5, 3));

            /*
                for (int row = 1; row < Board.Rows; row += Board.Rows - 3)
                {
                    for (int column = 0; column < Board.Columns; column++)
                    {
                        if (row == 1)
                        {
                            Board.AddPiece(new Pawn(Colors.Black, column, row));
                        }
                        else
                        {
                            Board.AddPiece(new Pawn(Colors.White, column, row));
                        }
                    }
                }
             */
        }

        private void OrganizeBackrow()
        {
            /*
                for (int row = 0; row < Board.Rows; row += Board.Rows - 1)
                {
                    if (row == 0)
                    {
                        Board.AddPiece(new Rook(Colors.Black, 0, row));
                        Board.AddPiece(new Knight(Colors.Black, 1, row));
                        Board.AddPiece(new Bishop(Colors.Black, 2, row));
                        Board.AddPiece(new Queen(Colors.Black, 3, row));
                        Board.AddPiece(new King(Colors.Black, 4, row));
                        Board.AddPiece(new Bishop(Colors.Black, 5, row));
                        Board.AddPiece(new Knight(Colors.Black, 6, row));
                        Board.AddPiece(new Rook(Colors.Black, 7, row));
                    }
                    else
                    {
                        Board.AddPiece(new Rook(Colors.White, 0, row));
                        Board.AddPiece(new Knight(Colors.White, 1, row));
                        Board.AddPiece(new Bishop(Colors.White, 2, row));
                        Board.AddPiece(new King(Colors.White, 4, row));
                        Board.AddPiece(new Queen(Colors.White, 3, row));
                        Board.AddPiece(new Bishop(Colors.White, 5, row));
                        Board.AddPiece(new Knight(Colors.White, 6, row));
                        Board.AddPiece(new Rook(Colors.White, 7, row));
                    }
                }
             */
        }

        private void NextPlayer()
        {
            Position origin = OriginRequest();
            Piece piece = Board.SelectPiece(origin);
            Board.AddPossibleMovements(piece.PossibleMovements(Board));

            DrawTable();

            Position destiny = DestinyRequest();

            Piece? removedPiece = MovePiece(origin, destiny);

            if (removedPiece != null)
            {
                AddRemovedPiece(removedPiece);
            }

            DrawTable();

            /*
                if (KingInCheck(Board.SelectKing(OpostPlayer())))
                {

                    ChessInterface.ShowCkeck(OpostPlayer());
                }

             */
            ChangePlayer();
        }

        private bool KingInCheck(King king)
        {
            bool[,] allPossibleMovements = Board.AllPossibleMovementsTo(PlayerMove);
            for (int y = 0; y < allPossibleMovements.GetLength(0); y++)
            {
                for (int x = 0; x < allPossibleMovements.GetLength(1); x++)
                {
                    if (x == king.Position.X && y == king.Position.Y && allPossibleMovements[y, x])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void ChangePlayer()
        {
            PlayerMove = OpostPlayer();
        }

        private Colors OpostPlayer()
        {
            return PlayerMove == Colors.White ? Colors.Black : Colors.White;
        }

        private void AddRemovedPiece(Piece piece)
        {

            CapturedPieces.Add(piece);
        }

        private void DrawTable()
        {
            ChessInterface.DrawBoard(Board);
            ChessInterface.DrawCapturedPieces(CapturedPieces);
        }

        private Position DestinyRequest()
        {
            Position destiny;
            do
            {
                ChessInterface.DestinyRequest(PlayerMove);
                destiny = ChessInterface.PositionRequest();
                Console.WriteLine(CanMoveDestiny(destiny));
            } while (!CanMoveDestiny(destiny));
            Console.WriteLine("TESTE");
            return destiny;
        }

        private Position OriginRequest()
        {
            Position origin;
            do
            {
                ChessInterface.OriginRequest(PlayerMove);
                origin = ChessInterface.PositionRequest();
            } while (CanMoveOrigin(origin));
            return origin;
        }

        private Piece? MovePiece(Position origin, Position destiny)
        {
            Piece removedPiece = Board.MovePiece(origin, destiny);
            Board.ResetPossibleMovements();
            return removedPiece;
        }

        private bool CanMoveOrigin(Position origin)
        {
            return !Board.HasPiece(origin) || Board.SelectPiece(origin).Color != PlayerMove;
        }

        private bool CanMoveDestiny(Position destiny)
        {
            if (Board.IsPossibleToMove(destiny))
            {
                return !(Board.HasPiece(destiny) && Board.SelectPiece(destiny).Color == PlayerMove);
            }
            return false;
        }
    }
}

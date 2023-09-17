﻿using Interface;
using Table;
using Table.Enums;

namespace Logic
{
    internal class GameController
    {
        protected Board Board { get; private set; }
        protected bool EndGame { get; private set; } = false;
        public Colors PlayerMove { get; private set; } = Colors.White;

        public GameController()
        {
            Board = new(this, 8, 8);
        }

        public void StartGame()
        {
            OrganizePawn();
            OrganizeBackrow();
            ChessInterface.DrawBoard(Board);
            while (!EndGame)
            {
                NextPlayer();
            }

        }

        private void OrganizePawn()
        {
            Board.AddPiece(new King(Colors.White, 3, 3));
            Board.AddPiece(new King(Colors.White, 2, 2));
            Board.AddPiece(new King(Colors.Black, 4, 4));
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
            ChessInterface.DrawBoard(Board);

            Position destiny = DestinyRequest();
            Piece removedPiece = MovePiece(origin, destiny);
            ChessInterface.DrawBoard(Board);

            if (removedPiece != null)
            {
                // provisório
                Console.WriteLine("Comeu um");
            }

            PlayerMove = PlayerMove == Colors.White ? Colors.Black : Colors.White;
        }

        private Position DestinyRequest()
        {
            Position destiny;
            do
            {
                ChessInterface.DestinyRequest(PlayerMove);
                destiny = ChessInterface.PositionRequest();
                Console.WriteLine(CanMoveOrigin(destiny));
            } while (CanMoveDestiny(destiny));
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

        private Piece MovePiece(Position origin, Position destiny)
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
            return !Board.HasPiece(destiny) || (Board.SelectPiece(destiny) is Piece && Board.SelectPiece(destiny).Color == PlayerMove);
        }
    }
}
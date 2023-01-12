using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class King: Piece
    {
        bool HasMoved { get; set; } = false;
        bool CanKingCastle { get; set; } = false;
        Game Game { get; set; }
        public King(Square square, Color color, Board board, Game game) : base(square, color, board) 
        {
            PieceType = PieceType.King;
            Game = game;
        }
        public override void Move(Square CurrentSquare, Square DestinationSquare, Piece AttackedPiece, List<Piece> Captured)
        {
            HasMoved = true;
            if (Math.Abs(CurrentSquare.Position.File - DestinationSquare.Position.File) > 1)
            {
                Castle(CurrentSquare, DestinationSquare);
            }
            else
            {
                if (AttackedPiece != null)
                {
                    Captured.Add(AttackedPiece);
                    this.Square = DestinationSquare;
                    DestinationSquare.Piece = this;
                    CurrentSquare.Piece = null;
                }
                else
                {
                    this.Square = DestinationSquare;
                    DestinationSquare.Piece = this;
                    CurrentSquare.Piece = null;
                }
            }
        }
        public override void CalcPossibleMoves()
        {
            List<PieceLocation> possiblemoves = new List<PieceLocation>();
            List<PieceLocation> possiblediagonalmoves = DiagonalMove();
            foreach (var move in possiblediagonalmoves)
            {
                possiblemoves.Add(move);
            }
            List<PieceLocation> possibleverticalmoves = VerticalMove();
            foreach (var move in possibleverticalmoves)
            {
                possiblemoves.Add(move);
            }
            List<PieceLocation> possiblehorizontalmoves = HorizontalMove();
            foreach (var move in possiblehorizontalmoves)
            {
                possiblemoves.Add(move);
            }
            //Needs implementation
            List<PieceLocation> castlemoves = CanCastle();
            foreach (var move in castlemoves)
            {
                possiblemoves.Add(move);
            }

            //This checks if a king move puts the king into check and if so, removes that move from possible moves
            for (int i = possiblemoves.Count - 1; i >= 0; i--)
                {
                Square MoveSquare = Board.BoardArray[possiblemoves[i].Rank, possiblemoves[i].File];
                if (MoveSquare.Attacked)
                {
                    possiblemoves.RemoveAt(i);
                }
            }
            this.PossibleMoves = possiblemoves;
        }
        public override char GetAlgNotation()
        {
            return 'K';
        }
        //Castling rules: King hasn't moved, rook hasn't moved, king not in check, king doesn't pass through check, and no pieces between king and rook
        public List<PieceLocation> CanCastle()
        {
            List<PieceLocation> possiblemoves = new List<PieceLocation>();
            if (Game.Check)
            {
                return possiblemoves;
            }
            if (!HasMoved)
            {
                if (this.Color == Color.White)
                {
                    //White Castle Kingside
                    if (this.Board.BoardArray[0, 7].Piece != null)
                    {
                        if (this.Board.BoardArray[0, 7].Piece.PieceType == PieceType.Rook)
                        {
                            Rook rook = (Rook)this.Board.BoardArray[0, 7].Piece;
                            if (!rook.HasMoved)
                            {
                                if (!this.Board.BoardArray[0, 5].IsPiece() & !this.Board.BoardArray[0, 6].IsPiece())
                                {
                                    if (!this.Board.BoardArray[0, 5].Attacked & !this.Board.BoardArray[0, 6].Attacked)
                                    {
                                        PieceLocation kingsideCastle = new PieceLocation(0, 6);
                                        possiblemoves.Add(kingsideCastle);
                                    }
                                }

                            }
                        }
                    }
                    //White Castle Queenside
                    if (this.Board.BoardArray[0, 0].Piece != null)
                    {
                        if (this.Board.BoardArray[0, 0].Piece.PieceType == PieceType.Rook)
                        {
                            Rook rook = (Rook)this.Board.BoardArray[0, 0].Piece;
                            if (!rook.HasMoved)
                            {
                                if (!this.Board.BoardArray[0, 1].IsPiece() & !this.Board.BoardArray[0, 2].IsPiece() & !this.Board.BoardArray[0, 3].IsPiece())
                                {
                                    if (!this.Board.BoardArray[0, 2].Attacked & !this.Board.BoardArray[0, 3].Attacked)
                                    {
                                        PieceLocation kingsideCastle = new PieceLocation(0, 2);
                                        possiblemoves.Add(kingsideCastle);
                                    }
                                }

                            }
                        }
                    }
                }
                else
                {
                    //Black Castle Kingside
                    if (this.Board.BoardArray[7, 7].Piece != null)
                    {
                        if (this.Board.BoardArray[7, 7].Piece.PieceType == PieceType.Rook)
                        {
                            Rook rook = (Rook)this.Board.BoardArray[7, 7].Piece;
                            if (!rook.HasMoved)
                            {
                                if (!this.Board.BoardArray[7, 5].IsPiece() & !this.Board.BoardArray[7, 6].IsPiece())
                                {
                                    if (!this.Board.BoardArray[7, 5].Attacked & !this.Board.BoardArray[7, 6].Attacked)
                                    {
                                        PieceLocation kingsideCastle = new PieceLocation(7, 6);
                                        possiblemoves.Add(kingsideCastle);
                                    }
                                }
                            }
                        }
                    }
                    //Black Castle Queenside
                    if (this.Board.BoardArray[7, 0].Piece != null)
                    {
                        if (this.Board.BoardArray[7, 0].Piece.PieceType == PieceType.Rook)
                        {
                            Rook rook = (Rook)this.Board.BoardArray[7, 0].Piece;
                            if (!rook.HasMoved)
                            {
                                if (!this.Board.BoardArray[7, 1].IsPiece() & !this.Board.BoardArray[7, 2].IsPiece() & !this.Board.BoardArray[7, 3].IsPiece())
                                {
                                    if (!this.Board.BoardArray[7, 2].Attacked & !this.Board.BoardArray[7, 3].Attacked)
                                    {
                                        PieceLocation kingsideCastle = new PieceLocation(7, 2);
                                        possiblemoves.Add(kingsideCastle);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return possiblemoves;
        }

        public void Castle(Square CurrentSquare, Square DestinationSquare)
        {
            King King = (King)CurrentSquare.Piece;
            if (King.Color == Color.White)
            {
                if (DestinationSquare.Position.File == 6)
                {
                    King.Square = DestinationSquare;
                    DestinationSquare.Piece = King;
                    CurrentSquare.Piece = null;

                    Piece Rook = this.Board.BoardArray[0,7].Piece;
                    Square RookDestinationSquare = this.Board.BoardArray[0, 5];
                    Rook.Square = RookDestinationSquare;
                    RookDestinationSquare.Piece = Rook;
                    this.Board.BoardArray[0, 7].Piece = null;
                }
                else if (DestinationSquare.Position.File == 2)
                {
                    King.Square = DestinationSquare;
                    DestinationSquare.Piece = King;
                    CurrentSquare.Piece = null;

                    Piece Rook = this.Board.BoardArray[0, 0].Piece;
                    Square RookDestinationSquare = this.Board.BoardArray[0, 3];
                    Rook.Square = RookDestinationSquare;
                    RookDestinationSquare.Piece = Rook;
                    this.Board.BoardArray[0, 0].Piece = null;
                }
            }
            else
            {
                if (DestinationSquare.Position.File == 6)
                {
                    King.Square = DestinationSquare;
                    DestinationSquare.Piece = King;
                    CurrentSquare.Piece = null;

                    Piece Rook = this.Board.BoardArray[7, 7].Piece;
                    Square RookDestinationSquare = this.Board.BoardArray[7, 5];
                    Rook.Square = RookDestinationSquare;
                    RookDestinationSquare.Piece = Rook;
                    this.Board.BoardArray[7, 7].Piece = null;
                }
                else if (DestinationSquare.Position.File == 2)
                {
                    King.Square = DestinationSquare;
                    DestinationSquare.Piece = King;
                    CurrentSquare.Piece = null;

                    Piece Rook = this.Board.BoardArray[7, 0].Piece;
                    Square RookDestinationSquare = this.Board.BoardArray[7, 3];
                    Rook.Square = RookDestinationSquare;
                    RookDestinationSquare.Piece = Rook;
                    this.Board.BoardArray[7, 0].Piece = null;
                }
            }
        }

        private List<PieceLocation> DiagonalMove()
        {
            List<PieceLocation> possiblemoves = new List<PieceLocation>();
            int rank = Square.Position.Rank;
            int file = Square.Position.File;

            PieceLocation upright = new PieceLocation(rank + 1, file + 1);
            if (upright.Rank <= 7 & upright.File <= 7)
            {
                if (Board.BoardArray[upright.Rank, upright.File].IsPiece())
                {
                    if (Board.BoardArray[upright.Rank, upright.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(upright);
                    }
                }
                else
                {
                    possiblemoves.Add(upright);
                }
            }
            PieceLocation upleft = new PieceLocation(rank + 1, file - 1);
            if (upleft.Rank <= 7 & upleft.File >= 0)
            {
                if (Board.BoardArray[upleft.Rank, upleft.File].IsPiece())
                {
                    if (Board.BoardArray[upleft.Rank, upleft.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(upleft);
                    }
                }
                else
                {
                    possiblemoves.Add(upleft);
                }
            }
            PieceLocation downright = new PieceLocation(rank - 1, file + 1 );
            if (downright.Rank >= 0 & downright.File <= 7)
            {
                if (Board.BoardArray[downright.Rank, downright.File].IsPiece())
                {
                    if (Board.BoardArray[downright.Rank, downright.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(downright);
                    }
                }
                else
                {
                    possiblemoves.Add(downright);
                }
            }
            PieceLocation downleft = new PieceLocation( rank - 1, file - 1 );
            if (downleft.Rank >= 0 & downleft.File >= 0)
            {
                if (Board.BoardArray[downleft.Rank, downleft.File].IsPiece())
                {
                    if (Board.BoardArray[downleft.Rank, downleft.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(downleft);
                    }
                }
                else
                {
                    possiblemoves.Add(downleft);
                }
            }
            return possiblemoves;
        }

        private List<PieceLocation> HorizontalMove()
        {
            List<PieceLocation> possiblemoves = new List<PieceLocation>();
            int rank = Square.Position.Rank;
            int file = Square.Position.File;

            PieceLocation right = new PieceLocation( rank, file + 1 );
            if (right.File <= 7)
            {
                if (Board.BoardArray[right.Rank, right.File].IsPiece())
                {
                    if (Board.BoardArray[right.Rank, right.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(right);
                    }
                }
                else
                {
                    possiblemoves.Add(right);
                }
            }
            PieceLocation left = new PieceLocation( rank, file - 1 );
            if (left.File >= 0)
            {
                if (Board.BoardArray[left.Rank, left.File].IsPiece())
                {
                    if (Board.BoardArray[left.Rank, left.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(left);
                    }
                }
                else
                {
                    possiblemoves.Add(left);
                }
            }
            return possiblemoves;
        }
        public List<PieceLocation> VerticalMove()
        {
            List<PieceLocation> possiblemoves = new List<PieceLocation>();
            int rank = Square.Position.Rank;
            int file = Square.Position.File;

            PieceLocation up = new PieceLocation(rank + 1, file);
            if (up.Rank <= 7)
            {
                if (Board.BoardArray[up.Rank, up.File].IsPiece())
                {
                    if (Board.BoardArray[up.Rank, up.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(up);
                    }
                }
                else
                {
                    possiblemoves.Add(up);
                }
            }
            PieceLocation down = new PieceLocation( rank-1, file );
            if (down.Rank >= 0)
            {
                if (Board.BoardArray[down.Rank, down.File].IsPiece())
                {
                    if (Board.BoardArray[down.Rank, down.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(down);
                    }
                }
                else
                {
                    possiblemoves.Add(down);
                }
            }
            return possiblemoves;
        }
    }
}
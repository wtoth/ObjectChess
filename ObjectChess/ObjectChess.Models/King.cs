using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class King: Piece
    {
        public King(Square square, Color color, Board board) : base(square, color, board) 
        {
            PieceType = PieceType.King;
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
            //List<List<int>> possiblecastle = CanCastle();
            //foreach (var move in possiblecastle)
            //{
            //    possiblemoves.Add(move);
            //}
            this.PossibleMoves = possiblemoves;
        }
        public override char GetAlgNotation()
        {
            return 'K';
        }
        public List<List<int>> CanCastle()
        {
            throw new System.NotImplementedException();
        }

        public void Castle()
        {
            throw new System.NotImplementedException();
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

        public void IsCheck()
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class Knight : Piece
    {
        public Knight(Square square, Color color, Board board) : base(square, color, board) 
        {
            PieceType = PieceType.Knight;
        }
        public override void Move()
        {
            throw new System.NotImplementedException();
        }
        public override void CalcPossibleMoves()
        {
            List<PieceLocation> possiblemoves = new List<PieceLocation>();
            List<PieceLocation> possibleknightmoves = KnightMove();
            foreach (var move in possibleknightmoves)
            {
                possiblemoves.Add(move);
            }
            this.PossibleMoves = possiblemoves;
        }
        public override char GetAlgNotation()
        {
            return 'N';
        }
        private List<PieceLocation> KnightMove()
        {
            List<PieceLocation> possiblemoves = new List<PieceLocation>();
            int rank = Square.Position.Rank;    
            int file = Square.Position.File;

            PieceLocation twouponeright = new PieceLocation( rank + 2, file + 1 ); 
            if (twouponeright.Rank <= 7 & twouponeright.File <= 7)
            {
                if (Board.BoardArray[twouponeright.Rank, twouponeright.File].IsPiece())
                {
                    if (Board.BoardArray[twouponeright.Rank, twouponeright.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(twouponeright);
                    }
                }
                else
                {
                    possiblemoves.Add(twouponeright);
                }
            }
            PieceLocation twouponeleft = new PieceLocation( rank + 2, file - 1 );
            if (twouponeleft.Rank <= 7 & twouponeleft.File >= 0)
            {
                if (Board.BoardArray[twouponeleft.Rank, twouponeleft.File].IsPiece())
                {
                    if (Board.BoardArray[twouponeleft.Rank, twouponeleft.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(twouponeleft);
                    }
                }
                else
                {
                    possiblemoves.Add(twouponeleft);
                }
            }
            PieceLocation twodownoneright = new PieceLocation(rank - 2, file + 1);
            if (twodownoneright.Rank >= 0 & twodownoneright.File <= 7)
            {
                if (Board.BoardArray[twodownoneright.Rank, twodownoneright.File].IsPiece())
                {
                    if (Board.BoardArray[twodownoneright.Rank, twodownoneright.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(twodownoneright);
                    }
                }
                else
                {
                    possiblemoves.Add(twodownoneright);
                }
            }
            PieceLocation twodownoneleft = new PieceLocation(rank - 2, file - 1);
            if (twodownoneleft.Rank >= 0 & twodownoneleft.File >= 0)
            {
                if (Board.BoardArray[twodownoneleft.Rank, twodownoneleft.File].IsPiece())
                {
                    if (Board.BoardArray[twodownoneleft.Rank, twodownoneleft.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(twodownoneleft);
                    }
                }
                else
                {
                    possiblemoves.Add(twodownoneleft);
                }
            }
            PieceLocation oneuptworight = new PieceLocation (rank + 1, file + 2);
            if (oneuptworight.Rank <= 7 & oneuptworight.File <= 7)
            {
                if (Board.BoardArray[oneuptworight.Rank, oneuptworight.File].IsPiece())
                {
                    if (Board.BoardArray[oneuptworight.Rank, oneuptworight.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(oneuptworight);
                    }
                }
                else
                {
                    possiblemoves.Add(oneuptworight);
                }

            }
            PieceLocation onedowntworight = new PieceLocation (rank - 1, file + 2);
            if (onedowntworight.Rank >= 0 & onedowntworight.File <= 7)
            {
                if (Board.BoardArray[onedowntworight.Rank, onedowntworight.File].IsPiece())
                {
                    if (Board.BoardArray[onedowntworight.Rank, onedowntworight.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(onedowntworight);
                    }
                }
                else
                {
                    possiblemoves.Add(onedowntworight);
                }
            }
            PieceLocation oneuptwoleft = new PieceLocation (rank + 1, file - 2);
            if (oneuptwoleft.Rank <= 7 & oneuptwoleft.File >= 0)
            {
                if (Board.BoardArray[oneuptwoleft.Rank, oneuptwoleft.File].IsPiece())
                {
                    if (Board.BoardArray[oneuptwoleft.Rank, oneuptwoleft.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(oneuptwoleft);
                    }
                }
                else
                {
                    possiblemoves.Add(oneuptwoleft);
                }
            }
            PieceLocation onedowntwoleft = new PieceLocation (rank - 1, file - 2);
            if (onedowntwoleft.Rank >= 0 & onedowntwoleft.File >= 0)
            {
                if (Board.BoardArray[onedowntwoleft.Rank, onedowntwoleft.File].IsPiece())
                {
                    if (Board.BoardArray[onedowntwoleft.Rank, onedowntwoleft.File].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(onedowntwoleft);
                    }
                }
                else
                {
                    possiblemoves.Add(onedowntwoleft);
                }
            }
            return possiblemoves;
        }
    }
}
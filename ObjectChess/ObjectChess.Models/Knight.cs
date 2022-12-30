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
            List<List<int>> possiblemoves = new List<List<int>>();
            List<List<int>> possibleknightmoves = KnightMove();
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
        private List<List<int>> KnightMove()
        {
            List<List<int>> possiblemoves = new List<List<int>>();
            int rank = Square.Position[0];
            int file = Square.Position[1];

            List<int> twouponeright = new List<int> { rank + 2, file + 1 }; 
            if (twouponeright[0] <= 7 & twouponeright[1] <= 7)
            {
                if (Board.BoardArray[twouponeright[0], twouponeright[1]].IsPiece())
                {
                    if (Board.BoardArray[twouponeright[0], twouponeright[1]].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(twouponeright);
                    }
                }
                else
                {
                    possiblemoves.Add(twouponeright);
                }
            }
            List<int> twouponeleft = new List<int> { rank + 2, file - 1 };
            if (twouponeleft[0] <= 7 & twouponeleft[1] >= 0)
            {
                if (Board.BoardArray[twouponeleft[0], twouponeleft[1]].IsPiece())
                {
                    if (Board.BoardArray[twouponeleft[0], twouponeleft[1]].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(twouponeleft);
                    }
                }
                else
                {
                    possiblemoves.Add(twouponeleft);
                }
            }
            List<int> twodownoneright = new List<int> { rank - 2, file + 1 };
            if (twodownoneright[0] >= 0 & twodownoneright[1] <= 7)
            {
                if (Board.BoardArray[twodownoneright[0], twodownoneright[1]].IsPiece())
                {
                    if (Board.BoardArray[twodownoneright[0], twodownoneright[1]].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(twodownoneright);
                    }
                }
                else
                {
                    possiblemoves.Add(twodownoneright);
                }
            }
            List<int> twodownoneleft = new List<int> { rank - 2, file - 1 };
            if (twodownoneleft[0] >= 0 & twodownoneleft[1] >= 0)
            {
                if (Board.BoardArray[twodownoneleft[0], twodownoneleft[1]].IsPiece())
                {
                    if (Board.BoardArray[twodownoneleft[0], twodownoneleft[1]].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(twodownoneleft);
                    }
                }
                else
                {
                    possiblemoves.Add(twodownoneleft);
                }
            }
            List<int> oneuptworight = new List<int> { rank + 1, file + 2 };
            if (oneuptworight[0] <= 7 & oneuptworight[1] <= 7)
            {
                if (Board.BoardArray[oneuptworight[0], oneuptworight[1]].IsPiece())
                {
                    if (Board.BoardArray[oneuptworight[0], oneuptworight[1]].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(oneuptworight);
                    }
                }
                else
                {
                    possiblemoves.Add(oneuptworight);
                }

            }
            List<int> onedowntworight = new List<int> { rank - 1, file + 2 };
            if (onedowntworight[0] >= 0 & onedowntworight[1] <= 7)
            {
                if (Board.BoardArray[onedowntworight[0], onedowntworight[1]].IsPiece())
                {
                    if (Board.BoardArray[onedowntworight[0], onedowntworight[1]].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(onedowntworight);
                    }
                }
                else
                {
                    possiblemoves.Add(onedowntworight);
                }
            }
            List<int> oneuptwoleft = new List<int> { rank + 1, file - 2 };
            if (oneuptwoleft[0] <= 7 & oneuptwoleft[1] >= 0)
            {
                if (Board.BoardArray[oneuptwoleft[0], oneuptwoleft[1]].IsPiece())
                {
                    if (Board.BoardArray[oneuptwoleft[0], oneuptwoleft[1]].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(oneuptwoleft);
                    }
                }
                else
                {
                    possiblemoves.Add(oneuptwoleft);
                }
            }
            List<int> onedowntwoleft = new List<int> { rank - 1, file - 2 };
            if (onedowntwoleft[0] >= 0 & onedowntwoleft[1] >= 0)
            {
                if (Board.BoardArray[onedowntwoleft[0], onedowntwoleft[1]].IsPiece())
                {
                    if (Board.BoardArray[onedowntwoleft[0], onedowntwoleft[1]].Piece.Color != this.Color)
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
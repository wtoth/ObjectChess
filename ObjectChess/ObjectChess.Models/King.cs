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
        public override void Move()
        {
            throw new System.NotImplementedException();
        }
        public override void CalcPossibleMoves()
        {
            List<List<int>> possiblemoves = new List<List<int>>();
            List<List<int>> possiblediagonalmoves = DiagonalMove();
            foreach (var move in possiblediagonalmoves)
            {
                possiblemoves.Add(move);
            }
            List<List<int>> possibleverticalmoves = VerticalMove();
            foreach (var move in possibleverticalmoves)
            {
                possiblemoves.Add(move);
            }
            List<List<int>> possiblehorizontalmoves = HorizontalMove();
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

        private List<List<int>> DiagonalMove()
        {
            List<List<int>> possiblemoves = new List<List<int>>();
            int rank = Square.Position[0];
            int file = Square.Position[1];

            List<int> upright = new List<int> { rank + 1, file + 1 };
            if (upright[0] <= 7 & upright[1] <= 7)
            {
                if (Board.BoardArray[upright[0], upright[1]].IsPiece())
                {
                    if (Board.BoardArray[upright[0], upright[1]].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(upright);
                    }
                }
                else
                {
                    possiblemoves.Add(upright);
                }
            }
            List<int> upleft = new List<int> { rank + 1, file - 1};
            if (upleft[0] <= 7 & upleft[1] >= 0)
            {
                if (Board.BoardArray[upleft[0], upleft[1]].IsPiece())
                {
                    if (Board.BoardArray[upleft[0], upleft[1]].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(upleft);
                    }
                }
                else
                {
                    possiblemoves.Add(upleft);
                }
            }
            List<int> downright = new List<int> { rank - 1, file + 1 };
            if (downright[0] >= 0 & downright[1] <= 7)
            {
                if (Board.BoardArray[downright[0], downright[1]].IsPiece())
                {
                    if (Board.BoardArray[downright[0], downright[1]].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(downright);
                    }
                }
                else
                {
                    possiblemoves.Add(downright);
                }
            }
            List<int> downleft = new List<int> { rank - 1, file - 1 };
            if (downleft[0] >= 0 & downleft[1] >= 0)
            {
                if (Board.BoardArray[downleft[0], downleft[1]].IsPiece())
                {
                    if (Board.BoardArray[downleft[0], downleft[1]].Piece.Color != this.Color)
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

        private List<List<int>> HorizontalMove()
        {
            List<List<int>> possiblemoves = new List<List<int>>();
            int rank = Square.Position[0];
            int file = Square.Position[1];

            List<int> right = new List<int> { rank, file + 1 };
            if (right[1] <= 7)
            {
                if (Board.BoardArray[right[0], right[1]].IsPiece())
                {
                    if (Board.BoardArray[right[0], right[1]].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(right);
                    }
                }
                else
                {
                    possiblemoves.Add(right);
                }
            }
            List<int> left = new List<int> { rank, file - 1 };
            if (left[1] >= 0)
            {
                if (Board.BoardArray[left[0], left[1]].IsPiece())
                {
                    if (Board.BoardArray[left[0], left[1]].Piece.Color != this.Color)
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

        public List<List<int>> VerticalMove()
        {
            List<List<int>> possiblemoves = new List<List<int>>();
            int rank = Square.Position[0];
            int file = Square.Position[1];

            List<int> up = new List<int> { rank+1, file };
            if (up[0] <= 7)
            {
                if (Board.BoardArray[up[0], up[1]].IsPiece())
                {
                    if (Board.BoardArray[up[0], up[1]].Piece.Color != this.Color)
                    {
                        possiblemoves.Add(up);
                    }
                }
                else
                {
                    possiblemoves.Add(up);
                }
            }
            List<int> down = new List<int> { rank-1, file };
            if (down[0] >= 0)
            {
                if (Board.BoardArray[down[0], down[1]].IsPiece())
                {
                    if (Board.BoardArray[down[0], down[1]].Piece.Color != this.Color)
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
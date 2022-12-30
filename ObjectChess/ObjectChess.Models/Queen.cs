using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class Queen: Piece
    {
        public Queen(Square square, Color color, Board board) : base(square, color, board) {
            this.PieceType = PieceType.Queen;
        }
        public override void Move()
        {
            throw new System.NotImplementedException();
        }
        public override void CalcPossibleMoves()
        {
            List<List<int>> possiblemoves = new List<List<int>>();
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
            List<List<int>> possiblediagonalmoves = DiagonalMove();
            foreach (var move in possiblediagonalmoves)
            {
                possiblemoves.Add(move);
            }
            this.PossibleMoves = possiblemoves;
        }
        public override char GetAlgNotation()
        {
            return 'Q';
        }
        private List<List<int>> DiagonalMove()
        {
            List<List<int>> possiblemoves = new List<List<int>>();
            //Checks if there in either of the attacking positions for the pawn
            int rank = Square.Position[0] + 1;
            int file = Square.Position[1] + 1;
            while ((rank >= 0) & (rank <= 7) & (file >= 0) & (file <= 7))
            {
                if (Board.BoardArray[rank, file].IsPiece())
                {
                    if (Board.BoardArray[rank, file].Piece.Color != this.Color)
                    {
                        List<int> position = new List<int> { rank, file };
                        possiblemoves.Add(position);
                    }
                    break;
                }
                else
                {
                    List<int> position = new List<int> { rank, file };
                    possiblemoves.Add(position);
                }
                rank = rank + 1;
                file = file + 1;
            }
            rank = Square.Position[0] - 1;
            file = Square.Position[1] + 1;
            while ((rank >= 0) & (rank <= 7) & (file >= 0) & (file <= 7))
            {
                if (Board.BoardArray[rank, file].IsPiece())
                {
                    if (Board.BoardArray[rank, file].Piece.Color != this.Color)
                    {
                        List<int> position = new List<int> { rank, file };
                        possiblemoves.Add(position);
                    }
                    break;
                }
                else
                {
                    List<int> position = new List<int> { rank, file };
                    possiblemoves.Add(position);
                }
                rank = rank - 1;
                file = file + 1;
            }
            rank = Square.Position[0] + 1;
            file = Square.Position[1] - 1;
            while ((rank >= 0) & (rank <= 7) & (file >= 0) & (file <= 7))
            {
                if (Board.BoardArray[rank, file].IsPiece())
                {
                    if (Board.BoardArray[rank, file].Piece.Color != this.Color)
                    {
                        List<int> position = new List<int> { rank, file };
                        possiblemoves.Add(position);
                    }
                    break;
                }
                else
                {
                    List<int> position = new List<int> { rank, file };
                    possiblemoves.Add(position);
                }
                rank = rank + 1;
                file = file - 1;
            }
            rank = Square.Position[0] - 1;
            file = Square.Position[1] - 1;
            while ((rank >= 0) & (rank <= 7) & (file >= 0) & (file <= 7))
            {
                if (Board.BoardArray[rank, file].IsPiece())
                {
                    if (Board.BoardArray[rank, file].Piece.Color != this.Color)
                    {
                        List<int> position = new List<int> { rank, file };
                        possiblemoves.Add(position);
                    }
                    break;
                }
                else
                {
                    List<int> position = new List<int> { rank, file };
                    possiblemoves.Add(position);
                }
                rank = rank - 1;
                file = file - 1;
            }
            return possiblemoves;
        }

        private List<List<int>> HorizontalMove()
        {
            {
                List<List<int>> possiblemoves = new List<List<int>>();
                //Checks if there in either of the attacking positions for the pawn
                int rank = Square.Position[0] + 1;
                int file = Square.Position[1];
                while ((rank >= 0) & (rank <= 7) & (file >= 0) & (file <= 7))
                {
                    if (Board.BoardArray[rank, file].IsPiece())
                    {
                        if (Board.BoardArray[rank, file].Piece.Color != this.Color)
                        {
                            List<int> position = new List<int> { rank, file };
                            possiblemoves.Add(position);
                        }
                        break;
                    }
                    else
                    {
                        List<int> position = new List<int> { rank, file };
                        possiblemoves.Add(position);
                    }
                    rank = rank + 1;
                }
                rank = Square.Position[0] - 1;
                file = Square.Position[1];
                while ((rank >= 0) & (rank <= 7) & (file >= 0) & (file <= 7))
                {
                    if (Board.BoardArray[rank, file].IsPiece())
                    {
                        if (Board.BoardArray[rank, file].Piece.Color != this.Color)
                        {
                            List<int> position = new List<int> { rank, file };
                            possiblemoves.Add(position);
                        }
                        break;
                    }
                    else
                    {
                        List<int> position = new List<int> { rank, file };
                        possiblemoves.Add(position);
                    }
                    rank = rank - 1;
                }
                return possiblemoves;
            }
        }

        private List<List<int>> VerticalMove()
        {
            List<List<int>> possiblemoves = new List<List<int>>();
            //Checks if there in either of the attacking positions for the pawn
            int rank = Square.Position[0];
            int file = Square.Position[1] + 1;
            while ((rank >= 0) & (rank <= 7) & (file >= 0) & (file <= 7))
            {
                if (Board.BoardArray[rank, file].IsPiece())
                {
                    if (Board.BoardArray[rank, file].Piece.Color != this.Color)
                    {
                        List<int> position = new List<int> { rank, file };
                        possiblemoves.Add(position);
                    }
                    break;
                }
                else
                {
                    List<int> position = new List<int> { rank, file };
                    possiblemoves.Add(position);
                }
                file = file + 1;
            }
            rank = Square.Position[0];
            file = Square.Position[1] - 1;
            while ((rank >= 0) & (rank <= 7) & (file >= 0) & (file <= 7))
            {
                if (Board.BoardArray[rank, file].IsPiece())
                {
                    if (Board.BoardArray[rank, file].Piece.Color != this.Color)
                    {
                        List<int> position = new List<int> { rank, file };
                        possiblemoves.Add(position);
                    }
                    break;
                }
                else
                {
                    List<int> position = new List<int> { rank, file };
                    possiblemoves.Add(position);
                }
                file = file - 1;
            }
            return possiblemoves;
        }
    }
}
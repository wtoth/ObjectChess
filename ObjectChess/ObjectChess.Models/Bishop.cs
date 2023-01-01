using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class Bishop: Piece
    {
        public Bishop(Square square, Color color, Board board) : base(square, color, board) 
        {
            PieceType = PieceType.Bishop;
        }
        public override void CalcPossibleMoves()
        {
            {
                List<PieceLocation> possiblemoves = new List<PieceLocation>();
                List<PieceLocation> possiblediagonalmoves = DiagonalMove();
                foreach (var move in possiblediagonalmoves)
                {
                    possiblemoves.Add(move);
                }
                this.PossibleMoves = possiblemoves;
            }
        }
        public override char GetAlgNotation()
        {
            return 'B';
        }
        private List<PieceLocation> DiagonalMove()
        {
            List<PieceLocation> possiblemoves = new List<PieceLocation>();
            //Checks if there in either of the attacking positions for the pawn
            int rank = Square.Position.Rank +1;
            int file = Square.Position.File +1;
            while ((rank >= 0) & (rank <= 7) & (file >= 0) & (file <= 7))
            {
                if (Board.BoardArray[rank, file].IsPiece())
                {
                    if (Board.BoardArray[rank, file].Piece.Color != this.Color)
                    {
                        PieceLocation position = new PieceLocation( rank, file );
                        possiblemoves.Add(position);
                    }
                    break;
                }
                else
                {
                    PieceLocation position = new PieceLocation(rank, file);
                    possiblemoves.Add(position);
                }
                rank = rank + 1;
                file = file + 1;
            }
            rank = Square.Position.Rank -1;
            file = Square.Position.File +1;
            while ((rank >= 0) & (rank <= 7) & (file >= 0) & (file <= 7))
            {
                if (Board.BoardArray[rank, file].IsPiece())
                {
                    if (Board.BoardArray[rank, file].Piece.Color != this.Color)
                    {
                        PieceLocation position = new PieceLocation(rank, file);
                        possiblemoves.Add(position);
                    }
                    break;
                }
                else
                {
                    PieceLocation position = new PieceLocation(rank, file);
                    possiblemoves.Add(position);
                }
                rank = rank - 1;
                file = file + 1;
            }
            rank = Square.Position.Rank + 1;
            file = Square.Position.File - 1;
            while ((rank >= 0) & (rank <= 7) & (file >= 0) & (file <= 7))
            {
                if (Board.BoardArray[rank, file].IsPiece())
                {
                    if (Board.BoardArray[rank, file].Piece.Color != this.Color)
                    {
                        PieceLocation position = new PieceLocation(rank, file);
                        possiblemoves.Add(position);
                    }
                    break;
                }
                else
                {
                    PieceLocation position = new PieceLocation(rank, file);
                    possiblemoves.Add(position);
                }
                rank = rank + 1;
                file = file - 1;
            }
            rank = Square.Position.Rank-1;
            file = Square.Position.File -1;
            while ((rank >= 0) & (rank <= 7) & (file >= 0) & (file <= 7))
            {
                if (Board.BoardArray[rank, file].IsPiece())
                {
                    if (Board.BoardArray[rank, file].Piece.Color != this.Color)
                    {
                        PieceLocation position = new PieceLocation(rank, file);
                        possiblemoves.Add(position);
                    }
                    break;
                }
                else
                {
                    PieceLocation position = new PieceLocation(rank, file);
                    possiblemoves.Add(position);
                }
                rank = rank - 1;
                file = file - 1;
            }
            return possiblemoves;
        }
    }
}
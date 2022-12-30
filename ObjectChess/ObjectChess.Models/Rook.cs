using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class Rook: Piece
    {
        public Rook(Square square, Color color, Board board):base(square, color, board) 
        {
            PieceType = PieceType.Rook;
        }
        public override void Move()
        {
            throw new System.NotImplementedException();
        }
        public override void CalcPossibleMoves()
        {
            List<PieceLocation> possiblemoves = new List<PieceLocation>();
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
            this.PossibleMoves = possiblemoves;
        }
        public override char GetAlgNotation()
        {
            return 'R';
        }
        private List<PieceLocation> HorizontalMove()
        {
            List<PieceLocation> possiblemoves = new List<PieceLocation>();
            //Checks if there in either of the attacking positions for the pawn
            int rank = Square.Position.Rank + 1;
            int file = Square.Position.File;
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
            }
            rank = Square.Position.Rank - 1;
            file = Square.Position.File;
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
            }
            return possiblemoves;
        }

        private List<PieceLocation> VerticalMove()
        {
            List<PieceLocation> possiblemoves = new List<PieceLocation>();
            //Checks if there in either of the attacking positions for the pawn
            int rank = Square.Position.Rank;
            int file = Square.Position.File + 1;
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
                file = file + 1;
            }
            rank = Square.Position.Rank;
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
                file = file - 1;
            }
            return possiblemoves;
        }
    }
}
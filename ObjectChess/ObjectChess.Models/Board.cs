using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.Models
{
    public class Board
    {
        public Square[,] BoardArray = new Square[8,8];

        public Board()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PieceLocation position = new PieceLocation(i, j);
                    BoardArray[i, j] = new Square(position, false);
                }
            }

        }
        public Board(Board board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Piece oldPiece = board.BoardArray[i, j].Piece;
                    Piece newPiece;
                    if (oldPiece != null)
                    {
                        if (oldPiece.PieceType == PieceType.Pawn)
                        {
                            newPiece = new Pawn(oldPiece.Square, oldPiece.Color, oldPiece.Board);
                        }
                        else if (oldPiece.PieceType == PieceType.Queen)
                        {
                            newPiece = new Queen(oldPiece.Square, oldPiece.Color, oldPiece.Board);
                        }
                        else if (oldPiece.PieceType == PieceType.King)
                        {
                            newPiece = new King(oldPiece.Square, oldPiece.Color, oldPiece.Board);
                        }
                        else if (oldPiece.PieceType == PieceType.Rook)
                        {
                            newPiece = new Rook(oldPiece.Square, oldPiece.Color, oldPiece.Board);
                        }
                        else if (oldPiece.PieceType == PieceType.Bishop)
                        {
                            newPiece = new Bishop(oldPiece.Square, oldPiece.Color, oldPiece.Board);
                        }
                        else if (oldPiece.PieceType == PieceType.Knight)
                        {
                            newPiece = new Knight(oldPiece.Square, oldPiece.Color, oldPiece.Board);
                        }
                        else
                        {
                            newPiece = null;
                        }
                    }
                    else
                    {
                        newPiece = null;
                    }
                    PieceLocation position = new PieceLocation(i, j);
                    BoardArray[i, j] = new Square(position, newPiece);
                }
            }
        }
        public Square GetSquare(PieceLocation RankFile)
        {
            return this.BoardArray[RankFile.Rank, RankFile.File];
        }
        public bool IsCheckMate()
        {
            throw new System.NotImplementedException();
        }
        public void CanCastle()
        {
            throw new System.NotImplementedException();
        }
        public Board Clone()
        {
            Board boardClone = new Board(this);
            return boardClone;
        }
    }
}

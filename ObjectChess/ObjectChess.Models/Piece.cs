using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.Models
{
    public abstract class Piece
    {
        public Color Color { get; set; }
        public Square Square { get; set; }
        public PieceType PieceType { get; set; }
        public Board Board { get; set; }

        public List<PieceLocation> PossibleMoves { get; set; }
        public Piece(Square square, Color color, Board board)
        {
            this.Square = square;
            this.Color = color;
            this.Board = board;
        }
        public void CanMove()
        {
            throw new System.NotImplementedException();
        }
        public abstract char GetAlgNotation();
        public void VerticalMove()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Move(Square CurrentSquare, Square DestinationSquare, Piece AttackedPiece, List<Piece> Captured)
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

        public abstract void CalcPossibleMoves();

        public void SetupPiece()
        {
            throw new System.NotImplementedException();
        }

        public bool IsPiece()
        {
            throw new System.NotImplementedException();
        }
    }
}

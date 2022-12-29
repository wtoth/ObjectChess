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

        public List<List<int>> PossibleMoves { get; set; }
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

        public abstract void Move();

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

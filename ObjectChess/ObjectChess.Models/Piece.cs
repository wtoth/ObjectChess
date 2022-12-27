using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.Models
{
    public abstract class Piece
    {
        Color Color { get; set; }

        Square Square { get; set; }

        public List<List<int>> PossibleMoves
        {
            get => default;
            set
            {
            }
        }
        public Piece(Square square, Color color)
        {
            this.Square = square;
            this.Color = color;
        }

        public void CanMove()
        {
            throw new System.NotImplementedException();
        }

        public void VerticalMove()
        {
            throw new System.NotImplementedException();
        }

        public abstract void Move();

        public void CalcPossibleMoves()
        {
            throw new System.NotImplementedException();
        }

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

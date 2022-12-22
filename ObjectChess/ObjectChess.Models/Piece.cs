using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.Models
{
    public abstract class Piece
    {
        int Color { get; set; }
        bool Alive { get; set; }

        public Square Square
        {
            get => default;
            set
            {
            }
        }

        public List<string> PossibleMoves
        {
            get => default;
            set
            {
            }
        }

        public void CanMove()
        {
            throw new System.NotImplementedException();
        }

        public void VerticalMove()
        {
            throw new System.NotImplementedException();
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public void CalcPossibleMoves()
        {
            throw new System.NotImplementedException();
        }

        public void SetupPiece()
        {
            throw new System.NotImplementedException();
        }

        public Piece()
        {

        }
        
    }
}

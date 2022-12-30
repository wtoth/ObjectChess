using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.Models
{
    public class Square
    {
        public PieceLocation Position { get; set; }
        public Piece Piece { get; set; }
        public bool Attacked { get; set; }
        public Square(PieceLocation position, bool attacked = false) 
        { 
            this.Position = position;
            this.Attacked= attacked;
        }
        public bool SquareAttacked()
        {
            throw new System.NotImplementedException();
        }
        public bool IsCheck()
        {
            throw new System.NotImplementedException();
        }
        public bool IsPiece()
        {
            if (Piece == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

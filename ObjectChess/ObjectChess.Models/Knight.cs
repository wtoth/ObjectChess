using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class Knight : Piece
    {
        public Knight(Square square, Color color) : base(square, color) { }
        public override void Move()
        {
            throw new System.NotImplementedException();
        }
        private void KnightMove()
        {
            throw new System.NotImplementedException();
        }
    }
}
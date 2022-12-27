using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class Rook: Piece
    {
        public Rook(Square square, Color color):base(square, color) { }
        public override void Move()
        {
            throw new System.NotImplementedException();
        }
        private void HorizontalMove()
        {
            throw new System.NotImplementedException();
        }

        private void VerticalMove()
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class Pawn : Piece
    {
        public Pawn(Square square, Color color) : base(square, color) { }
        public override void Move()
        {
            throw new System.NotImplementedException();
        }
        public void Promote()
        {
            throw new System.NotImplementedException();
        }

        private void DiagonalMove()
        {
            throw new System.NotImplementedException();
        }

        private void VerticalMove()
        {
            throw new System.NotImplementedException();
        }
    }
}
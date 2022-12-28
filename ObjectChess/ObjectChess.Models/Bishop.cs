using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class Bishop: Piece
    {
        public Bishop(Square square, Color color) : base(square, color) 
        {
            PieceType = PieceType.Bishop;
        }
        public override void Move()
        {
            throw new System.NotImplementedException();
        }
        public override char GetAlgNotation()
        {
            return 'B';
        }
        private void DiagonalMove()
        {
            throw new System.NotImplementedException();
        }
    }
}
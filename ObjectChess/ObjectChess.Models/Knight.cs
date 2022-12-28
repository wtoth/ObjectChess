using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class Knight : Piece
    {
        public Knight(Square square, Color color) : base(square, color) 
        {
            PieceType = PieceType.Knight;
        }
        public override void Move()
        {
            throw new System.NotImplementedException();
        }
        public override char GetAlgNotation()
        {
            return 'N';
        }
        private void KnightMove()
        {
            throw new System.NotImplementedException();
        }
    }
}
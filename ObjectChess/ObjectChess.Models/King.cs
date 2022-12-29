using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class King: Piece
    {
        public King(Square square, Color color, Board board) : base(square, color, board) 
        {
            PieceType = PieceType.King;
        }
        public override void Move()
        {
            throw new System.NotImplementedException();
        }
        public override void CalcPossibleMoves()
        {
            throw new System.NotImplementedException();
        }
        public override char GetAlgNotation()
        {
            return 'K';
        }
        public void CanCastle()
        {
            throw new System.NotImplementedException();
        }

        public void Castle()
        {
            throw new System.NotImplementedException();
        }

        private void DiagonalMove()
        {
            throw new System.NotImplementedException();
        }

        private void HorizontalMove()
        {
            throw new System.NotImplementedException();
        }

        public void VerticalMove()
        {
            throw new System.NotImplementedException();
        }

        public void IsCheck()
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class Queen: Piece
    {
        public Queen(Square square, Color color, Board board) : base(square, color, board) {
            this.PieceType = PieceType.Queen;
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
            return 'Q';
        }
        private void DiagonalMove()
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class Rook: Piece
    {
        public Rook(Square square, Color color, Board board):base(square, color, board) 
        {
            PieceType = PieceType.Rook;
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
            return 'R';
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
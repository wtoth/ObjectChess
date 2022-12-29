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
            List<List<int>> possiblemoves = new List<List<int>>();
            List<List<int>> possiblediagonalmoves = DiagonalMove();
            foreach (var move in possiblediagonalmoves)
            {
                possiblemoves.Add(move);
            }
            List<List<int>> possibleverticalmoves = VerticalMove();
            foreach (var move in possibleverticalmoves)
            {
                possiblemoves.Add(move);
            }
            List<List<int>> possiblehorizontalmoves = HorizontalMove();
            foreach (var move in possiblehorizontalmoves)
            {
                possiblemoves.Add(move);
            }
            this.PossibleMoves = possiblemoves;
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

        private List<List<int>> DiagonalMove()
        {
            throw new System.NotImplementedException();
        }

        private List<List<int>> HorizontalMove()
        {
            throw new System.NotImplementedException();
        }

        public List<List<int>> VerticalMove()
        {
            throw new System.NotImplementedException();
        }

        public void IsCheck()
        {
            throw new System.NotImplementedException();
        }
    }
}
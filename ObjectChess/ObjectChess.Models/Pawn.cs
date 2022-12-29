using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class Pawn : Piece
    {
        bool EnPassant = false;
        public Pawn(Square square, Color color, Board board) : base(square, color, board) 
        {
            PieceType = PieceType.Pawn;
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
            this.PossibleMoves = possiblemoves;
        }
        public override void Move()
        {
            throw new System.NotImplementedException();
        }
        public override char GetAlgNotation()
        {
            return 'P';
        }
        public void Promote()
        {
            throw new System.NotImplementedException();
        }

        private List<List<int>> DiagonalMove()
        {
            List<List<int>> possiblemoves = new List<List<int>>();
            //Checks if there in either of the attacking positions for the pawn
            if (this.Color == Color.White)
            {   
                if (this.Board.BoardArray[(this.Square.Position[0] + 1), (this.Square.Position[0] + 1)].IsPiece())
                {
                    possiblemoves.Add(this.Board.BoardArray[(this.Square.Position[0] + 1), (this.Square.Position[0] + 1)].Position);
                }
                if (this.Board.BoardArray[(this.Square.Position[0] + 1), (this.Square.Position[0] - 1)].IsPiece())
                {
                    possiblemoves.Add(this.Board.BoardArray[(this.Square.Position[0] + 1), (this.Square.Position[0] - 1)].Position);
                }
            }
            else 
            {
                if (this.Board.BoardArray[(this.Square.Position[0] - 1), (this.Square.Position[0] + 1)].IsPiece())
                {
                    possiblemoves.Add(this.Board.BoardArray[(this.Square.Position[0] - 1), (this.Square.Position[0] + 1)].Position);
                }
                if (this.Board.BoardArray[(this.Square.Position[0] - 1), (this.Square.Position[0] - 1)].IsPiece())
                {
                    possiblemoves.Add(this.Board.BoardArray[(this.Square.Position[0] - 1), (this.Square.Position[0] - 1)].Position);
                }
            }
            return possiblemoves;
        }

        private List<List<int>> VerticalMove()
        {
            List<List<int>> possiblemoves = new List<List<int>>();
            if (this.Color == Color.White)
            {
                //Check if there is not piece in front of current piece
                if (!this.Board.BoardArray[(this.Square.Position[0] + 1), (this.Square.Position[0])].IsPiece())
                {
                    possiblemoves.Add(this.Board.BoardArray[(this.Square.Position[0] + 1), (this.Square.Position[0])].Position);
                }
                //Check if there is not a piece in front of current piece for two moves and if the pawn is in the second rank
                if ((!this.Board.BoardArray[(this.Square.Position[0] + 1), (this.Square.Position[0])].IsPiece()) & (!this.Board.BoardArray[(this.Square.Position[0] + 2), (this.Square.Position[0])].IsPiece()) & (this.Square.Position[0] == 1))
                {
                    possiblemoves.Add(this.Board.BoardArray[(this.Square.Position[0] + 2), (this.Square.Position[0])].Position);
                }
            }
            else
            {
                //Check if there is not piece in front of current piece
                if (!this.Board.BoardArray[(this.Square.Position[0] - 1), (this.Square.Position[0])].IsPiece())
                {
                    possiblemoves.Add(this.Board.BoardArray[(this.Square.Position[0] - 1), (this.Square.Position[0])].Position);
                }
                //Check if there is not a piece in front of current piece for two moves and if the pawn is in the second rank
                if ((!this.Board.BoardArray[(this.Square.Position[0] - 1), (this.Square.Position[0])].IsPiece()) & (!this.Board.BoardArray[(this.Square.Position[0] - 2), (this.Square.Position[0])].IsPiece()) & (this.Square.Position[0] == 6))
                {
                    possiblemoves.Add(this.Board.BoardArray[(this.Square.Position[0] - 2), (this.Square.Position[0])].Position);
                }
            }
            return possiblemoves;
        }
    }
}
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
            List<PieceLocation> possiblemoves = new List<PieceLocation>();
            List<PieceLocation> possiblediagonalmoves = DiagonalMove();
            foreach (var move in possiblediagonalmoves)
            {
                possiblemoves.Add(move);
            }
            List<PieceLocation> possibleverticalmoves = VerticalMove();
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

        private List<PieceLocation> DiagonalMove()
        {
            List<PieceLocation> possiblemoves = new List<PieceLocation>();
            //Checks if there in either of the attacking positions for the pawn
            if (this.Color == Color.White)
            {
                PieceLocation attackright = new PieceLocation((this.Square.Position.Rank + 1), (this.Square.Position.File + 1));
                if (attackright.Rank <= 7 & attackright.File <= 7)
                {
                    Square attackrightsquare = Board.BoardArray[attackright.Rank, attackright.File];
                    if (attackrightsquare.IsPiece())
                    {
                        if (attackrightsquare.Piece.Color == Color.Black)
                        {
                            possiblemoves.Add(attackright);
                        }
                    }
                }
                PieceLocation attackleft = new PieceLocation((this.Square.Position.Rank + 1), (this.Square.Position.File - 1));
                if (attackleft.Rank <= 7 & attackleft.File >= 0)
                {
                    Square attackleftsquare = Board.BoardArray[attackleft.Rank, attackleft.File];
                    if (attackleftsquare.IsPiece())
                    {
                        if (attackleftsquare.Piece.Color == Color.Black)
                        {
                            possiblemoves.Add(attackleft);
                        }
                    }
                }
                
            }
            else 
            {
                PieceLocation attackright = new PieceLocation((this.Square.Position.Rank - 1), (this.Square.Position.File + 1));
                if (attackright.Rank >= 0 & attackright.File <= 7)
                {
                    Square attackrightsquare = Board.BoardArray[attackright.Rank, attackright.File];
                    if (attackrightsquare.IsPiece())
                    {
                        if (attackrightsquare.Piece.Color == Color.White)
                        {
                            possiblemoves.Add(attackright);
                        }
                    }
                }  
                PieceLocation attackleft = new PieceLocation((this.Square.Position.Rank - 1), (this.Square.Position.File - 1));
                if (attackleft.Rank >= 0 & attackleft.File >= 0)
                {
                    Square attackleftsquare = Board.BoardArray[attackleft.Rank, attackleft.File];
                    if (attackleftsquare.IsPiece())
                    {
                        if (attackleftsquare.Piece.Color == Color.White)
                        {
                            possiblemoves.Add(attackleft);
                        }
                    }
                }
            }
            return possiblemoves;
        }

        private List<PieceLocation> VerticalMove()
        {
            List<PieceLocation> possiblemoves = new List<PieceLocation>();
            if (this.Color == Color.White)
            {
                //Check if there is not piece in front of current piece
                PieceLocation moveforwardone = new PieceLocation(this.Square.Position.Rank + 1, this.Square.Position.File);
                Square squareinfront = this.Board.BoardArray[moveforwardone.Rank, moveforwardone.File];
                if (!squareinfront.IsPiece() & moveforwardone.Rank <= 7)
                {
                    possiblemoves.Add(moveforwardone);
                }
                //Check if there is not a piece in front of current piece for two moves and if the pawn is in the second rank
                PieceLocation moveforwardtwo = new PieceLocation(this.Square.Position.Rank + 2, this.Square.Position.File);
                Square squaretwoinfront = this.Board.BoardArray[moveforwardone.Rank, moveforwardone.File];
                if (!squaretwoinfront.IsPiece() & moveforwardtwo.Rank <= 7)
                {
                    possiblemoves.Add(moveforwardtwo);
                }
            }
            else
            {
                //Check if there is not piece in front of current piece
                PieceLocation moveforwardone = new PieceLocation(this.Square.Position.Rank - 1, this.Square.Position.File);
                Square squareinfront = this.Board.BoardArray[moveforwardone.Rank, moveforwardone.File];
                if (!squareinfront.IsPiece() & moveforwardone.Rank >= 0)
                {
                    possiblemoves.Add(moveforwardone);
                }
                //Check if there is not a piece in front of current piece for two moves and if the pawn is in the second rank
                PieceLocation moveforwardtwo = new PieceLocation(this.Square.Position.Rank - 2, this.Square.Position.File);
                Square squaretwoinfront = this.Board.BoardArray[moveforwardone.Rank, moveforwardone.File];
                if (!squaretwoinfront.IsPiece() & moveforwardtwo.Rank >= 0)
                {
                    possiblemoves.Add(moveforwardtwo);
                }
            }
            return possiblemoves;
        }
    }
}
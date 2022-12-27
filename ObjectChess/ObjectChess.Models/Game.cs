using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.Models
{
    public class Game
    {
        public int CurrTurn = (int)Color.White;

        public List<Piece> Captured
        {
            get => default;
            set
            {
            }
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public void IsCheck()
        {
            throw new System.NotImplementedException();
        }

        public void IsCheckmate()
        {
            throw new System.NotImplementedException();
        }
        //Need to solve how to get piece type here and how to output them in a aesthetically pleasing way
        public List<string> GetBoard(Board board)
        {
            List<string> boardOutput = new List<string>();
            foreach (var square in board.BoardArray)
            {
                string position = square.Position[0].ToString() + square.Position[1].ToString();
                boardOutput.Add(position);
            }
            foreach (var piece in boardOutput)
            {
                Console.Write(piece.ToString());
            }
            return boardOutput;
        }

        public void PossibleMoves()
        {
            throw new System.NotImplementedException();
        }

        public Board SetupBoard()
        {
            Board board = new Board();
            return board;
        }

        public List<int> AlgebraicNotationToRankFile()
        {
            throw new System.NotImplementedException();
        }

        //This will allow us to setup custom piece configs in the future
        //Look into FEN setup process in the future
        public void SetupPieces(Board board)
        {
            string[,] PieceSetup = new string[,] {{"r","n","b","q","k","b","n","r"},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"r","n","b","k","q","b","n","r"}};

            for (int i = 0; i < 8; i++)
            {
                for (int j=0; j < 8; j++)
                {
                    Color pieceColor;
                    if (i < 3)
                    {
                        pieceColor = Color.White;
                    }
                    else
                    {
                        pieceColor = Color.Black;
                    }
                    if (PieceSetup[i,j] == "r")
                    {
                        Rook rook = new Rook(board.BoardArray[i, j], pieceColor);
                        board.BoardArray[i, j].Piece = rook;
                    }
                    else if (PieceSetup[i, j] == "n")
                    {
                        Knight knight = new Knight(board.BoardArray[i, j], pieceColor);
                        board.BoardArray[i, j].Piece = knight;
                    }
                    else if (PieceSetup[i, j] == "b")
                    {
                        Bishop bishop = new Bishop(board.BoardArray[i, j], pieceColor);
                        board.BoardArray[i, j].Piece = bishop;
                    }
                    else if (PieceSetup[i, j] == "q")
                    {
                        Queen queen = new Queen(board.BoardArray[i, j], pieceColor);
                        board.BoardArray[i, j].Piece = queen;
                    }
                    else if (PieceSetup[i, j] == "k")
                    {
                        King king = new King(board.BoardArray[i, j], pieceColor);
                        board.BoardArray[i, j].Piece = king;
                    }
                    else if (PieceSetup[i, j] == "p")
                    {
                        Pawn pawn= new Pawn(board.BoardArray[i, j], pieceColor);
                        board.BoardArray[i, j].Piece = pawn;
                    }
                }
            }
        }
    }
}

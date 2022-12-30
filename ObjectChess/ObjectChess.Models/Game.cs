using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.Models
{
    public class Game
    {
        public int CurrTurn = (int)Color.White;
        public List<Piece> Captured { get; set; }
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
        public List<string> GetBoard(Board board)
        {
            var boardOutput = new List<string>();
            foreach (var square in board.BoardArray)
            {
                if (square.Piece != null)
                {
                    var type = square.Piece.GetAlgNotation();
                    boardOutput.Add(type.ToString());
                } else
                {
                    boardOutput.Add("-");
                }
            }
            return boardOutput;
        }

        public List<PieceLocation> PossibleMoves(PieceLocation rankfile, Board board)
        {
            Square Square = board.GetSquare(rankfile);
            Piece Piece = Square.Piece;
            if (Square.IsPiece())
            {
                Piece.CalcPossibleMoves();
                return Piece.PossibleMoves;
            }
            else
            {
                throw new InvalidOperationException("No Piece Found here");
            }
        }
        public Board SetupBoard()
        {
            Board board = new Board();
            return board;
        }
        public PieceLocation AlgebraicNotationToRankFile(string input)
        {
            PieceLocation RankFile = new PieceLocation();
            //List<int> RankFile = new List<int>();
            char[] letters = input.ToCharArray();
            RankFile.Rank = (int)Char.GetNumericValue(letters[1]) - 1;

            if (char.ToLower(letters[0]) == 'a')
            {
                RankFile.File = 0;
            }
            else if (char.ToLower(letters[0]) == 'b')
            {
                RankFile.File = 1;
            }
            else if (char.ToLower(letters[0]) == 'c')
            {
                RankFile.File = 2;
            }
            else if (char.ToLower(letters[0]) == 'd')
            {
                RankFile.File = 3;
            }
            else if (char.ToLower(letters[0]) == 'e')
            {
                RankFile.File = 4;
            }
            else if (char.ToLower(letters[0]) == 'f')
            {
                RankFile.File = 5;
            }
            else if (char.ToLower(letters[0]) == 'g')
            {
                RankFile.File = 6;
            }
            else if (char.ToLower(letters[0]) == 'h')
            {
                RankFile.File = 7;
            }
            return RankFile;
        }
        public string RankFileToAlgebraicNotation(PieceLocation RankFile)
        {
            string algnotation = "";
            if (RankFile.File == 0)
            {
                algnotation = algnotation + "A";
            }
            else if (RankFile.File == 1)
            {
                algnotation = algnotation + "B";
            }
            else if (RankFile.File == 2)
            {
                algnotation = algnotation + "C";
            }
            else if (RankFile.File == 3)
            {
                algnotation = algnotation + "D";
            }
            else if (RankFile.File == 4)
            {
                algnotation = algnotation + "E";
            }
            else if (RankFile.File == 5)
            {
                algnotation = algnotation + "F";
            }
            else if (RankFile.File == 6)
            {
                algnotation = algnotation + "G";
            }
            else if (RankFile.File == 7)
            {
                algnotation = algnotation + "H";
            }
            algnotation = algnotation + (RankFile.Rank + 1).ToString();
            return algnotation;
        }
        //This will allow us to setup custom piece configs in the future
        //Look into FEN setup process in the future
        public void SetupPieces(Board board, string[,] PieceSetup)
        {
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
                        Rook rook = new Rook(board.BoardArray[i, j], pieceColor, board);
                        board.BoardArray[i, j].Piece = rook;
                    }
                    else if (PieceSetup[i, j] == "n")
                    {
                        Knight knight = new Knight(board.BoardArray[i, j], pieceColor, board);
                        board.BoardArray[i, j].Piece = knight;
                    }
                    else if (PieceSetup[i, j] == "b")
                    {
                        Bishop bishop = new Bishop(board.BoardArray[i, j], pieceColor, board);
                        board.BoardArray[i, j].Piece = bishop;
                    }
                    else if (PieceSetup[i, j] == "q")
                    {
                        Queen queen = new Queen(board.BoardArray[i, j], pieceColor, board);
                        board.BoardArray[i, j].Piece = queen;
                    }
                    else if (PieceSetup[i, j] == "k")
                    {
                        King king = new King(board.BoardArray[i, j], pieceColor, board);
                        board.BoardArray[i, j].Piece = king;
                    }
                    else if (PieceSetup[i, j] == "p")
                    {
                        Pawn pawn= new Pawn(board.BoardArray[i, j], pieceColor, board);
                        board.BoardArray[i, j].Piece = pawn;
                    }
                }
            }
        }
        public void SetupPieces(Board board, string fen)
        {
            int rank = 0;
            int file = 0;

            //reverse fen
            char[] charArray = fen.ToCharArray();
            Array.Reverse(charArray);
            string reversefen = new string(charArray);
            foreach (var letter in reversefen)
            {
                if (Char.IsNumber(letter))
                {
                    if (letter == '8')
                    {
                        if (rank == 7)
                        {
                            break;
                        }
                        else
                        {
                            file = file + (int)Char.GetNumericValue(letter);
                        }
                    }
                    else
                    {
                        file = file + (int)Char.GetNumericValue(letter);
                    }
                }
                else if (letter == '/')
                {
                    rank++;
                    file = 0;
                }
                else
                {
                    if (letter == 'k')
                    {
                        King king = new King(board.BoardArray[rank, file], Color.Black, board);
                        board.BoardArray[rank, file].Piece = king;
                        file++;
                    }
                    else if (letter == 'q')
                    {
                        Queen queen = new Queen(board.BoardArray[rank, file], Color.Black, board);
                        board.BoardArray[rank, file].Piece = queen;
                        file++;
                    }
                    else if (letter == 'r')
                    {
                        Rook rook = new Rook(board.BoardArray[rank, file], Color.Black, board);
                        board.BoardArray[rank, file].Piece = rook;
                        file++;
                    }
                    else if (letter == 'n')
                    {
                        Knight knight = new Knight(board.BoardArray[rank, file], Color.Black, board);
                        board.BoardArray[rank, file].Piece = knight;
                        file++;
                    }
                    else if (letter == 'b')
                    {
                        Bishop bishop = new Bishop(board.BoardArray[rank, file], Color.Black, board);
                        board.BoardArray[rank, file].Piece = bishop;
                        file++;
                    }
                    else if (letter == 'p')
                    {
                        Pawn pawn = new Pawn(board.BoardArray[rank, file], Color.Black, board);
                        board.BoardArray[rank, file].Piece = pawn;
                        file++;
                    }
                    if (letter == 'K')
                    {
                        King king = new King(board.BoardArray[rank, file], Color.White, board);
                        board.BoardArray[rank, file].Piece = king;
                        file++;
                    }
                    else if (letter == 'Q')
                    {
                        Queen queen = new Queen(board.BoardArray[rank, file], Color.White, board);
                        board.BoardArray[rank, file].Piece = queen;
                        file++;
                    }
                    else if (letter == 'R')
                    {
                        Rook rook = new Rook(board.BoardArray[rank, file], Color.White, board);
                        board.BoardArray[rank, file].Piece = rook;
                        file++;
                    }
                    else if (letter == 'N')
                    {
                        Knight knight = new Knight(board.BoardArray[rank, file], Color.White, board);
                        board.BoardArray[rank, file].Piece = knight;
                        file++;
                    }
                    else if (letter == 'B')
                    {
                        Bishop bishop = new Bishop(board.BoardArray[rank, file], Color.White, board);
                        board.BoardArray[rank, file].Piece = bishop;
                        file++;
                    }
                    else if (letter == 'P')
                    {
                        Pawn pawn = new Pawn(board.BoardArray[rank, file], Color.White, board);
                        board.BoardArray[rank, file].Piece = pawn;
                        file++;
                    }
                }
            }
        }
    }
}
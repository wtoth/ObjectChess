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

        public List<List<int>> PossibleMoves(List<int> position, Board board)
        {
            if (board.BoardArray[position[0], position[1]].IsPiece())
            {
                board.BoardArray[position[0], position[1]].Piece.CalcPossibleMoves();
                return board.BoardArray[position[0], position[1]].Piece.PossibleMoves;
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
        public List<int> AlgebraicNotationToRankFile(string input)
        {
            List<int> RankFile = new List<int>();
            char[] letters = input.ToCharArray();
            int rank = (int)Char.GetNumericValue(letters[1]) - 1;
            RankFile.Add(rank);

            if (char.ToLower(letters[0]) == 'a')
            {
                RankFile.Add(0);
            }
            else if (char.ToLower(letters[0]) == 'b')
            {
                RankFile.Add(1);
            }
            else if (char.ToLower(letters[0]) == 'c')
            {
                RankFile.Add(2);
            }
            else if (char.ToLower(letters[0]) == 'd')
            {
                RankFile.Add(3);
            }
            else if (char.ToLower(letters[0]) == 'e')
            {
                RankFile.Add(4);
            }
            else if (char.ToLower(letters[0]) == 'f')
            {
                RankFile.Add(5);
            }
            else if (char.ToLower(letters[0]) == 'g')
            {
                RankFile.Add(6);
            }
            else if (char.ToLower(letters[0]) == 'h')
            {
                RankFile.Add(7);
            }
            return RankFile;
        }
        public string RankFileToAlgebraicNotation(List<int> input)
        {
            string algnotation = "";
            if (input[1] == 0)
            {
                algnotation = algnotation + "A";
            }
            else if (input[1] == 1)
            {
                algnotation = algnotation + "B";
            }
            else if (input[1] == 2)
            {
                algnotation = algnotation + "C";
            }
            else if (input[1] == 3)
            {
                algnotation = algnotation + "D";
            }
            else if (input[1] == 4)
            {
                algnotation = algnotation + "E";
            }
            else if (input[1] == 5)
            {
                algnotation = algnotation + "F";
            }
            else if (input[1] == 6)
            {
                algnotation = algnotation + "G";
            }
            else if (input[1] == 7)
            {
                algnotation = algnotation + "H";
            }
            algnotation = algnotation + (input[0] + 1).ToString();
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
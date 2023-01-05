using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.Models
{
    public class Game
    {
        public Color CurrentTurn = Color.White;
        public List<Piece> Captured { get; set; }
        public Game() 
        { 
            Captured= new List<Piece>();
        }
        public void MovePiece(Board Board, PieceLocation PieceToMove, PieceLocation PieceDestination)
        {
            Square CurrentSquare = Board.BoardArray[PieceToMove.Rank, PieceToMove.File];
            Piece CurrentPiece = Board.BoardArray[PieceToMove.Rank, PieceToMove.File].Piece;
            Square DestinationSquare = Board.BoardArray[PieceDestination.Rank, PieceDestination.File];
            Piece AttackedPiece = null;
            if (DestinationSquare.Piece != null)
            {
                AttackedPiece = DestinationSquare.Piece;
            }

            CurrentPiece.Move(CurrentSquare, DestinationSquare, AttackedPiece, this.Captured);
        }
        public bool IsMoveablePiece(Board Board, PieceLocation PieceLocation, Color PlayersColor, List<PieceLocation> PossibleMoves)
        {
            Square MovementSquare = Board.BoardArray[PieceLocation.Rank, PieceLocation.File];
            if (MovementSquare.IsPiece())
            {
                if (MovementSquare.Piece.Color == PlayersColor)
                {
                    if (PossibleMoves != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsPieceDestinationValid(PieceLocation PieceDestination, List<PieceLocation> PossibleMoves)
        {
            if (PossibleMoves.Any(x=> x.Rank == PieceDestination.Rank && x.File == PieceDestination.File))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsCheck(Board board)
        {
            bool inCheck = false;
            Color CurrentColor = CurrentTurn;
            PieceLocation KingSquare = new PieceLocation();
            foreach (var square in board.BoardArray)
            {
                if (square.IsPiece())
                {
                    if (square.Piece.PieceType == PieceType.King & square.Piece.Color == CurrentColor)
                    {
                        KingSquare = square.Position;
                    }
                }
            }
            //run possible moves for every single piece
            List<PieceLocation> PossibleMoves = new List<PieceLocation>();
            foreach (var square in board.BoardArray)
            {
                if (square.IsPiece())
                {
                    square.Piece.CalcPossibleMoves();
                    if (square.Piece.Color != CurrentColor)
                    {
                        foreach (var possiblemove in square.Piece.PossibleMoves)
                        {
                            PossibleMoves.Add(possiblemove);
                        }
                    }
                }
            }
            //Checks all squares for whether they are attacked by opponent pieces
            foreach (var square in board.BoardArray)
            {
                if (PossibleMoves.Any(x => x.Rank == square.Position.Rank && x.File == square.Position.File))
                {
                    square.Attacked = true;
                }
                else
                {
                    square.Attacked = false;
                }
            }
            //check if king position is in possible moves for any piece
            bool KingInPossibleMoves = PossibleMoves.Any(item => item.Rank == KingSquare.Rank & item.File == KingSquare.File);
            //if so return true
            if (KingInPossibleMoves)
            {
                inCheck = true;
            }
            return inCheck;
        }
        public bool IsCheckmate(Board board, Game game, Color currentcolor)
        {
            Board BoardClone = board.Clone();
            foreach (var square in BoardClone.BoardArray)
            {
                if (square.Piece != null)
                {
                    if (square.Piece.Color == currentcolor)
                    {
                        square.Piece.CalcPossibleMoves();
                        foreach (var move in square.Piece.PossibleMoves)
                        {
                            game.MovePiece(BoardClone, square.Position, move);
                            if (!game.IsCheck(BoardClone))
                            {
                                game.MovePiece(BoardClone, move, square.Position);
                                return false;
                            }
                            else
                            {
                                game.MovePiece(BoardClone, move, square.Position);
                            }
                        }
                    }
                }
                
            }
            return true;
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
            int rank = 7;
            int file = 0;
            foreach (var letter in fen)
            {
                if (Char.IsNumber(letter))
                {
                    if (letter == '8')
                    {
                        if (rank == 0)
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
                    rank--;
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
        public List<string> GetBoard(Board board)
        {
            var boardOutput = new List<string>();
            foreach (var square in board.BoardArray)
            {
                if (square.Piece != null)
                {
                    var type = square.Piece.GetAlgNotation();
                    boardOutput.Add(type.ToString());
                }
                else
                {
                    boardOutput.Add("-");
                }
            }
            return boardOutput;
        }
        public List<string> GetBoardFen(Board board)
        {
            List<string> boardOutput = new List<string>();
            int emptySquares = 0;
            for (int i = 7; i >= 0; i--) 
            {
                for (int j = 0; j <= 7; j++)
                {
                    Square CurrentSquare = board.BoardArray[i, j];
                    if (CurrentSquare.Piece != null)
                    {
                        if (emptySquares != 0)
                        {
                            boardOutput.Add(emptySquares.ToString());
                            emptySquares = 0;
                        }
                        var type = CurrentSquare.Piece.GetAlgNotation();
                        if (CurrentSquare.Piece.Color == Color.Black)
                        {
                            boardOutput.Add(Char.ToLower(type).ToString());
                        }
                        else
                        {
                            boardOutput.Add(type.ToString());
                        }
                    }
                    else
                    {
                        emptySquares++;
                    }
                    if (j == 7)
                    {
                        if (emptySquares != 0)
                        {
                            boardOutput.Add(emptySquares.ToString());
                            emptySquares = 0;
                        }
                        if (i != 0)
                        {
                            boardOutput.Add("/");
                        }
                    }
                }
                
            }
            return boardOutput;
        }
    }
}
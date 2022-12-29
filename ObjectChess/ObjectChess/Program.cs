using ObjectChess.ConsoleApp;
using ObjectChess.Models;
using System.ComponentModel;

namespace ObjectChess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game Game = new Game();
            ConsoleInterpreter Interpreter = new ConsoleInterpreter();
            bool playing = true;
            //instantiate the board and it's squares
            string DefaultFenSetup = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
            string OtherFenSetup = "8/5k2/3p4/1p1Pp2p/pP2Pp1P/P4P1K/8/8";
            string[,] DefaultPieceSetup = new string[,] {{"r","n","b","q","k","b","n","r"},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"r","n","b","q","k","b","n","r"}};
            Board Board = Game.SetupBoard();
            Game.SetupPieces(Board, DefaultFenSetup);
            //var check = Game.GetBoard(board);
            //Console.WriteLine(Game.GetBoard(Board).ToString());
            

            while (playing)
            {
                bool turnComplete = false;
                if (Game.CurrTurn == (int)Color.White)
                {
                    while (!turnComplete)
                    {
                        Interpreter.PrintOutput(Game.GetBoard(Board));
                        Console.WriteLine("White's turn");
                        Console.WriteLine("What Piece do you want to move?");
                        List<int> pieceToMove = Game.AlgebraicNotationToRankFile(Console.ReadLine());
                        //Need to check if there is a piece there and if it is white
                        List<List<int>> possiblemoves = Game.PossibleMoves(pieceToMove, Board);
                        foreach (var position in possiblemoves)
                        {
                            Console.WriteLine(Game.RankFileToAlgebraicNotation(position));
                        }
                        Console.WriteLine("Where do you want to move it to");
                        string pieceDestination = Console.ReadLine();
                        //MovePiece();
                        turnComplete = true;
                    }
                    Game.CurrTurn = (int)Color.Black;
                }
                else
                {
                    while (!turnComplete)
                    {
                        Interpreter.PrintOutput(Game.GetBoard(Board));
                        Console.WriteLine("Black's turn");
                        Console.WriteLine("What Piece do you want to move?");
                        List<int> pieceToMove = Game.AlgebraicNotationToRankFile(Console.ReadLine());
                        //Need to check if there is a piece there and if it is black
                        //Game.PossibleMoves(pieceToMove);
                        Console.WriteLine("Where do you want to move it to");
                        string pieceDestination = Console.ReadLine();
                        //MovePiece();
                        turnComplete = true;
                    }
                    Game.CurrTurn = (int)Color.White;
                }
                //if(Game.IsCheckmate()){
                //  playing = false;
                //}
                //playing = false;
            }

        }
    }
}
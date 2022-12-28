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
            string[,] DefaultPieceSetup = new string[,] {{"r","n","b","q","k","b","n","r"},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"r","n","b","q","k","b","n","r"}};
            Board Board = Game.SetupBoard();
            Game.SetupPieces(Board, DefaultPieceSetup);
            //var check = Game.GetBoard(board);
            Console.WriteLine(Game.GetBoard(Board).ToString());
            Interpreter.PrintOutput(Game.GetBoard(Board));

            //while (playing)
            //{
            //    bool turnComplete = false;
            //    if (Game.CurrTurn == (int)Color.White)
            //    {
            //        while (!turnComplete)
            //        {
            //            //DisplayBoard();
            //            Console.WriteLine("White's turn");
            //            Console.WriteLine("What Piece do you want to move?");
            //            string pieceToMove = Console.ReadLine();
            //            //PossibleMoves();
            //            Console.WriteLine("Where do you want to move it to");
            //            string pieceDestination = Console.ReadLine();
            //            //MovePiece();
            //            turnComplete = true;
            //        }
            //        Game.CurrTurn = (int)Color.Black;
            //    }
            //    else
            //    {
            //        while (!turnComplete)
            //        {
            //            //DisplayBoard();
            //            Console.WriteLine("Black's turn");
            //            Console.WriteLine("What Piece do you want to move?");
            //            string pieceToMove = Console.ReadLine();
            //            //PossibleMoves();
            //            Console.WriteLine("Where do you want to move it to");
            //            string pieceDestination = Console.ReadLine();
            //            //MovePiece();
            //            turnComplete = true;
            //        }
            //        Game.CurrTurn = (int)Color.White;
            //    }
            //    //if(Game.IsCheckmate()){
            //    //  playing = false;
            //    //}
            //    //playing = false;
            //}

        }
    }
}
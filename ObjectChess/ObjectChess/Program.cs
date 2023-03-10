using ObjectChess.ConsoleApp;
using ObjectChess.Models;
using ObjectChess.CustomExtensions;
using System.ComponentModel;

namespace ObjectChess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game Game = new Game();
            ConsolePlayer ConsolePlayer = new ConsolePlayer();
            ConsoleInterpreter Interpreter = new ConsoleInterpreter();
            //instantiate the board and it's squares
            string DefaultFenSetup = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
            string CanCastleSetup = "r3k2r/ppppbppp/5n2/8/8/5N2/PPPPBPPP/R3K2R";
            string InCheckFenSetup = "rnb1kbnr/pppp1p1p/6p1/8/4q3/P6P/1PP2PP1/RNB1KBNR";
            string CheckmateFenSetup = "k7/8/8/8/8/8/5r2/5q1K";
            string OtherFenSetup = "8/5k2/3p4/1p1Pp2p/pP2Pp1P/P4P1K/8/8";
            string OtherOtherFenSetup = "r1b1k1nr/p2p1pNp/n2B4/1p1NP2P/6P1/3P1Q2/P1P1K3/q5b1";
            string[,] DefaultPieceSetup = new string[,] {{"r","n","b","q","k","b","n","r"},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"r","n","b","q","k","b","n","r"}};
            Board Board = Game.SetupBoard();
            Game.SetupPieces(Board, CanCastleSetup);
            Console.WriteLine();
            ConsolePlayer.GameLoop(Game, Board, Interpreter);
        }
    }
}
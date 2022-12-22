using ObjectChess.Models;
using System.ComponentModel;

namespace ObjectChess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game Game = new Game();
            bool playing = true;
            //instantiate pieces, squares, board
            while (playing)
            {
                bool turnComplete = false;
                if (Game.CurrTurn == Game.WHITE)
                {
                    while (!turnComplete)
                    {
                        //DisplayBoard();
                        Console.WriteLine("White's turn");
                        Console.WriteLine("What Piece do you want to move?");
                        string pieceToMove = Console.ReadLine();
                        //PossibleMoves();
                        Console.WriteLine("Where do you want to move it to");
                        string pieceDestination = Console.ReadLine();
                        //MovePiece();
                        turnComplete = true;
                    }
                    Game.CurrTurn = Game.BLACK;
                }
                else
                {
                    while (!turnComplete)
                    {
                        //DisplayBoard();
                        Console.WriteLine("Black's turn");
                        Console.WriteLine("What Piece do you want to move?");
                        string pieceToMove = Console.ReadLine();
                        //PossibleMoves();
                        Console.WriteLine("Where do you want to move it to");
                        string pieceDestination = Console.ReadLine();
                        //MovePiece();
                        turnComplete = true;
                    }
                    Game.CurrTurn = Game.WHITE;
                }
                //if(Game.IsCheckmate()){
                //  playing = false;
                //}
                //playing = false;
            }

        }
    }
}
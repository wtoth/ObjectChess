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
            //instantiate the board and it's squares
            Board board = Game.SetupBoard();
            Game.SetupPieces(board);
            Game.GetBoard(board).ForEach(x=>Console.WriteLine(x));

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
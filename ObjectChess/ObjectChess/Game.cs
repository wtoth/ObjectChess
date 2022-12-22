using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess
{
    internal class Game
    {
        const int WHITE = 0;
        const int BLACK = 1;
        int CurrTurn = WHITE;
        public void StartGame()
        {
            bool playing = true;
            
            //instantiate pieces, squares, board
            while (playing)
            {
                Turn();
                //if(Checkmate()){
                //  playing = false;
                //}
                //playing = false;
            }
        }
        public void Turn()
        {
            int nextTurn;
            bool turnComplete = false;
            if (CurrTurn == WHITE)
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
                CurrTurn = BLACK;
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
                    turnComplete= true;
                }
                CurrTurn = WHITE;
            }
        }

    }
}

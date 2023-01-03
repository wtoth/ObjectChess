using ObjectChess.CustomExtensions;
using ObjectChess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.ConsoleApp
{
    public class ConsolePlayer
    {
        public void GameLoop(Game Game, Board Board, ConsoleInterpreter Interpreter)
        {
            bool playing = true;
            while (playing)
            {
                bool turnComplete = false;
                if (Game.CurrentTurn == Color.White)
                {
                    bool InCheck = Game.IsCheck(Board);
                    while (!turnComplete)
                    {
                        //Interpreter.PrintOutput(Game.GetBoard(Board));
                        Interpreter.PrintFenOutput(Game.GetBoardFen(Board));
                        Console.WriteLine("White's turn");
                        Console.WriteLine("What Piece do you want to move?");
                        PieceLocation PieceToMove = Console.ReadLine().AlgebraicNotationToRankFile();
                        //Need to check if there is a piece there and if it is white
                        List<PieceLocation> PossibleMoves = Game.PossibleMoves(PieceToMove, Board);
                        if (!Game.IsMoveablePiece(Board, PieceToMove, Game.CurrentTurn, PossibleMoves))
                        {
                            Console.WriteLine("This does not appear to be a moveable piece. Please try again.");
                            continue;
                        }
                        Console.WriteLine("Possible Moves for this piece are");
                        foreach (var position in PossibleMoves)
                        {
                            Console.WriteLine(position.RankFileToAlgebraicNotation());
                        }
                        Console.WriteLine("Where do you want to move it to");
                        string PieceDestination = Console.ReadLine();
                        if (!Game.IsPieceDestinationValid(PieceDestination.AlgebraicNotationToRankFile(), PossibleMoves))
                        {
                            Console.WriteLine("Sorry you can't move your piece there. Please try again.");
                            continue;
                        }
                        Game.MovePiece(Board, PieceToMove, PieceDestination.AlgebraicNotationToRankFile());
                        turnComplete = true;
                    }
                    Game.CurrentTurn = Color.Black;
                }
                else
                {
                    bool InCheck = Game.IsCheck(Board);
                    while (!turnComplete)
                    {
                        Interpreter.PrintOutput(Game.GetBoard(Board));
                        Console.WriteLine("Black's turn");
                        Console.WriteLine("What Piece do you want to move?");
                        PieceLocation PieceToMove = Console.ReadLine().AlgebraicNotationToRankFile();
                        //Need to check if there is a piece there and if it is black
                        List<PieceLocation> PossibleMoves = Game.PossibleMoves(PieceToMove, Board);
                        if (!Game.IsMoveablePiece(Board, PieceToMove, Game.CurrentTurn, PossibleMoves))
                        {
                            Console.WriteLine("This does not appear to be a moveable piece. Please try again.");
                            continue;
                        }
                        Console.WriteLine("Possible Moves for this piece are");
                        foreach (var position in PossibleMoves)
                        {
                            Console.WriteLine(position.RankFileToAlgebraicNotation());
                        }
                        Console.WriteLine("Where do you want to move it to");
                        string PieceDestination = Console.ReadLine();
                        if (!Game.IsPieceDestinationValid(PieceDestination.AlgebraicNotationToRankFile(), PossibleMoves))
                        {
                            Console.WriteLine("Sorry you can't move your piece there. Please try again.");
                            continue;
                        }
                        Game.MovePiece(Board, PieceToMove, PieceDestination.AlgebraicNotationToRankFile());
                        turnComplete = true;
                    }
                    Game.CurrentTurn = Color.White;
                }
            }
            //if(Game.IsCheckmate()){
            //  playing = false;
            //}
            //playing = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectChess.Models;
using ObjectChess.ConsoleApp;

namespace ObjectChess.Test
{
    public class IllegalMoves
    {
        //revisit this and see if we can catch the error that illegal moves should throw
        //Looking into Assert.Throw<Expected Exception> for most of these as I am attempting to catch the correct error here
        [Fact]
        public void JumpingPawns()
        {
            Game Game = new Game();
            Board Board = Game.SetupBoard();
            string[,] PieceSetup = new string[,] {{"r","n","b","q","k","b","n","r"},
                                                  {"p","p","p","p","p","p","p","p"},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"p","p","p","p","p","p","p","p"},
                                                  {"r","n","b","q","k","b","n","r"}};
            Game.SetupPieces(Board, PieceSetup);
            //Game.Move("A1", "A3");
            //Game.Move("C1", "A3");
            //Game.Move("D1", "D3");
            //Game.Move("E1", "E3");
            //Game.Move("F1", "H3");
            //Game.Move("H1", "H3");

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"r","n","b","q","k","b","n","r"},
                                                         {"p","p","p","p","p","p","p","p"},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"p","p","p","p","p","p","p","p"},
                                                         {"r","n","b","q","k","b","n","r"}};
            CorrectGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(Game.GetBoard(Board), CorrectGame.GetBoard(CorrectBoard));
        }
        [Fact]
        public void OutOfBounds()
        {
            Game Game = new Game();
            Board Board = Game.SetupBoard();
            string[,] PieceSetup = new string[,] {{"r","n","b","q","k","b","n","r"},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""}};
            Game.SetupPieces(Board, PieceSetup);
            //Game.Move("A1", "A9");
            //Game.Move("G1", "I2");
            //Game.Move("D1", "D9");
            //Game.Move("E1", "E0");
            //Game.Move("F1", "I4");

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"r","n","b","q","k","b","n","r"},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""}};
            CorrectGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(Game.GetBoard(Board), CorrectGame.GetBoard(CorrectBoard));
        }
    }
}

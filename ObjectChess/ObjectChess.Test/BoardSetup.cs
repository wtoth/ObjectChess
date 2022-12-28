using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectChess.Models;
using ObjectChess.ConsoleApp;

namespace ObjectChess.Test
{
    public class BoardSetup
    {
        [Fact]
        public void GetBoardTest()
        {
            Game Game = new Game();
            Board Board = Game.SetupBoard();
            string[,] PieceSetup = new string[,] {{"r","n","b","q","k","","",""},
                                                 {"p","","","","","","",""},
                                                 {"p","","","","","","",""},
                                                 {"p","","","","","","",""},
                                                 {"p","","","","","","",""},
                                                 {"p","","","","","","",""},
                                                 {"p","","","","","","",""},
                                                 {"p","","","","","","",""}};
            Game.SetupPieces(Board, PieceSetup);
            List<string> correctGetBoard = new List<string>() { "R", "N", "B", "Q", "K", "-", "-", "-",
                                                                "P", "-", "-", "-", "-", "-", "-", "-",
                                                                "P", "-", "-", "-", "-", "-", "-", "-",
                                                                "P", "-", "-", "-", "-", "-", "-", "-",
                                                                "P", "-", "-", "-", "-", "-", "-", "-",
                                                                "P", "-", "-", "-", "-", "-", "-", "-",
                                                                "P", "-", "-", "-", "-", "-", "-", "-",
                                                                "P", "-", "-", "-", "-", "-", "-", "-"};
            Assert.Equal(Game.GetBoard(Board), correctGetBoard);
        }
    }
}

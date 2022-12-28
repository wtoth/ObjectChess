using ObjectChess.Models;
using ObjectChess.ConsoleApp;

namespace ObjectChess.Test
{
    public class Movement
    {
        [Fact]
        public void BasicTest()
        {
            Assert.Equal(1, 1);
        }
        [Fact]
        public void PawnMove()
        {
            Game PawnGame = new Game();
            Board Board = PawnGame.SetupBoard();
            string[,] PieceSetup = new string[,] {{"r","n","b","q","k","b","n","r"},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"r","n","b","q","k","b","n","r"}};
            PawnGame.SetupPieces(Board, PieceSetup);
            PawnGame.Move("A2", "A3");

            Game CorrectPawnGame = new Game();
            Board CorrectBoard = CorrectPawnGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"r","n","b","q","k","b","n","r"},
                                                 {"","p","p","p","p","p","p","p"},
                                                 {"p","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"r","n","b","q","k","b","n","r"}};
            CorrectPawnGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(PawnGame.GetBoard(Board), CorrectPawnGame.GetBoard(CorrectBoard));
        }
        [Fact]
        public void HorizontalMoveLeft()
        {
            throw new NotImplementedException("Not fully implemented.");
        }
        [Fact]
        public void HorizontalMoveRight()
        {
            throw new NotImplementedException("Not fully implemented.");
        }
        [Fact]
        public void VerticalMoveLeft()
        {
            throw new NotImplementedException("Not fully implemented.");
        }
        [Fact]
        public void VerticalMoveRight()
        {
            throw new NotImplementedException("Not fully implemented.");
        }
        [Fact]
        public void KnightMoveUpRight()
        {
            throw new NotImplementedException("Not fully implemented.");
        }
        [Fact]
        public void KnightMoveUpLeft()
        {
            throw new NotImplementedException("Not fully implemented.");
        }
        [Fact]
        public void KnightMoveDownRight()
        {
            throw new NotImplementedException("Not fully implemented.");
        }
        [Fact]
        public void KnightMoveDownLeft()
        {
            throw new NotImplementedException("Not fully implemented.");
        }
    }
}
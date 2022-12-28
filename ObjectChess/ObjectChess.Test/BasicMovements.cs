using ObjectChess.Models;
using ObjectChess.ConsoleApp;

namespace ObjectChess.Test
{
    public class BasicMovements
    {
        [Fact]
        public void BasicTest()
        {
            Assert.Equal(1, 1);
        }
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
            //PawnGame.Move("A2","A3");
            //PawnGame.Move("D7","D5");

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
            Game Game = new Game();
            Board Board = Game.SetupBoard();
            string[,] PieceSetup = new string[,] {{"","","","","","","","k"},
                                                  {"","","","","","","","q"},
                                                  {"","","","","","","","r"},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""}};
            Game.SetupPieces(Board, PieceSetup);
            //Game.Move("H1", "G1");
            //Game.Move("H2","F2");
            //Game.Move("H3","E3");

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"","","","","","","k",""},
                                                         {"","","","","","q","",""},
                                                         {"","","","","r","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""}};
            CorrectGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(Game.GetBoard(Board), CorrectGame.GetBoard(CorrectBoard));
        }
        [Fact]
        public void HorizontalMoveRight()
        {
            Game Game = new Game();
            Board Board = Game.SetupBoard();
            string[,] PieceSetup = new string[,] {{"k","","","","","","",""},
                                                  {"q","","","","","","",""},
                                                  {"r","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""}};
            Game.SetupPieces(Board, PieceSetup);
            //Game.Move("A1", "B1");
            //Game.Move("A2","C2");
            //Game.Move("A3","D3");

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"","k","","","","","",""},
                                                         {"","","q","","","","",""},
                                                         {"","","","r","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""}};
            CorrectGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(Game.GetBoard(Board), CorrectGame.GetBoard(CorrectBoard));
        }
        [Fact]
        public void VerticalMoveDown()
        {
            Game Game = new Game();
            Board Board = Game.SetupBoard();
            string[,] PieceSetup = new string[,] {{"k","q","r","","","","",""},
                                                  {"","","","","p","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""}};
            Game.SetupPieces(Board, PieceSetup);
            //Game.Move("A1", "A2");
            //Game.Move("B1","B3");
            //Game.Move("C1","C8");
            //Game.Move("D2","D4");

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"","","","","","","",""},
                                                         {"k","","","","","","",""},
                                                         {"","q","","","","","",""},
                                                         {"","","","p","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","r","","","","",""}};
            CorrectGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(Game.GetBoard(Board), CorrectGame.GetBoard(CorrectBoard));
        }
        [Fact]
        public void VerticalMoveUp()
        {
            Game Game = new Game();
            Board Board = Game.SetupBoard();
            string[,] PieceSetup = new string[,] {{"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","p","","",""},
                                                  {"k","q","r","","","","",""}};
            Game.SetupPieces(Board, PieceSetup);
            //Game.Move("A8", "A7");
            //Game.Move("B8","B6");
            //Game.Move("C8","C1");
            //Game.Move("D7","D5");

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"","","r","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","p","","",""},
                                                         {"","q","","","","","",""},
                                                         {"k","","","","","","",""},
                                                         {"","","","","","","",""}};
            CorrectGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(Game.GetBoard(Board), CorrectGame.GetBoard(CorrectBoard));
        }
        [Fact]
        public void DiagonalMoveUpLeft()
        {
            Game Game = new Game();
            Board Board = Game.SetupBoard();
            string[,] PieceSetup = new string[,] {{"","","","","","","","k"},
                                                  {"","","","","","","","q"},
                                                  {"","","","","","","","r"},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","k","q","b"}};
            Game.SetupPieces(Board, PieceSetup);
            //Game.Move("H8", "A1");
            //Game.Move("G8","A2");
            //Game.Move("F8","E7");

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"b","","","","","","",""},
                                                         {"q","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","k","","",""},
                                                         {"","","","","","","",""}};
            CorrectGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(Game.GetBoard(Board), CorrectGame.GetBoard(CorrectBoard));
        }
        [Fact]
        public void DiagonalMoveUpRight()
        {
            Game Game = new Game();
            Board Board = Game.SetupBoard();
            string[,] PieceSetup = new string[,] {{"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"b","q","k","","","","",""}};
            Game.SetupPieces(Board, PieceSetup);
            //Game.Move("A8", "H1");
            //Game.Move("B8","H2");
            //Game.Move("C8","D7");

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"","","","","","","","b"},
                                                         {"","","","","","","","q"},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","k","","","",""},
                                                         {"","","","","","","",""}};
            CorrectGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(Game.GetBoard(Board), CorrectGame.GetBoard(CorrectBoard));
        }
        [Fact]
        public void DiagonalMoveDownLeft()
        {
            Game Game = new Game();
            Board Board = Game.SetupBoard();
            string[,] PieceSetup = new string[,] {{"","","","","","","","b"},
                                                  {"","","","","","","","q"},
                                                  {"","","","","","","","k"},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""}};
            Game.SetupPieces(Board, PieceSetup);
            //Game.Move("H1", "A8");
            //Game.Move("H2","B8");
            //Game.Move("H3","G4");

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","k",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"b","q","","","","","",""}};
            CorrectGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(Game.GetBoard(Board), CorrectGame.GetBoard(CorrectBoard));
        }
        [Fact]
        public void DiagonalMoveDownRight()
        {
            Game Game = new Game();
            Board Board = Game.SetupBoard();
            string[,] PieceSetup = new string[,] {{"b","","","","","","",""},
                                                  {"q","","","","","","",""},
                                                  {"k","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""}};
            Game.SetupPieces(Board, PieceSetup);
            //Game.Move("A1", "H8");
            //Game.Move("A2","G8");
            //Game.Move("A3","B4");

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","k","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","q","b"}};
            CorrectGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(Game.GetBoard(Board), CorrectGame.GetBoard(CorrectBoard));
        }
        [Fact]
        public void KnightMoveUpRight()
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
            //Game.Move("B7", "C5");

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"r","n","b","q","k","b","n","r"},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","n","","","","",""},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"r","","b","q","k","b","n","r"}};
            CorrectGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(Game.GetBoard(Board), CorrectGame.GetBoard(CorrectBoard));
        }
        [Fact]
        public void KnightMoveUpLeft()
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
            //Game.Move("G7", "F5");

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"r","n","b","q","k","b","n","r"},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","n","",""},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"r","n","b","q","k","b","","r"}};
            CorrectGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(Game.GetBoard(Board), CorrectGame.GetBoard(CorrectBoard));
        }
        [Fact]
        public void KnightMoveDownRight()
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
            //Game.Move("B1", "C3");

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"r","","b","q","k","b","n","r"},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"","","n","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"r","n","b","q","k","b","n","r"}};
            CorrectGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(Game.GetBoard(Board), CorrectGame.GetBoard(CorrectBoard));
        }
        [Fact]
        public void KnightMoveDownLeft()
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
            //Game.Move("G1", "F3");

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"r","n","b","q","k","b","","r"},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"","","","","","n","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"","","","","","","",""},
                                                 {"p","p","p","p","p","p","p","p"},
                                                 {"r","n","b","q","k","b","n","r"}};
            CorrectGame.SetupPieces(CorrectBoard, CorrectPieceSetup);

            Assert.Equal(Game.GetBoard(Board), CorrectGame.GetBoard(CorrectBoard));
        }
    }
}
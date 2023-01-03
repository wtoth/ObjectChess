using ObjectChess.Models;
using ObjectChess.ConsoleApp;
using ObjectChess.CustomExtensions;

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
            PawnGame.MovePiece(Board, "A2".AlgebraicNotationToRankFile(),"A3".AlgebraicNotationToRankFile());

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
            Game.MovePiece(Board, "H1".AlgebraicNotationToRankFile(), "G1".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "H2".AlgebraicNotationToRankFile(), "F2".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "H3".AlgebraicNotationToRankFile(), "E3".AlgebraicNotationToRankFile());

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
            Game.MovePiece(Board, "A1".AlgebraicNotationToRankFile(), "B1".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "A2".AlgebraicNotationToRankFile(), "C2".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "A3".AlgebraicNotationToRankFile(), "D3".AlgebraicNotationToRankFile());

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
                                                  {"","","","p","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""}};
            Game.SetupPieces(Board, PieceSetup);
            Game.MovePiece(Board, "A1".AlgebraicNotationToRankFile(), "A2".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "B1".AlgebraicNotationToRankFile(), "B3".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "C1".AlgebraicNotationToRankFile(), "C8".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "D2".AlgebraicNotationToRankFile(), "D4".AlgebraicNotationToRankFile());

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
                                                  {"","","","p","","","",""},
                                                  {"k","q","r","","","","",""}};
            Game.SetupPieces(Board, PieceSetup);
            Game.MovePiece(Board, "A8".AlgebraicNotationToRankFile(), "A7".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "B8".AlgebraicNotationToRankFile(), "B6".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "C8".AlgebraicNotationToRankFile(), "C1".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "D7".AlgebraicNotationToRankFile(), "D5".AlgebraicNotationToRankFile());

            Game CorrectGame = new Game();
            Board CorrectBoard = CorrectGame.SetupBoard();
            string[,] CorrectPieceSetup = new string[,] {{"","","r","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","","","","",""},
                                                         {"","","","p","","","",""},
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
            string[,] PieceSetup = new string[,] {{"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","","",""},
                                                  {"","","","","","k","q","b"}};
            Game.SetupPieces(Board, PieceSetup);
            Game.MovePiece(Board, "H8".AlgebraicNotationToRankFile(), "A1".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "G8".AlgebraicNotationToRankFile(), "A2".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "F8".AlgebraicNotationToRankFile(), "E7".AlgebraicNotationToRankFile());

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
            Game.MovePiece(Board, "A8".AlgebraicNotationToRankFile(), "H1".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "B8".AlgebraicNotationToRankFile(), "H2".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "C8".AlgebraicNotationToRankFile(), "D7".AlgebraicNotationToRankFile());

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
            Game.MovePiece(Board, "H1".AlgebraicNotationToRankFile(), "A8".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "H2".AlgebraicNotationToRankFile(), "B8".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "H3".AlgebraicNotationToRankFile(), "G4".AlgebraicNotationToRankFile());

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
            Game.MovePiece(Board, "A1".AlgebraicNotationToRankFile(), "H8".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "A2".AlgebraicNotationToRankFile(), "G8".AlgebraicNotationToRankFile());
            Game.MovePiece(Board, "A3".AlgebraicNotationToRankFile(), "B4".AlgebraicNotationToRankFile());

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
            Game.MovePiece(Board, "B8".AlgebraicNotationToRankFile(), "C6".AlgebraicNotationToRankFile());

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
            Game.MovePiece(Board, "G8".AlgebraicNotationToRankFile(), "F6".AlgebraicNotationToRankFile());

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
            Game.MovePiece(Board, "B1".AlgebraicNotationToRankFile(), "C3".AlgebraicNotationToRankFile());

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
            Game.MovePiece(Board, "G1".AlgebraicNotationToRankFile(), "F3".AlgebraicNotationToRankFile());

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
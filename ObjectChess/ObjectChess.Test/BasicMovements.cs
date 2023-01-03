using ObjectChess.Models;
using ObjectChess.ConsoleApp;
using ObjectChess.CustomExtensions;
using System.Xml.Linq;

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
            List<PieceLocation> PossibleMoves = PawnGame.PossibleMoves("A2".AlgebraicNotationToRankFile(), Board);
            if (PawnGame.IsPieceDestinationValid("A3".AlgebraicNotationToRankFile(), PossibleMoves))
            {
                PawnGame.MovePiece(Board, "A2".AlgebraicNotationToRankFile(), "A3".AlgebraicNotationToRankFile());
            }
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

            List<PieceLocation> PossibleMoves = Game.PossibleMoves("H1".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("G1".AlgebraicNotationToRankFile(), PossibleMoves))
            {
                Game.MovePiece(Board, "H1".AlgebraicNotationToRankFile(), "G1".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves2 = Game.PossibleMoves("H2".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("F2".AlgebraicNotationToRankFile(), PossibleMoves2))
            {
                Game.MovePiece(Board, "H2".AlgebraicNotationToRankFile(), "F2".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves3 = Game.PossibleMoves("H3".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("E3".AlgebraicNotationToRankFile(), PossibleMoves3))
            {
                Game.MovePiece(Board, "H3".AlgebraicNotationToRankFile(), "E3".AlgebraicNotationToRankFile());
            }
            

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
            List<PieceLocation> PossibleMoves = Game.PossibleMoves("A1".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("B1".AlgebraicNotationToRankFile(), PossibleMoves))
            {
                Game.MovePiece(Board, "A1".AlgebraicNotationToRankFile(), "B1".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves2 = Game.PossibleMoves("A2".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("C2".AlgebraicNotationToRankFile(), PossibleMoves2))
            {
                Game.MovePiece(Board, "A2".AlgebraicNotationToRankFile(), "C2".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves3 = Game.PossibleMoves("A3".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("D3".AlgebraicNotationToRankFile(), PossibleMoves3))
            {
                Game.MovePiece(Board, "A3".AlgebraicNotationToRankFile(), "D3".AlgebraicNotationToRankFile());
            }
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
            List<PieceLocation> PossibleMoves = Game.PossibleMoves("A1".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("A2".AlgebraicNotationToRankFile(), PossibleMoves))
            {
                Game.MovePiece(Board, "A1".AlgebraicNotationToRankFile(), "A2".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves2 = Game.PossibleMoves("B1".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("B3".AlgebraicNotationToRankFile(), PossibleMoves2))
            {
                Game.MovePiece(Board, "B1".AlgebraicNotationToRankFile(), "B3".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves3 = Game.PossibleMoves("C1".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("C8".AlgebraicNotationToRankFile(), PossibleMoves3))
            {
                Game.MovePiece(Board, "C1".AlgebraicNotationToRankFile(), "C8".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves4 = Game.PossibleMoves("D2".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("D4".AlgebraicNotationToRankFile(), PossibleMoves4))
            {
                Game.MovePiece(Board, "D2".AlgebraicNotationToRankFile(), "D4".AlgebraicNotationToRankFile());
            }
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

            List<PieceLocation> PossibleMoves = Game.PossibleMoves("A8".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("A7".AlgebraicNotationToRankFile(), PossibleMoves))
            {
                Game.MovePiece(Board, "A8".AlgebraicNotationToRankFile(), "A7".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves2 = Game.PossibleMoves("B8".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("B6".AlgebraicNotationToRankFile(), PossibleMoves2))
            {
                Game.MovePiece(Board, "B8".AlgebraicNotationToRankFile(), "B6".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves3 = Game.PossibleMoves("C8".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("C1".AlgebraicNotationToRankFile(), PossibleMoves3))
            {
                Game.MovePiece(Board, "C8".AlgebraicNotationToRankFile(), "C1".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves4 = Game.PossibleMoves("D7".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("D5".AlgebraicNotationToRankFile(), PossibleMoves4))
            {
                Game.MovePiece(Board, "D7".AlgebraicNotationToRankFile(), "D5".AlgebraicNotationToRankFile());
            }
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
            List<PieceLocation> PossibleMoves = Game.PossibleMoves("H8".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("A1".AlgebraicNotationToRankFile(), PossibleMoves))
            {
                Game.MovePiece(Board, "H8".AlgebraicNotationToRankFile(), "A1".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves2 = Game.PossibleMoves("G8".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("A2".AlgebraicNotationToRankFile(), PossibleMoves2))
            {
                Game.MovePiece(Board, "G8".AlgebraicNotationToRankFile(), "A2".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves3 = Game.PossibleMoves("F8".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("E7".AlgebraicNotationToRankFile(), PossibleMoves3))
            {
                Game.MovePiece(Board, "F8".AlgebraicNotationToRankFile(), "E7".AlgebraicNotationToRankFile());
            }

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
            List<PieceLocation> PossibleMoves = Game.PossibleMoves("A8".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("H1".AlgebraicNotationToRankFile(), PossibleMoves))
            {
                Game.MovePiece(Board, "A8".AlgebraicNotationToRankFile(), "H1".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves2 = Game.PossibleMoves("B8".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("H2".AlgebraicNotationToRankFile(), PossibleMoves2))
            {
                Game.MovePiece(Board, "B8".AlgebraicNotationToRankFile(), "H2".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves3 = Game.PossibleMoves("C8".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("D7".AlgebraicNotationToRankFile(), PossibleMoves3))
            {
                Game.MovePiece(Board, "C8".AlgebraicNotationToRankFile(), "D7".AlgebraicNotationToRankFile());
            }
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
            List<PieceLocation> PossibleMoves = Game.PossibleMoves("H1".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("A8".AlgebraicNotationToRankFile(), PossibleMoves))
            {
                Game.MovePiece(Board, "H1".AlgebraicNotationToRankFile(), "A8".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves2 = Game.PossibleMoves("H2".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("B8".AlgebraicNotationToRankFile(), PossibleMoves2))
            {
                Game.MovePiece(Board, "H2".AlgebraicNotationToRankFile(), "B8".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves3 = Game.PossibleMoves("H3".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("G4".AlgebraicNotationToRankFile(), PossibleMoves3))
            {
                Game.MovePiece(Board, "H3".AlgebraicNotationToRankFile(), "G4".AlgebraicNotationToRankFile());
            }

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
            List<PieceLocation> PossibleMoves = Game.PossibleMoves("A1".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("H8".AlgebraicNotationToRankFile(), PossibleMoves))
            {
                Game.MovePiece(Board, "A1".AlgebraicNotationToRankFile(), "H8".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves2 = Game.PossibleMoves("A2".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("G8".AlgebraicNotationToRankFile(), PossibleMoves2))
            {
                Game.MovePiece(Board, "A2".AlgebraicNotationToRankFile(), "G8".AlgebraicNotationToRankFile());
            }
            List<PieceLocation> PossibleMoves3 = Game.PossibleMoves("A3".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("B4".AlgebraicNotationToRankFile(), PossibleMoves3))
            {
                Game.MovePiece(Board, "A3".AlgebraicNotationToRankFile(), "B4".AlgebraicNotationToRankFile());
            }

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
            List<PieceLocation> PossibleMoves = Game.PossibleMoves("B8".AlgebraicNotationToRankFile(), Board);
            if(Game.IsPieceDestinationValid("C6".AlgebraicNotationToRankFile(), PossibleMoves))
            {
                Game.MovePiece(Board, "B8".AlgebraicNotationToRankFile(), "C6".AlgebraicNotationToRankFile());
            }
        
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
            List<PieceLocation> PossibleMoves = Game.PossibleMoves("G8".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("F6".AlgebraicNotationToRankFile(), PossibleMoves))
            {
                Game.MovePiece(Board, "G8".AlgebraicNotationToRankFile(), "F6".AlgebraicNotationToRankFile());
            } 

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
            List<PieceLocation> PossibleMoves = Game.PossibleMoves("B1".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("C3".AlgebraicNotationToRankFile(), PossibleMoves))
            {
                Game.MovePiece(Board, "B1".AlgebraicNotationToRankFile(), "C3".AlgebraicNotationToRankFile());
            }

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
            List<PieceLocation> PossibleMoves = Game.PossibleMoves("G1".AlgebraicNotationToRankFile(), Board);
            if (Game.IsPieceDestinationValid("F3".AlgebraicNotationToRankFile(), PossibleMoves))
            {
                Game.MovePiece(Board, "G1".AlgebraicNotationToRankFile(), "F3".AlgebraicNotationToRankFile());
            }

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
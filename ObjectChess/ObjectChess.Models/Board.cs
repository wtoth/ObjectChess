using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.Models
{
    public class Board
    {
        public Square[,] BoardArray = new Square[8,8];

        public Board()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PieceLocation position = new PieceLocation( i, j );
                    BoardArray[i, j] = new Square(position, false);
                }
            }

        }
        public Square GetSquare(PieceLocation RankFile)
        {
            return this.BoardArray[RankFile.Rank, RankFile.File];
        }
        public bool IsCheckMate()
        {
            throw new System.NotImplementedException();
        }

        public void MovePatterns()
        {
            throw new System.NotImplementedException();
        }

        public void CanCastle()
        {
            throw new System.NotImplementedException();
        }
    }
}

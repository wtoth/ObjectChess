using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.Models
{
    public class Game
    {
        public const int WHITE = 0;
        public const int BLACK = 1;
        public int CurrTurn = WHITE;

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public void IsCheck()
        {
            throw new System.NotImplementedException();
        }

        public void IsCheckmate()
        {
            throw new System.NotImplementedException();
        }

        public void GetBoard()
        {
            throw new System.NotImplementedException();
        }

        public void PossibleMoves()
        {
            throw new System.NotImplementedException();
        }

        public void SetupBoard()
        {
            throw new System.NotImplementedException();
        }

        public List<int> AlgebraicNotationToRankFile()
        {
            throw new System.NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.Models
{
    internal class Board
    {
        public List<Square> BoardList
        {
            get => default;
            set
            {
            }
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

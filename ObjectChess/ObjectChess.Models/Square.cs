using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.Models
{
    internal class Square
    {
        public List<int> Position
        {
            get => default;
            set
            {
            }
        }

        public Piece Piece
        {
            get => default;
            set
            {
            }
        }

        public bool Attacked
        {
            get => default;
            set
            {
            }
        }

        public bool SquareAttacked()
        {
            throw new System.NotImplementedException();
        }

        public bool IsCheck()
        {
            throw new System.NotImplementedException();
        }
    }
}

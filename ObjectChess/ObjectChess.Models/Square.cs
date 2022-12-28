using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.Models
{
    public class Square
    {
        public List<int> Position { get; set; }
        public Piece Piece { get; set; }
        public bool Attacked { get; set; }
        public Square(List<int> position, bool attacked = false) 
        { 
            this.Position = position;
            this.Attacked= attacked;
        }
        public bool SquareAttacked()
        {
            throw new System.NotImplementedException();
        }
        public bool IsCheck()
        {
            throw new System.NotImplementedException();
        }
        public bool IsPiece()
        {
            throw new System.NotImplementedException();
        }
    }
}

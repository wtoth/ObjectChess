using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectChess.Models
{
    public class PieceLocation
    {
        public int Rank { get; set;}
        public int File { get; set; }
        public PieceLocation() { }
        public PieceLocation(int rank, int file)
        {
            Rank = rank;
            File = file;
        }
    }
}
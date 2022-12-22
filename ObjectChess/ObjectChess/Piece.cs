using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess
{
    internal class Piece
    {
        char pieceType { get; set; }
        int color { get; set; }
        bool alive { get; set; }
        Piece(char pieceType , int pieceColor)
        {
            this.pieceType = pieceType;
            color = pieceColor;
            alive = true;
        }
        
    }
}

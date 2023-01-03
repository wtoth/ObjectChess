using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectChess.Models;

namespace ObjectChess.CustomExtensions
{
    public static class PieceLocationExtensions
    {
        public static string RankFileToAlgebraicNotation(this PieceLocation rankfile)
        {
            string algnotation = "";
            if (rankfile.File == 0)
            {
                algnotation = algnotation + "A";
            }
            else if (rankfile.File == 1)
            {
                algnotation = algnotation + "B";
            }
            else if (rankfile.File == 2)
            {
                algnotation = algnotation + "C";
            }
            else if (rankfile.File == 3)
            {
                algnotation = algnotation + "D";
            }
            else if (rankfile.File == 4)
            {
                algnotation = algnotation + "E";
            }
            else if (rankfile.File == 5)
            {
                algnotation = algnotation + "F";
            }
            else if (rankfile.File == 6)
            {
                algnotation = algnotation + "G";
            }
            else if (rankfile.File == 7)
            {
                algnotation = algnotation + "H";
            }
            algnotation = algnotation + (rankfile.Rank + 1).ToString();
            return algnotation;
        }
    }
}

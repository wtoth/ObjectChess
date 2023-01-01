using ObjectChess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess.ConsoleApp
{
    public class ConsoleInterpreter
    {
        public ConsoleInterpreter() { }
        public void PrintOutput(List<string> boardOutput)
        {
            string output = "";
            int i = 1;
            int j = 1;
            output = output + j.ToString() + " ";
            j++;
            foreach (var piece in boardOutput)
            {
                output = output + piece + " ";
                if (i%8 == 0)
                {
                    output = output + "\n";
                    output = output + j.ToString() + " ";
                    j++;
                }
                i++;
            }
            Console.WriteLine("\n  A B C D E F G H");
            Console.WriteLine(output);
        }
        public void PrintPossibleMoves(List<List<int>> PossibleMoves)
        {
            Console.WriteLine("Possible Moves for this piece are");
            foreach (var position in PossibleMoves)
            {
                //Console.WriteLine(Game.RankFileToAlgebraicNotation(position));
            }
        }
    }
}

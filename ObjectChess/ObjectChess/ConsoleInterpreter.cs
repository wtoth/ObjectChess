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
            foreach (var piece in boardOutput)
            {
                output = output + piece + " ";
                if (i%8 == 0)
                {
                    output = output + "\n";
                }
                i++;
            }
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

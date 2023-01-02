using ObjectChess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
                    if (j < 9)
                    {
                        output = output + "\n";
                        output = output + j.ToString() + " "; 
                    }
                    j++;
                }
                i++;
            }
            Console.WriteLine(output);
            Console.WriteLine("  A B C D E F G H");
        }
        //Doesn't work yet
        public void PrintWhiteOutput(List<string> boardOutput)
        {
            string output = "";
            int i = 1;
            int j = 8;
            output = output + j.ToString() + " ";
            j--;
            boardOutput.Reverse();
            foreach (var piece in boardOutput)
            {
                output = output + piece + " ";
                if (i % 8 == 0)
                {
                    output = output + "\n";
                    if (j > 0)
                    {
                        output = output + j.ToString() + " ";
                    }
                    j--;
                }
                i++;
            }
            Console.WriteLine(output);
            Console.WriteLine("\n  A B C D E F G H");
        }
        public void PrintFenOutput(List<string> Fen)
        {
            string output = "";
            int Rank = 8;
            output = output + Rank.ToString() + " ";
            Rank--;
            foreach (var piece in Fen)
            {
                char charPiece = piece.ToCharArray()[0];
                if (char.IsLetter(charPiece))
                {
                    output = output + char.ToUpper(charPiece).ToString() + " ";
                }
                else if (charPiece == '/')
                {
                    output = output + "\n";
                    if (Rank > 0)
                    {
                        output = output + Rank.ToString() + " ";
                        Rank--;
                    }
                }
                else if (char.IsNumber(charPiece))
                {
                    string spaces = String.Concat(Enumerable.Repeat("- ", (int)char.GetNumericValue(charPiece)));
                    output = output + spaces;
                }
            }
            Console.WriteLine(output);
            Console.WriteLine("  A B C D E F G H");
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

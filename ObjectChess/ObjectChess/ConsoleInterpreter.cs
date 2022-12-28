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
    }
}

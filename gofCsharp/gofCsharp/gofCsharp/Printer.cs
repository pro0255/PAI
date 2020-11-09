using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gofCsharp
{
    public class Printer : IPrinter
    {

        private char TrueCell;
        private char FalseCell;
        public Printer()
        {
            TrueCell = '*';
            FalseCell = '.';
        }

        public void PrintHeader(Board pop)
        {
            Console.WriteLine("=================================");
            Console.WriteLine(($"================{pop.BoardIndex}================"));
            Console.WriteLine("=================================\n");
        }

        public void PrintFooter()
        {
            Console.WriteLine("\n=================================");
        }


        public void Print(Board pop, bool printH = true, bool printF = true)
        {
            var matrix = pop.Population;

            if (printH) PrintHeader(pop);

            for (int i = 0; i < pop.Width; i++)
            {
                for (int j = 0; j < pop.Height; j++)
                {
                    var state = matrix[i, j];
                    Console.Write($"{(state ? TrueCell : FalseCell)}");
                }
                Console.WriteLine();
            }


            if (printH) PrintFooter();


        }
    }
}

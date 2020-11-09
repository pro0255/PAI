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
        public void Print(Board pop)
        {
            var matrix = pop.Population;

            for (int i = 0; i < pop.Width; i++)
            {
                for (int j = 0; j < pop.Height; j++)
                {
                    var state = matrix[i, j];
                    Console.Write($"{(state ? TrueCell : FalseCell)}");
                }
                Console.WriteLine();
            }

        }
    }
}

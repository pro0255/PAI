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
        public void Print(bool[,] pop)
        {
            Console.WriteLine("print");

        }
    }
}

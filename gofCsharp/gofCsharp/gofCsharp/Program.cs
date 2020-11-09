using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gofCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxGen = 20;
            int size = 10;
            var board = new Board(size);
            board.Run(maxGen);

        }
    }
}

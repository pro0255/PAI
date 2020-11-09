using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gofCsharp
{
    class Program

    {
        static int NUMBER_OF_GENERATIONS = 20;
        static void Main(string[] args)
        {
            var controller = new CellNextStateController();
            var size = new Tuple<int, int>(20, 20);
            var printer = new Printer();
            GoF gof = new GoF(controller, size, printer);
            gof.StartSerial(NUMBER_OF_GENERATIONS);
        }
    }
}

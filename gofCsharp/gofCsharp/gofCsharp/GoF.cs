using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gofCsharp
{
    public class GoF
    {

        public ICellNextState NextStateController { get; set; }

        public Board Board { get; set; }

        public IPrinter Printer { get; set; }

        public GoF(ICellNextState nextStateController, Tuple<int, int> size, IPrinter printer)
        {
            Board = new Board(size.Item1, size.Item2);
            NextStateController = nextStateController;
            Printer = printer;
        }

        public void StartSerial(int maxGeneration)
        {
            Printer.Print(Board);
        }

        public Board SerialIterationRun(Board old)
        {
            var newBoard = ExtensionMethods.DeepClone<Board>(old);

        }


        public void StartParallel(int maxGeneration, int numberOfThreads)
        {

        }
    }
}

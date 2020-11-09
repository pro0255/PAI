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

        public Board B { get; set; }

        public IPrinter Printer { get; set; }

        public GoF(ICellNextState nextStateController, Tuple<int, int> size, IPrinter printer)
        {
            B = new Board(size.Item1, size.Item2);
            NextStateController = nextStateController;
            Printer = printer;
        }

        public void StartSerial(int maxGeneration)
        {

            B = Board.PopulateTestCaseBoard(B);
            while (Board.Migration < maxGeneration)
            {
                Printer.Print(B);
                B = SerialIterationRun(B);
            }
        }

        private Board CopyOld(Board old)
        {
            return new Board(old.Width, old.Height);
        }

        public Board SerialIterationRun(Board old)
        {
            var newBoard = CopyOld(old);

            for (int i = 0; i < old.Width; i++)
            {
                for (int j = 0; j < old.Height; j++)
                {
                    newBoard.Population[i, j] = NextStateController.NextState(i, j, old);
                }
            }
            return newBoard;
        }


        public void StartParallel(int maxGeneration, int numberOfThreads)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

        public void StartSerial(int maxGeneration, bool verbose = true)
        {
            Board.Migration = 0;
            Console.WriteLine("Serial");
            B = Board.PopulateRandom(B);
            while (Board.Migration < maxGeneration)
            {
                if (verbose) Printer.Print(B);
                B = SerialIterationRun(B);
            }
        }

        private Board CopyOld(Board old)
        {
            return new Board(old.Width, old.Height);
        }

        public Board SerialIterationRun(Board old, bool verbose = false)
        {
            var sw = new Stopwatch();
            sw.Start();
            var newBoard = CopyOld(old);

            for (int i = 0; i < old.Width; i++)
            {
                for (int j = 0; j < old.Height; j++)
                {
                    newBoard.Population[i, j] = NextStateController.NextState(i, j, old);
                    if (verbose) Console.WriteLine($"{i} {j} - {Thread.CurrentThread.ManagedThreadId}");
                }
            }
            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
            return newBoard;
        }


        public void StartParallel(int maxGeneration, int numberOfThreads, bool verbose = true)
        {
            Board.Migration = 0;
            Console.WriteLine("Parallel");
            B = Board.PopulateRandom(B);
            while (Board.Migration < maxGeneration)
            {
                if (verbose) Printer.Print(B);
                B = ParallelIterationRun(B, numberOfThreads);
            }

        }

        public Board ParallelIterationRun(Board old, int numberOfThreads, bool verbose = false)
        {
            var sw = new Stopwatch();
            sw.Start();
            var newBoard = CopyOld(old);


            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = numberOfThreads
            };

            Parallel.For(0, old.Width, options, i =>
            {
                Parallel.For(0, old.Height, options, j =>
                {
                    newBoard.Population[i, j] = NextStateController.NextState(i, j, old);
                    if (verbose) Console.WriteLine($"{i} {j} - {Thread.CurrentThread.ManagedThreadId}");
                });


            });

            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
            return newBoard;


        }

    }
}



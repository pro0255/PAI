using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gofCsharp
{
    class Program
    {
        /// <summary>
        /// Method which starts calculation with timer.   
        /// </summary>
        /// <param name="approach">Enum which describes calculation approach.</param>
        /// <param name="game">Instance of game.</param>
        /// <param name="maxG">Number which represents number of migrations.</param>
        /// <returns></returns>
        static string RunWithStopWatch(Approach approach, GoF game, int maxG)
        {
            var timer = new Stopwatch();
            timer.Start();
            if (approach == Approach.Sequential)
            {
                game.StartSequential(maxG, false);
            }
            else
            {
                game.StartParallel(maxG, 4, false);
            }
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            return foo;
        }

        /// <summary>
        /// Helper method which writes results to file.
        /// </summary>
        /// <param name="parallel">Parallel result.</param>
        /// <param name="sequential">Sequential result.</param>
        /// <param name="maxG">Number which represents number of migrations.</param>
        /// <param name="path">Path where will be output saved.</param>
        static void WriteToFileResults(string parallel, string sequential, int maxG, string path)
        {
            using (var file = new StreamWriter($"{Path.GetFullPath(path)}"))
            {
                file.WriteLine($"Max generation - {maxG} ");
                file.WriteLine($"\tParallel time - {parallel}");
                file.WriteLine($"\tSequential time - {sequential}");
            }
        }

        /// <summary>
        /// Method starts calculation with both approach for same migration parameter.
        /// </summary>
        /// <param name="gof">Instance of game.</param>
        /// <param name="maxG">Number which represents number of migrations.</param>
        static void RunCalculation(GoF gof, int maxG)
        {
            var seq = RunWithStopWatch(Approach.Sequential, gof, maxG);
            var par = RunWithStopWatch(Approach.Parallel, gof, maxG);
            WriteToFileResults(par, seq, maxG, Path.GetFullPath($"../../TestOutputs/gof-gen-{maxG}.txt"));
        }

        static int WIDTH = 500;
        static int HEIGHT = WIDTH;

        static void Main(string[] args)
        {
            var controller = new CellNextStateController();
            var size = new Tuple<int, int>(WIDTH, HEIGHT);
            var printer = new Printer();
            GoF gof = new GoF(controller, size, printer);

            RunCalculation(gof, 100);
            //RunCalculation(gof, 500);
            //RunCalculation(gof, 1000);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gofCsharp
{
    class Program

    {
        static int NUMBER_OF_GENERATIONS = 5;
        static int WIDTH = 10000;
        static int HEIGHT = WIDTH;


        public static Tuple<int, int> GetUserInputGenAndThreads()
        {
            var gen = GetUserInputGen();

            Console.WriteLine("Threads");
            var t = Console.ReadLine();

            return new Tuple<int, int>(gen, Convert.ToInt32(t));
        }
        public static int GetUserInputGen()
        {

            Console.WriteLine("Max generation");
            var gen = Console.ReadLine();

            return Convert.ToInt32(gen);
        }

        static void Main(string[] args)
        {
            var controller = new CellNextStateController();
            var size = new Tuple<int, int>(WIDTH, HEIGHT);
            var printer = new Printer();
            GoF gof = new GoF(controller, size, printer);






            while (true)
            {
                Console.WriteLine(@"
                    Press 1 for Serial
                    Press 2 for Parallel
                    Everything else for close");
                var val = Console.ReadLine();
                if (val == "1")
                {

                    var gen = GetUserInputGen();

                    gof.StartSequential(gen, false);
                }
                else if (val == "2")
                {
                    var tup = GetUserInputGenAndThreads();

                    gof.StartParallel(tup.Item1, tup.Item2, false);
                }
                else
                {
                    break;
                }

            }
        }
    }
}

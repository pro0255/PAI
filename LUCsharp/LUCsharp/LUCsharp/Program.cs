using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUCsharp
{



    /** 
        References

            - https://www.youtube.com/watch?v=yYxwlnilEJs&ab_channel=BlakeTabian
            - https://en.wikipedia.org/wiki/Crout_matrix_decomposition     
    */
    class Program
    {


        static Matrix ReadMatrixFromFile()
        {
            var A = new Matrix(3, 3);
            return A;
        }


        static Matrix FirstTestCase()
        {
            var A = new Matrix(3, 3);
            A[0, 0] = 1;
            A[0, 1] = 2;
            A[0, 2] = 3;
            A[1, 0] = 2;
            A[1, 1] = 20;
            A[1, 2] = 26;
            A[2, 0] = 3;
            A[2, 1] = 26;
            A[2, 2] = 70;
            return A;
        }

        static void RunWithStopwatch(Approach approach, Matrix testMatrix)
        {
            var timer = new Stopwatch();
            var calc = new Calculator();
            timer.Start();
            calc.Start(testMatrix, approach);
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(foo);
        }


        static void Main(string[] args)
        {
            var calc = new Calculator();
            var A = FirstTestCase();
            RunWithStopwatch(Approach.Sequential, A);
            RunWithStopwatch(Approach.Sequential, A);
        }
    }
}

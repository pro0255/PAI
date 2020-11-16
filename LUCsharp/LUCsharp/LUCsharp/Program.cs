using System;
using System.Collections.Generic;
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

        static void Main(string[] args)
        {
            var calc = new Calculator();
            var A = Program.FirstTestCase();



            var seqResult = calc.Start(A, Approach.Sequential);
            Console.WriteLine(seqResult.Item1);
            Console.WriteLine(seqResult.Item2);
            var parallelResult = calc.Start(A, Approach.Parallel);
            Console.WriteLine(parallelResult.Item1);
            Console.WriteLine(parallelResult.Item2);

        }
    }
}

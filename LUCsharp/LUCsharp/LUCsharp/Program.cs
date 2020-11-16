using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
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

            Console.WriteLine(A);

            var seqResult = calc.Start(A, Approach.Sequential);
            Console.WriteLine(seqResult.Item1);
            Console.WriteLine(seqResult.Item2);
            calc.Start(A, Approach.Parallel);
        }
    }
}

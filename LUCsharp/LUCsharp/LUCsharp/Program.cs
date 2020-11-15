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
            var A = new Matrix(10, 10);
            calc.Start(A, Approach.Sequential);
            calc.Start(A, Approach.Parallel);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUCsharp
{
    public class Calculator
    {
        public Calculator()
        {
        }


        public Tuple<Matrix, Matrix> Init()
        {

            return new Tuple<Matrix, Matrix>(new Matrix(10, 10), new Matrix(10, 10));
        }


        public Tuple<Matrix, Matrix> Start(Matrix A, Approach approach)
        {

            var LU = Init();
            switch (approach)
            {
                case Approach.Sequential:
                    return CalculateSequentialy(LU.Item1, LU.Item2, A);
                case Approach.Parallel:
                    return CalculateParallel(LU.Item1, LU.Item2, A);
                default:
                    return null;
            }
        }


        public Tuple<Matrix, Matrix> CalculateSequentialy(Matrix L, Matrix U, Matrix A)
        {
            Console.WriteLine("Calculating sequentialy");
            return new Tuple<Matrix, Matrix>(L, U);
        }


        public Tuple<Matrix, Matrix> CalculateParallel(Matrix L, Matrix U, Matrix A)
        {
            Console.WriteLine("Calculating parallel");
            return new Tuple<Matrix, Matrix>(L, U);
        }
    }
}

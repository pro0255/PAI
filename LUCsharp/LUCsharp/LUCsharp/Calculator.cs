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

        private int N { get; set; }


        public Tuple<Matrix, Matrix> Init(Matrix A)
        {

            N = A.Rows;
            var L = new Matrix(A.Rows, A.Columns);
            var U = new Matrix(A.Rows, A.Columns);


            for (int i = 0; i < N; i++)
            {
                U[i, i] = 1;
            }

            return new Tuple<Matrix, Matrix>(L, U);
        }


        public Tuple<Matrix, Matrix> Start(Matrix A, Approach approach)
        {

            var LU = Init(A);
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


            for (int j = 0; j < N; j++)
            {
                for (int i = j; i < N; i++)
                {
                    float sum = 0;
                    for (int k = 0; k < j; k++)
                    {
                        sum = sum + L[i, k] * U[k, j];
                    }
                    L[i, j] = A[i, j] - sum;

                }

                for (int i = j; i < N; i++) //start od diagonaly po velikost sloupcu
                {
                    float sum = 0;
                    for (int k = 0; k < j; k++) //vyuziti predchozich prvku 
                    {
                        sum = sum + L[j, k] * U[k, i];
                    }
                    if (L[j, j] == 0)
                    {
                        throw new Exception("Singular");

                    }
                    U[j, i] = (A[j, i] - sum) / L[j, j];
                }
            }

            return new Tuple<Matrix, Matrix>(L, U);
        }


        public Tuple<Matrix, Matrix> CalculateParallel(Matrix L, Matrix U, Matrix A)
        {
            Console.WriteLine("Calculating parallel");

            for (int j = 0; j < N; j++)
            {
                Parallel.For(j, N, i =>
                {
                    float sum = 0;
                    for (int k = 0; k < j; k++)
                    {
                        sum = sum + L[i, k] * U[k, j];
                    }
                    L[i, j] = A[i, j] - sum;
                });


                Parallel.For(j, N, i =>
                {

                    float sum = 0;
                    for (int k = 0; k < j; k++) //vyuziti predchozich prvku 
                    {
                        sum = sum + L[j, k] * U[k, i];
                    }
                    if (L[j, j] == 0)
                    {
                        throw new Exception("Singular");

                    }
                    U[j, i] = (A[j, i] - sum) / L[j, j];
                });
            }


            return new Tuple<Matrix, Matrix>(L, U);

        }
    }
}

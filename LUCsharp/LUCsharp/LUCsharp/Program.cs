using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUCsharp
{
    /** 
        References
            - https://www.youtube.com/watch?v=yYxwlnilEJs&ab_channel=BlakeTabian
            - https://en.wikipedia.org/wiki/Crout_matrix_decomposition     

            - https://onlinemathtools.com/generate-random-matrix (matrix generator)       
    */
    class Program
    {


        static Matrix ReadMatrixFromFile(string path, int size)
        {
            string[] lines = System.IO.File.ReadAllLines($"{path}");

            var A = new Matrix(size, size);

            for (int i = 0; i < lines.Length; i++)
            {

                var splited = lines[i].Split(';');
                for (int j = 0; j < splited.Length; j++)
                {
                    A[i, j] = Convert.ToInt32(splited[j]);
                }
            }
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

        static string RunWithStopwatch(Approach approach, Matrix testMatrix)
        {
            var timer = new Stopwatch();
            var calc = new Calculator();
            timer.Start();
            calc.Start(testMatrix, approach);
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            return foo;
        }


        static void WriteToFileResults(string parallel, string sequential, string matrixDes, string path)
        {
            using (var file = new StreamWriter($"{Path.GetFullPath(path)}"))
            {
                file.WriteLine($"Matrix - {matrixDes}");
                file.WriteLine($"Parallel time - {parallel}");
                file.WriteLine($"Sequential time - {sequential}");
            }

        }

        static void RunCalculation(string matrixName, int size)
        {
            var matrix = ReadMatrixFromFile(Path.GetFullPath($"../../TestMatrix/{matrixName}"), size);
            var calc = new Calculator();
            var seq = RunWithStopwatch(Approach.Sequential, matrix);
            var par = RunWithStopwatch(Approach.Parallel, matrix);
            WriteToFileResults(par, seq, $"\n\tsize - {size}\n\tname - {matrixName}", Path.GetFullPath($"../../TestMatrixOutputs/{matrixName}"));
        }


        static void Main(string[] args)
        {
            //var A = FirstTestCase
            //var seq = RunWithStopwatch(Approach.Sequential, A);
            //var par = RunWithStopwatch(Approach.Parallel, A);
            //RunCalculation("matrix500.txt", 500);

            RunCalculation("matrix100.txt", 100);
            //RunCalculation("matrix500.txt", 500);
            //RunCalculation("matrix1500.txt", 1500);
            //RunCalculation("matrix2000.txt", 2000);
        }
    }
}

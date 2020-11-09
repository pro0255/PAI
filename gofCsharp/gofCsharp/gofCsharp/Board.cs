using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gofCsharp
{
    public class Board
    {

        public bool[,] Matrix { get; set; }
        private int Size { get; set; }

        public Board(int size)
        {
            Matrix = new bool[size, size];
            Size = size;
            PopulateMatrix();
            PrintBoard(0);
        }

        private void PopulateMatrix()
        {
            var rand = new Random();
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    this.Matrix[i, j] = rand.NextDouble() > 0.5;
                }
            }


        }



        private void PrintBoard(int numberOfGeneration)
        {

            Console.WriteLine($"============[Gen-{numberOfGeneration}]=============");
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    Console.Write(Matrix[i, j] ? "*" : " ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("===========================\n");

        }



        private bool CheckBorder(int value)
        {
            return value >= 0 && value < Size;
        }

        private Tuple<int, int> CheckCell(int i, int j)
        {

            List<Tuple<int, int>> surroundings = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(1, -1),
                new Tuple<int, int>(0, -1),
                new Tuple<int, int>(-1, -1),
                new Tuple<int, int>(-1, 0),
                new Tuple<int, int>(-1, 1),
            };

            int numberOfDeath = 0;
            int numberOfLive = 0;

            surroundings.ForEach(item =>
            {

                if (CheckBorder(i + item.Item1) && CheckBorder(j + item.Item2))
                {
                    if (Matrix[i + item.Item1, j + item.Item2])
                    {
                        numberOfLive++;
                    }
                    else
                    {
                        numberOfDeath++;
                    }
                }
            });
            return new Tuple<int, int>(numberOfLive, numberOfDeath);
        }


        public void Run(int maxGeneration)
        {
            int i = 0;
            while (i++ < maxGeneration)
            {
                MakeAnotherGeneration(i);
            }
        }


        private void CheckLiveCell(int i, int j, bool[,] newPop)
        {

            var tuple = CheckCell(i, j);

            //Console.WriteLine($"I am live cell with {tuple.Item1} live around");

            if (tuple.Item1 < 2)
            {
                //Console.WriteLine("I die");
                newPop[i, j] = false;
            }


            if (tuple.Item1 >= 2 && tuple.Item1 <= 3)
            {
                //Console.WriteLine("I live");

                newPop[i, j] = true;
            }

            if (tuple.Item1 > 3)
            {
                //Console.WriteLine("I die");
                newPop[i, j] = false;
            }


        }

        private void CheckDeathCell(int i, int j, bool[,] newPop)
        {


            var tuple = CheckCell(i, j);

            //Console.WriteLine($"I am death cell with {tuple.Item1} live around");
            if (tuple.Item1 == 3)
            {
                //Console.WriteLine("I born");
                newPop[i, j] = true;
            }

        }


        private void MakeAnotherGeneration(int numberOfGeneration)
        {
            var newPopulation = Matrix.Clone() as bool[,];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Matrix[i, j])
                    {
                        CheckLiveCell(i, j, newPopulation);
                    }
                    else
                    {
                        CheckDeathCell(i, j, newPopulation);
                    }
                }
            }
            Matrix = newPopulation;
            PrintBoard(numberOfGeneration);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gofCsharp
{
    public class Board
    {
        public static int Migration = 0;
        public int BoardIndex { get; set; }
        public bool[,] Population { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }


        private void InitBoard(int width, int height)
        {
            var rand = new Random();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Population[i, j] = rand.NextDouble() > 0.5;
                }

            }
        }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            Population = new bool[Width, Height];
            BoardIndex = Board.Migration++;
            InitBoard(width, height);
        }



        private bool CheckBorderWidth(int i)
        {
            return i >= 0 && i < Width;

        }

        private bool CheckBorderHeight(int j)
        {
            return j >= 0 && j < Height;
        }


        public bool CheckBorder(int i, int j)
        {
            return CheckBorderWidth(i) && CheckBorderHeight(j);
        }


    }
}

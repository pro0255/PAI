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

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            Population = new bool[Width, Height];
            BoardIndex = Board.Migration++;
        }


        public static Board PopulateRandom(Board b)
        {
            var rand = new Random(1);

            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    b.Population[i, j] = rand.NextDouble() > 0.5;
                }

            }
            return b;
        }

        public static Board PopulateTestCaseBoard(Board b)
        {

            int w = 5;
            int h = 5;
            var mindgames = new Board(w, h);
            var t = new List<Tuple<int, int>>() {
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(0, 4),

            };
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    mindgames.Population[i, j] = false;
                }

            }

            t.ForEach(pos =>
            {

                mindgames.Population[pos.Item1, pos.Item2] = true;
            });

            return mindgames;

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

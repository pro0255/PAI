using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gofCsharp
{
    /// <summary>
    /// Instance of board which is used in one migration cycle.
    /// </summary>
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


        /// <summary>
        /// Pupulates board with bool information with random approach.
        /// </summary>
        /// <param name="b">Board to populate.</param>
        /// <returns>Populated board.</returns>
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


        /// <summary>
        /// Populates board with defined test case.
        /// </summary>
        /// <param name="b">Board to populate.</param>
        /// <returns>Populated board.</returns>
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


        /// <summary>
        /// Checks if index is in range.
        /// </summary>
        /// <param name="i">Collumn index.</param>
        /// <returns>Boolean information.</returns>
        private bool CheckBorderWidth(int i)
        {
            return i >= 0 && i < Width;

        }

        /// <summary>
        /// Checks if index is in range.
        /// </summary>
        /// <param name="j">Row index.</param>
        /// <returns>Boolean information.</returns>
        private bool CheckBorderHeight(int j)
        {
            return j >= 0 && j < Height;
        }


        /// <summary>
        /// Checks if row and collumn index is in range.
        /// </summary>
        /// <param name="i">Collumn index.</param>
        /// <param name="j">Row index.</param>
        /// <returns>Boolean information.</returns>
        public bool CheckBorder(int i, int j)
        {
            return CheckBorderWidth(i) && CheckBorderHeight(j);
        }


    }
}

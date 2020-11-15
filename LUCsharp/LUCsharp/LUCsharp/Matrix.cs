using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUCsharp
{
    public class Matrix
    {
        public Matrix()
        {
        }
        private int Rows { get; set; }
        private int Columns { get; set; }
        private float[,] matrix { get; set; }

        public float this[int i, int j]
        {
            get
            {
                return matrix[i, j];

            }
            set
            {
                matrix[i, j] = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    sb.Append(matrix[i, j]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}

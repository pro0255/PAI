using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gofCsharp
{
    public class CellNextStateController : CellNextState
    {
        public List<Tuple<int, int>> GetSurroundigs()
        {
            return new List<Tuple<int, int>>()
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
        }

        public bool NextState(int i, int j, bool[,] pop)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gofCsharp
{
    public interface CellNextState
    {
        bool NextState(int i, int j, bool[,] pop);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gofCsharp
{
    /// <summary>
    /// Represents logic which take care of next state of one cell.
    /// It is rescriped in https://cs.wikipedia.org/wiki/Hra_%C5%BEivota [CZ]
    /// CZ summary:
    ///             Každá živá buňka s méně než dvěma živými sousedy zemře.
    ///             Každá živá buňka se dvěma nebo třemi živými sousedy zůstává žít.
    ///             Každá živá buňka s více než třemi živými sousedy zemře.
    ///             Každá mrtvá buňka s právě třemi živými sousedy oživne.
    /// </summary>
    public class CellNextStateController : ICellNextState
    {

        private bool RunConditions(int numberOfDeath, int numberOfLive, bool state)
        {
            if (state && numberOfLive < 2)
            {
                return false;
            }

            if (state && numberOfLive >= 2 && numberOfLive <= 3)
            {
                return true;
            }
            if (state && numberOfLive > 3)
            {
                return false;
            }
            if (!state && numberOfLive == 3)
            {
                return true;
            }
            return state;

        }

        public bool NextState(int i, int j, Board b)
        {
            var sur = GetSurroundigs();
            var pop = b.Population;
            var currentCell = pop[i, j];

            int numberOfDeath = 0;
            int numberOfLive = 0;

            sur.ForEach(s =>
            {
                var posX = i + s.Item1;
                var posY = j + s.Item2;
                if (b.CheckBorder(posX, posY))
                {
                    if (pop[posX, posY])
                    {
                        numberOfLive++;
                    }
                    else
                    {
                        numberOfDeath++;
                    }
                }
            });
            return RunConditions(numberOfDeath, numberOfLive, currentCell);
        }




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

    }
}

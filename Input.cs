using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenVsRed
{
    public static class Input
    {
        public static int[] ParseGridDimentions () {
            var dimentions = Console.ReadLine()
                                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => int.Parse(x))
                                    .ToArray();

            return dimentions;
        }

        public static Grid ParseGridContent(int[] dimentions)
        {
            var grid = new Grid(dimentions[1], dimentions[0]);

            for (int i = 0; i < grid.Rows; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < grid.Columns; j++)
                {
                    grid.Body[i, j] = int.Parse(line[j].ToString());
                }
            }

            return grid;
        }

        public static Cell ParseGridTargetAndRounds(ref int rounds)
        {
            var coordinatesAndRounds = Console.ReadLine()
                                               .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                               .Select(x => int.Parse(x))
                                               .ToArray();

            int cellX = coordinatesAndRounds[0];
            int cellY = coordinatesAndRounds[1];

            Cell target = new Cell(cellY, cellX);

            rounds = coordinatesAndRounds[2];

            return target;
        }

    }
}

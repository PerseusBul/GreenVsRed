using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenVsRed
{
    public class Game
    {
        private int rounds;
        private int version;
        private Cell target;
        private List<Generation> generations;

        public Game(int rounds, Cell target)
        {
            this.rounds = rounds;
            this.version = 0;
            this.target = target;
            this.generations = new List<Generation>();
        }

        public int Rounds { get; set; }

        public int Version { get; set; }

        public void AddGeneration(Generation generation)
        {
            this.generations.Add(generation);
        }

        public void Play(Grid gridInitial)
        {
            var grid = generations[0].CopyGrid(gridInitial);

            for (int i = 0; i < this.rounds; i++)
            {
                var operGrid = generations[i].CopyGrid(grid);

                for (int k = 0; k < grid.Rows; k++)
                {
                    for (int l = 0; l < grid.Columns; l++)
                    {
                        int neighboursState = 0;

                        for (int m = -1; m <= 1; m++)
                        {
                            for (int n = -1; n <= 1; n++)
                            {
                                if (m == 0 && n == 0)
                                {
                                    continue;
                                }

                                if (k + m >= 0 && k + m < grid.Columns && l + n >= 0 && l + n < grid.Columns)
                                {
                                    neighboursState += grid.Body[k + m, l + n];
                                }
                            }
                        }

                        if (grid.Body[k, l] == 1 && !(neighboursState == 2 || neighboursState == 3 || neighboursState == 6))
                        {
                            operGrid.Body[k, l] = 0;
                        }

                        if (grid.Body[k, l] == 0 && (neighboursState == 3 || neighboursState == 6))
                        {
                            operGrid.Body[k, l] = 1;
                        }
                    }
                }

                grid = operGrid;

                var generation = new Generation(i + 1, grid);
                AddGeneration(generation);
            }
        }

        public void DisplayScore()
        {
            int count = this.CountGenerationsWithGreenTargetCell();

            Console.WriteLine($"# expected result: {count}");
        }

        private int CountGenerationsWithGreenTargetCell()
        {
            int count = generations
                .Where(g => g.Grid.Body[target.Row, target.Column] == 1)
                .Count();

            return count;
        }
    }
}

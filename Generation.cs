using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed
{
    public class Generation
    {
        private int version;

        public Generation(int version, Grid grid)
        {
            this.version = version;
            this.Grid = this.CopyGrid(grid);
        }

        public int Version => this.version;

        public Grid Grid { get; set; }

        public bool IsTargetCellGreen(Cell target)
        {
            bool isGreen = this.Grid.Body[target.Row, target.Column] == 1;

            return isGreen;
        }

        public Grid CopyGrid(Grid grid)
        {
            var operGrid = new Grid(grid.Rows, grid.Columns);

            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Columns; j++)
                {
                    operGrid.Body[i, j] = grid.Body[i, j];
                }
            }

            return operGrid;
        }
    }
}

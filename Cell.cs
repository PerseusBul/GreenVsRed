using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed
{
    public class Cell
    {
        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}

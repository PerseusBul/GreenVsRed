using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed
{
    public class Grid
    {
        private int rows;
        private int columns;

        public Grid(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.Body = new int[rows, columns];
        }

        public int Rows => this.rows;

        public int Columns => this.columns;

        public int[,] Body { get; set; }
    }
}

using GameOfLife.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Domain.EventArgs
{
    public class CellProcessedEventArgs
    {
        public Cell Cell { get; private set; }

        public CellProcessedEventArgs(Cell cell)
        {
            Cell = cell;
        }
    }
}

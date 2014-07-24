using GameOfLife.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Domain.EventArgs
{
    public class CellProcessedEventArgs
    {
        public ICell Cell { get; private set; }

        public CellProcessedEventArgs(ICell cell)
        {
            Cell = cell;
        }
    }
}

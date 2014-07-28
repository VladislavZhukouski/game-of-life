using GameOfLife.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.Domain.EventArgs
{
    public class FieldProcessedEventArgs
    {
        public IEnumerable<ICell> ChangedCells { get; private set; }
        public FieldProcessedEventArgs(IEnumerable<ICell> changedCells)
        {
            ChangedCells = changedCells;
        }
    }
}

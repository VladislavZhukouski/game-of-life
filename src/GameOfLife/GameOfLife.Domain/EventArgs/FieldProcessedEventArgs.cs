using GameOfLife.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.Domain.EventArgs
{
    public class FieldProcessedEventArgs
    {
        public IEnumerable<Cell> ChangedCells { get; private set; }
        public FieldProcessedEventArgs(IEnumerable<Cell> changedCells)
        {
            ChangedCells = changedCells;
        }
    }
}

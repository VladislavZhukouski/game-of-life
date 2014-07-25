using GameOfLife.Domain.Entities;
using GameOfLife.Domain.EventArgs;
using GameOfLife.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Domain
{
    public class Processor
    {
        private Field field;
        private IList<ICell> changedCells;

        public Processor(int m, int n)
        {
            field = new Field(m, n);
            changedCells = new List<ICell>();
        }

        public delegate void CellProcessedEventHandler(object sender, CellProcessedEventArgs e);

        public event CellProcessedEventHandler CellProcessedEvent;

        public void Process()
        {
            for (var i = 0; i < field.M; i++)
                for (var j = 0; j < field.N; j++)
                {
                    ProcessCell(i, j);
                }
        }

        public void ProcessCell(int x, int y)
        {
            var cell = field[x, y];
            var aliveNeighboorsCount = AliveNeighboorsCount(cell);
            if (!cell.IsAlive)
            {
                if (aliveNeighboorsCount == 3)
                    changedCells.Add(cell.Revive());
            }
            else
            {
                if (!(aliveNeighboorsCount == 2 || aliveNeighboorsCount == 3))
                    changedCells.Add(cell.Kill());
            }
        }

        private void ProcessCells()
        {
            for (var i = 0; i < field.M; i++)
                for (var j = 0; j < field.N; j++)
                {
                    ProcessCell(i, j);
                }
        }

        private void RemakeField()
        {
            foreach(var item in changedCells)
            {
                field[item.X, item.Y].IsAlive = item.IsAlive;
            }
        }

        public int AliveNeighboorsCount(ICell cell)
        {
            throw new NotImplementedException();
        }

        private void RaiseCellProcessedEvent(ICell processedCell)
        {
            if (CellProcessedEvent != null)
            {
                CellProcessedEvent(this, new CellProcessedEventArgs(processedCell));
            }
        }
    }
}

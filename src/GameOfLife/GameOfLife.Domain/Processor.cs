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

        public Processor(int m, int n)
        {
            field = new Field(m, n);
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
                    cell.IsAlive = true;
            }
            else
            {
                if (!(aliveNeighboorsCount == 2 || aliveNeighboorsCount == 3))
                    cell.IsAlive = false;
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

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
        private NeigboorCellsProcessor neigboorCellsProcessor;

        public Processor(int m, int n)
        {
            field = new Field(m, n);
            changedCells = new List<ICell>();
            neigboorCellsProcessor = new NeigboorCellsProcessor(field);
        }

        public delegate void CellProcessedEventHandler(object sender, CellProcessedEventArgs e);

        public event CellProcessedEventHandler CellProcessedEvent;

        public Field Field
        {
            get
            {
                return field;
            }
        }

        public IEnumerable<ICell> ProcessField()
        {
            RemakeField();
            for (var i = 0; i < field.M; i++)
                for (var j = 0; j < field.N; j++)
                {
                    ProcessCell(i, j);
                }
            return changedCells;
        }

        public void SetAliveCell(int i, int j)
        {
            field[i, j].IsAlive = true;
        }

        private void ProcessCell(int i, int j)
        {
            var cell = field[i, j];
            var aliveNeighboorsCount = AliveNeighboorCellsCount(cell);
            if (!cell.IsAlive)
            {
                if (aliveNeighboorsCount == 3)
                    changedCells.Add(new Cell(cell.I, cell.J, true));
            }
            else
            {
                if (!(aliveNeighboorsCount == 2 || aliveNeighboorsCount == 3))
                    changedCells.Add(new Cell(cell.I, cell.J));
            }
        }

        private void RemakeField()
        {
            changedCells.Clear();
            foreach(var item in changedCells)
            {
                field[item.I, item.J].IsAlive = item.IsAlive;
            }
        }

        private int AliveNeighboorCellsCount(ICell cell)
        {
            return neigboorCellsProcessor.GetNeigboorCells(cell).Count(x => x.IsAlive);
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

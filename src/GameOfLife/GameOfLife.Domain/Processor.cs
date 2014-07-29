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

        #region Fields and properties

        private Field field;
        private IList<ICell> changedCells;
        private NeigboorCellsProcessor neigboorCellsProcessor;
        public Field Field
        {
            get
            {
                return field;
            }
        }

        #endregion

        public Processor(int m, int n)
        {
            field = new Field(m, n);
            changedCells = new List<ICell>();
            neigboorCellsProcessor = new NeigboorCellsProcessor(field);
        }

        #region Eventing

        public delegate void CellProcessedEventHandler(object sender, CellProcessedEventArgs e);
        public delegate void FieldProcessedEventHandler(object sender, FieldProcessedEventArgs e);

        public event CellProcessedEventHandler CellProcessed;
        public event FieldProcessedEventHandler FieldProcessed;

        private void RaiseCellProcessedEvent(ICell processedCell)
        {
            if (CellProcessed != null)
            {
                CellProcessed(this, new CellProcessedEventArgs(processedCell));
            }
        }

        private void RaiseFieldProcessedEvent(IEnumerable<ICell> changedCells)
        {
            if (FieldProcessed != null)
            {
                FieldProcessed(this, new FieldProcessedEventArgs(changedCells));
            }
        }

        #endregion

        #region Field processing

        public void ProcessField()
        {
            RemakeField();
            for (var i = 0; i < field.M; i++)
                for (var j = 0; j < field.N; j++)
                {
                    ProcessCell(field[i, j]);
                }
            RaiseFieldProcessedEvent(changedCells);
        }

        private void ProcessCell(ICell cell)
        {
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

        public void ProcessOnlyCell(ICell cell)
        {
            ProcessCell(cell);
            RaiseCellProcessedEvent(cell);
        }

        private void RemakeField()
        {
            foreach (var item in changedCells)
            {
                field[item.I, item.J].IsAlive = item.IsAlive;
            }
            changedCells.Clear();
        }

        private int AliveNeighboorCellsCount(ICell cell)
        {
            return neigboorCellsProcessor.GetNeigboorCells(cell).Count(x => x.IsAlive);
        }

        #endregion
    }
}

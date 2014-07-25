using GameOfLife.Domain.Entities;
using GameOfLife.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Domain
{
    public class NeigboorCellsProcessor
    {
        private Field field;

        public NeigboorCellsProcessor(Field field)
        {
            this.field = field;
        }

        public IList<ICell> GetNeigboorCells(ICell cell)
        {
            var result = new List<ICell>();
            result.Add(GetLeftTopCell(cell));
            result.Add(GetTopCell(cell));
            result.Add(GetRightTopCell(cell));
            result.Add(GetRightCell(cell));
            result.Add(GetRightBottomCell(cell));
            result.Add(GetBottomCell(cell));
            result.Add(GetLeftBottomCell(cell));
            result.Add(GetLeftCell(cell));
            return result;
        }

        private ICell GetLeftTopCell(ICell cell)
        {
            if (cell.I == 0 && cell.J == 0)
                return field[field.M - 1, field.N - 1];
            if (cell.I == 0)
                return field[field.M - 1, cell.J - 1];
            if (cell.J == 0)
                return field[cell.I - 1, field.N - 1];
            return field[cell.I - 1, cell.J - 1];
        }

        private ICell GetTopCell(ICell cell)
        {
            if (cell.I == 0)
                return field[field.M - 1, cell.J];
            return field[cell.I - 1, cell.J];
        }

        private ICell GetRightTopCell(ICell cell)
        {
            if (cell.I == 0 && cell.J == field.N - 1)
                return field[field.M - 1, 0];
            if (cell.I == 0)
                return field[field.M - 1, cell.J + 1];
            if (cell.J == field.N - 1)
                return field[cell.I - 1, 0];
            return field[cell.I - 1, cell.J + 1];
        }

        private ICell GetRightCell(ICell cell)
        {
            if (cell.J == field.N)
                return field[cell.I, 0];
            return field[cell.I, cell.J + 1];
        }

        private ICell GetRightBottomCell(ICell cell)
        {
            if (cell.I == field.M - 1 && cell.J == field.N - 1)
                return field[0, 0];
            if (cell.I == field.M - 1)
                return field[0, cell.J + 1];
            if (cell.J == field.N - 1)
                return field[cell.I + 1, 0];
            return field[cell.I + 1, cell.J + 1];
        }

        private ICell GetBottomCell(ICell cell)
        {
            if (cell.I == field.M - 1)
                return field[0, cell.J];
            return field[cell.I + 1, cell.J];
        }

        private ICell GetLeftBottomCell(ICell cell)
        {
            if (cell.I == field.M - 1 && cell.J == 0)
                return field[0, field.N - 1];
            if (cell.I == field.M - 1)
                return field[0, cell.J - 1];
            if (cell.J == 0)
                return field[cell.I + 1, field.N - 1];
            return field[cell.I + 1, cell.J - 1];
        }

        private ICell GetLeftCell(ICell cell)
        {
            if (cell.J == 0)
                return field[cell.I, field.N - 1];
            return field[cell.I, cell.J - 1];
        }

    }
}

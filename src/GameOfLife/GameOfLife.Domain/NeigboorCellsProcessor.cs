using GameOfLife.Domain.Entities;
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

        public IList<Cell> GetNeigboorCells(Cell cell)
        {
            var result = new List<Cell>();
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

        private Cell GetLeftTopCell(Cell cell)
        {
            if (cell.I == 0 && cell.J == 0)
                return field[field.M - 1, field.N - 1];
            if (cell.I == 0)
                return field[field.M - 1, cell.J - 1];
            if (cell.J == 0)
                return field[cell.I - 1, field.N - 1];
            return field[cell.I - 1, cell.J - 1];
        }

        private Cell GetTopCell(Cell cell)
        {
            if (cell.I == 0)
                return field[field.M - 1, cell.J];
            return field[cell.I - 1, cell.J];
        }

        private Cell GetRightTopCell(Cell cell)
        {
            if (cell.I == 0 && cell.J == field.N - 1)
                return field[field.M - 1, 0];
            if (cell.I == 0)
                return field[field.M - 1, cell.J + 1];
            if (cell.J == field.N - 1)
                return field[cell.I - 1, 0];
            return field[cell.I - 1, cell.J + 1];
        }

        private Cell GetRightCell(Cell cell)
        {
            if (cell.J == field.N - 1)
                return field[cell.I, 0];
            return field[cell.I, cell.J + 1];
        }

        private Cell GetRightBottomCell(Cell cell)
        {
            if (cell.I == field.M - 1 && cell.J == field.N - 1)
                return field[0, 0];
            if (cell.I == field.M - 1)
                return field[0, cell.J + 1];
            if (cell.J == field.N - 1)
                return field[cell.I + 1, 0];
            return field[cell.I + 1, cell.J + 1];
        }

        private Cell GetBottomCell(Cell cell)
        {
            if (cell.I == field.M - 1)
                return field[0, cell.J];
            return field[cell.I + 1, cell.J];
        }

        private Cell GetLeftBottomCell(Cell cell)
        {
            if (cell.I == field.M - 1 && cell.J == 0)
                return field[0, field.N - 1];
            if (cell.I == field.M - 1)
                return field[0, cell.J - 1];
            if (cell.J == 0)
                return field[cell.I + 1, field.N - 1];
            return field[cell.I + 1, cell.J - 1];
        }

        private Cell GetLeftCell(Cell cell)
        {
            if (cell.J == 0)
                return field[cell.I, field.N - 1];
            return field[cell.I, cell.J - 1];
        }

    }
}

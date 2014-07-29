using GameOfLife.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Domain.Entities
{
    public class Cell: ICell
    {
        public Cell(int i, int j)
        {
            I = i;
            J = j;
            GenerateId();
        }

        public Cell(int i, int j, bool isAlive): this(i, j)
        {
            IsAlive = isAlive;
        }

        private void GenerateId()
        {
            Id = (I + J) * (I + J + 1) / 2 + J;
        }

        public bool IsAlive { get; set; }

        public int I { get; private set; }

        public int J { get; private set; }

        public int Id { get; private set; }
    }
}

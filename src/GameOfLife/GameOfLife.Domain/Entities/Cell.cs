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
        }

        public Cell(int i, int j, bool isAlive)
        {
            I = i;
            J = j;
            IsAlive = isAlive;
        }

        private void GenerateId()
        {
            Id = 1 / 2 * (I + J) * (I + J + 1) + J;
        }

        public bool IsAlive { get; set; }

        public int I { get; private set; }

        public int J { get; private set; }

        public int Id { get; private set; }
    }
}

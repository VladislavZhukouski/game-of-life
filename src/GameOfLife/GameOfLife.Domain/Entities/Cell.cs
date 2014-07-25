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
        public bool IsAlive { get; set; }
        public int I { get; private set; }
        public int J { get; private set; }


        public ICell Revive()
        {
            IsAlive = true;
            return this;
        }

        public ICell Kill()
        {
            IsAlive = false;
            return this;
        }
    }
}

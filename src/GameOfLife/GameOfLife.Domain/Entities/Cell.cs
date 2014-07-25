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
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
        public bool IsAlive { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }


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

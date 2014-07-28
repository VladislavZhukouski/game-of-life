using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class Settings
    {
        public const int CELL_SIZE = 15;
        public static readonly Color DEAD_CELL_COLOR = Color.White;
        public static readonly Color ALIVE_CELL_COLOR = Color.Black;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Domain.Interfaces
{
    public interface ICell
    {
        bool IsAlive { get; set; }
        int I { get; }
        int J { get; }
        ICell Revive();
        ICell Kill();
    }
}

using GameOfLife.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Domain.Entities
{
    public class Field
    {
        private IList<ICell> field;


        public Field(int m, int n)
        {
            InitializeField(m, n);
        }

        public int M { get; private set; }
        public int N { get; private set; }
        public IEnumerable<ICell> Cells
        {
            get
            {
                return field;
            }
        }

        public ICell this[int i, int j]
        {
            get
            {
                return field[i * N + j];
            }
            set
            {
                field[i * N + j] = value;
            }
        }

        private void InitializeField(int m, int n)
        {
            M = m;
            N = n;
            field = new List<ICell>();
            for(var i = 0; i < M; i++)
                for (var j = 0; j < N; j++)
                {
                    field.Add(new Cell(i, j));
                }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (var i = 0; i < M; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    if (this[i, j].IsAlive)
                        builder.Append(1);
                    else
                        builder.Append(0);
                }
                builder.AppendLine(String.Empty);
            }
            return builder.ToString();
        }
    }
}

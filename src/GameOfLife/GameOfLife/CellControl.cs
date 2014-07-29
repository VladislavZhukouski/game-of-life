using GameOfLife.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public class CellControl: Label
    {
        private delegate void ChangeColorDelegate();
        private ChangeColorDelegate changeColorDelegate;

        public CellControl(ICell cell):base()
        {
            this.changeColorDelegate = Rise;
            InitializeCell(cell.I, cell.J);
        }

        private void InitializeCell(int i, int j)
        {
            this.Text = String.Empty;
            this.BackColor = Settings.DEAD_CELL_COLOR;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(Settings.CELL_SIZE * j, Settings.CELL_SIZE * i);
            this.Size = new System.Drawing.Size(Settings.CELL_SIZE, Settings.CELL_SIZE);
        }

        public void Act()
        {
            changeColorDelegate.Invoke();
        }

        private void Rise()
        {
            this.BackColor = Settings.ALIVE_CELL_COLOR;
            this.changeColorDelegate = Die;
        }

        private void Die()
        {
            this.BackColor = Settings.DEAD_CELL_COLOR;
            this.changeColorDelegate = Rise;
        }
    }
}

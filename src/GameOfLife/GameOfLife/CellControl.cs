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
        public ICell Cell { get; private set; }

        private delegate void ChangeColorDelegate();
        private ChangeColorDelegate changeColorDelegate;

        public CellControl(ICell cell):base()
        {
            this.Cell = cell;
            this.changeColorDelegate = Rise;
            InitializeCell();
        }

        private void InitializeCell()
        {
            this.Text = String.Empty;
            this.BackColor = Settings.DEAD_CELL_COLOR;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(Settings.CELL_SIZE * Cell.J, Settings.CELL_SIZE * Cell.I);
            this.Size = new System.Drawing.Size(Settings.CELL_SIZE, Settings.CELL_SIZE);
        }

        public void ChangeColor()
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

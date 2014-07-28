using GameOfLife.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Field : Form
    {
        private IList<CellControl> cells;
        private int m;
        private int n;
        private Processor processor;

        public Field(int m, int n)
        {
            this.m = m;
            this.n = n;
            InitializeComponent();
            InitializeProcessor();
            InitializeField();
            InitializeCells();
        }

        private void InitializeProcessor()
        {
            processor = new Processor(this.m, this.n);
        }

        private void InitializeField()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(Settings.CELL_SIZE * n + 16, Settings.CELL_SIZE * m + 38);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
        }

        private void InitializeCells()
        {
            cells = new List<CellControl>();
            foreach(var item in processor.Field.Cells)
            {
                var cellControl = new CellControl(item);
                cellControl.Click += cellControl_Click;
                cells.Add(cellControl);
            }
            foreach(var item in this.cells)
            {
                this.Controls.Add(item);
            }
        }

        void cellControl_Click(object sender, EventArgs e)
        {
            var cellControl = (CellControl)sender;
            
        }
    }
}

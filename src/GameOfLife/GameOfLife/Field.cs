using GameOfLife.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Field : Form
    {
        private Dictionary<int, CellControl> cellControls;
        //private IList<CellControl> cells;
        private int m;
        private int n;
        private Processor processor;
        private Thread drawingThread;
        private Button startButton;
        private Button stopButton;

        public Field(int m, int n)
        {
            this.m = m;
            this.n = n;
            InitializeGame();
        }

        private void InitializeGame()
        {
            InitializeComponent();
            InitializeProcessor();
            InitializeField();
            InitializeCellControls();
            InitializeButtons();
        }

        private void InitializeProcessor()
        {
            processor = new Processor(this.m, this.n);
            processor.FieldProcessed += processor_FieldProcessed;
            processor.CellProcessed += processor_CellProcessed;
        }

        private void InitializeField()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(Settings.CELL_SIZE * n + 16, Settings.CELL_SIZE * m + 38 + 40);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
        }

        private void InitializeCellControls()
        {
            //cells = new List<CellControl>();
            //foreach(var item in processor.Field.Cells)
            //{
            //    var cellControl = new CellControl(item);
            //    cellControl.Click += cellControl_Click;
            //    cells.Add(cellControl);
            //}
            //foreach(var item in this.cells)
            //{
            //    this.Controls.Add(item);
            //}

            //
            cellControls = new Dictionary<int, CellControl>();
            foreach (var item in processor.Field.Cells)
            {
                var cellControl = new CellControl(item);
                cellControl.Click += cellControl_Click;
                cellControls.Add(item.Id, cellControl);
                this.Controls.Add(cellControl);
            }
        }

        private void InitializeButtons()
        {
            startButton = new Button();
            startButton.BackColor = Color.White;
            startButton.ForeColor = Color.Black;
            startButton.Text = "Start";
            startButton.Size = new System.Drawing.Size(50, 26);
            startButton.Location = new System.Drawing.Point(6, this.Height - 70);
            startButton.Click += startButton_Click;
            startButton.Visible = true;
            this.Controls.Add(startButton);

            stopButton = new Button();
            stopButton.BackColor = Color.White;
            stopButton.ForeColor = Color.Black;
            stopButton.Text = "Stop";
            stopButton.Size = new System.Drawing.Size(50, 25);
            stopButton.Location = new System.Drawing.Point(this.Width - 72, this.Height - 70);
            stopButton.Click += stopButton_Click;
            stopButton.Visible = true;
            this.Controls.Add(stopButton);

            var clearButton = new Button();
            clearButton.BackColor = Color.White;
            clearButton.ForeColor = Color.Black;
            clearButton.Text = "Clear";
            clearButton.Size = new System.Drawing.Size(50, 25);
            clearButton.Location = new System.Drawing.Point(this.Width - 72 - 55, this.Height - 70);
            clearButton.Click += clearButton_Click;
            clearButton.Visible = true;
            this.Controls.Add(clearButton);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (drawingThread != null)
                drawingThread.Abort();
            InitializeGame();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (drawingThread != null)
                drawingThread.Abort();
            startButton.Enabled = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            drawingThread = new Thread(
                () =>
                {
                    while (true)
                    {
                        processor.ProcessField();
                        Thread.Sleep(50);
                    }
                });
            drawingThread.IsBackground = true;
            drawingThread.Start();
            startButton.Enabled = false;
        }

        private void processor_CellProcessed(object sender, Domain.EventArgs.CellProcessedEventArgs e)
        {
            cellControls[e.Cell.Id].Act();
        }

        private void processor_FieldProcessed(object sender, Domain.EventArgs.FieldProcessedEventArgs e)
        {
            foreach(var item in e.ChangedCells.Select(x=>x.Id))
                cellControls[item].Act();
        }

        private void cellControl_Click(object sender, EventArgs e)
        {
            var cellControl = (CellControl)sender;
            processor.ManuallyProcessCell(cellControls.Single(x=> x.Value == cellControl).Key);
        }
    }
}

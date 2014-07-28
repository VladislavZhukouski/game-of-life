using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsTest
{
    public partial class Form1 : Form
    {
        private IList<CustomLabel> labels;
        private int m;
        private int n;
        private const int CELL_SIZE = 15;
        private Thread drawingThread1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeForm();
            InitializeLabels();
            Go();
        }

        private void Go()
        {
            drawingThread1 = new Thread(
                () =>
                {
                    for (var i = 0; i < m; i++)
                        for (var j = 0; j < n; j++)
                        {
                            this.labels[i * n + j].ChangeColor();
                            Thread.Sleep(10);
                        }
                }
            );
            drawingThread1.Start();
        }

        private void InitializeForm()
        {
            this.m = 50;
            this.n = 50;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.Red;
            this.ForeColor = Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(CELL_SIZE * m + 16, CELL_SIZE * n + 38);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeLabels()
        {
            labels = new List<CustomLabel>();
            for (var i = 0; i < m; i++)
                for (var j = 0; j < n; j++)
                    labels.Add(new CustomLabel());
            for (var i = 0; i < m; i++)
                for (var j = 0; j < n; j++)
            {
                this.labels[i * n + j].Text = String.Empty;
                this.labels[i * n + j].BackColor = Color.Red;
                this.labels[i * n + j].BorderStyle = BorderStyle.FixedSingle;
                this.labels[i * n + j].Location = new System.Drawing.Point(CELL_SIZE * i, CELL_SIZE * j);
                this.labels[i * n + j].Size = new System.Drawing.Size(CELL_SIZE, CELL_SIZE);
                this.labels[i * n + j].Click += label1_Click;
            }
            foreach (var item in labels)
                this.Controls.Add(item);
        }

        void label1_Click(object sender, EventArgs e)
        {
            ((CustomLabel)sender).ChangeColor();
        }
    }
}

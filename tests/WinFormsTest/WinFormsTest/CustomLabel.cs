using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTest
{
    public class CustomLabel: Label
    {
        public delegate void ChangeColorDelegate();
        public ChangeColorDelegate changeColorDelegate;

        public CustomLabel():base()
        {
            this.changeColorDelegate = ChangeColorToBlack;
        }

        private void ChangeColorToRed()
        {
            this.BackColor = Color.Red;
            this.changeColorDelegate = ChangeColorToBlack;
        }

        private void ChangeColorToBlack()
        {
            this.BackColor = Color.Black;
            this.changeColorDelegate = ChangeColorToRed;
        }

        public void ChangeColor()
        {
            changeColorDelegate.Invoke();
        }
    }
}

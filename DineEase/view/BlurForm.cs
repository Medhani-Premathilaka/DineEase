using System;
using System.Drawing;
using System.Windows.Forms;

namespace DineEase.view
{
    public partial class BlurForm : Form
    {
        public BlurForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Black;
            this.Opacity = 0.5;  // You can adjust the opacity
            this.ShowInTaskbar = false;
            this.TopMost = true;

        }

        private void BlurForm_Load(object sender, EventArgs e)
        {

        }
    }
}

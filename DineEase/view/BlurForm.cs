using System;
using System.Drawing;
using System.Windows.Forms;

namespace DineEase.view
{
    public partial class BlurForm : Form
    {
        public BlurForm(Form parent)
        {
            InitializeComponent();

            // Make it borderless and not full screen
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.TopMost = false;
            this.BackColor = Color.Black;
            this.Opacity = 0.4; // Slight dim
            this.Size = parent.ClientSize; // Same size as parent window
            this.Location = parent.PointToScreen(Point.Empty); // Align perfectly with parent
        }

        private void BlurForm_Load(object sender, EventArgs e)
        {

        }
    }
}
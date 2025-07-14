using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DineEase
{
    public partial class Description : UserControl
    {

        public int quantity { get; set; }


        public Description()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            qtyLabel.Text = (int.Parse(qtyLabel.Text) + 1).ToString();
        }

        private void Description_Load(object sender, EventArgs e)
        {
            quantity = 0;
            qtyLabel.Text = quantity.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            qtyLabel.Text = (int.Parse(qtyLabel.Text) - 1).ToString();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}

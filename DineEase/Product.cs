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
    public partial class Product : UserControl
    {
        public Product()
        {
            InitializeComponent();
        }

        public event EventHandler onSelect = null;
        public int id { get; set; }
        public string pprice { get; set; }

        public string pcategory { get; set; }

        public string pname
        {
            get { return pLabel.Text; }
            set { pLabel.Text = value; }
        }

        public Image pimg
        {
            get { return pImage.Image; }
            set { pImage.Image = value; }
        }

        private void pImage_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
    }
}

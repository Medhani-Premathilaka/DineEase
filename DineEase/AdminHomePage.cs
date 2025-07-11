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
    public partial class AdminHomePage : Form
    {
        string connectionString = @"Data Source=DESKTOP-TAR59NP\SQLEXPRESS;Initial Catalog=dineEase;Integrated Security=True";
        public AdminHomePage()
        {
            InitializeComponent();
        }

        private void guna2ButtonAddNewItem_Click(object sender, EventArgs e)
        {
            AddItemPage addItemPage = new AddItemPage(); // create instance of form2
            addItemPage.Show(); // open the AddItemPage
            this.Hide(); // optional: hide AdminHomePage
        }
    }
}

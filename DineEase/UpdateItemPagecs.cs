using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DineEase
{
    public partial class UpdateItemPagecs : Form
    {
        string connectionString = @"Data Source=DESKTOP-TAR59NP\SQLEXPRESS;Initial Catalog=dineEase;Integrated Security=True";
        string originalName;
        public UpdateItemPagecs(string name, string addFor, string price, string description)
        {
            InitializeComponent();
            guna2TextBoxName.Text = name;
            guna2TextBoxAddFor.Text = addFor;
            guna2TextBoxPrice.Text = price;
            guna2TextBoxDescription.Text = description;

            originalName = name;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ButtonUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE menu 
                                 SET name = @name, addFor = @addFor, price = @price, description = @description 
                                 WHERE name = @originalName";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", guna2TextBoxName.Text);
                cmd.Parameters.AddWithValue("@addFor", guna2TextBoxAddFor.Text);
                cmd.Parameters.AddWithValue("@price", guna2TextBoxPrice.Text);
                cmd.Parameters.AddWithValue("@description", guna2TextBoxDescription.Text);
                cmd.Parameters.AddWithValue("@originalName", originalName);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Item updated successfully.");
                        this.Close();
                        new AdminHomePage().Show(); // return to Admin page
                    }
                    else
                    {
                        MessageBox.Show("Update failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void guna2TextBoxAddFor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

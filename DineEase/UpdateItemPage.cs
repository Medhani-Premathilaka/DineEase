using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DineEase
{
    public partial class UpdateItemPage : Form
    {
        private string imagePath = null;
        string connectionString = @"Data Source=DESKTOP-TAR59NP\SQLEXPRESS;Initial Catalog=dineEase;Integrated Security=True";
        string originalName;
        public UpdateItemPage(string name, string addFor, string price, string description)
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
                 SET name = @name, addFor = @addFor, price = @price, description = @description, imagePath = @imagePath 
                 WHERE name = @originalName";



                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", guna2TextBoxName.Text);
                cmd.Parameters.AddWithValue("@addFor", guna2TextBoxAddFor.Text);
                cmd.Parameters.AddWithValue("@price", guna2TextBoxPrice.Text);
                cmd.Parameters.AddWithValue("@description", guna2TextBoxDescription.Text);
                cmd.Parameters.AddWithValue("@originalName", originalName);

                if (!string.IsNullOrEmpty(imagePath))
                {
                    cmd.Parameters.AddWithValue("@imagePath", imagePath);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@imagePath", DBNull.Value);
                }



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

        private void guna2ButtonImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                string selectedFilePath;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;
                    Image selectedImage = Image.FromFile(selectedFilePath);
                    pictureBoxItem.Image = selectedImage;
                    imagePath = selectedFilePath; // store the path
                }
            }
        }

        private byte[] imageBytes = null;  // store current image bytes

        private byte[] ImageToByteArray(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

        private void pictureBoxItem_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DineEase
{
    public partial class UpdateItemPage : Form
    {
        private string imagePath = null;
        //string connectionString = @"Server=dineease.chc86qwacnkf.eu-north-1.rds.amazonaws.com;Database=DineEase;User Id=admin;Password=DineEase;";
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



        private void guna2TextBoxAddFor_TextChanged(object sender, EventArgs e)
        {

        }

        //private void guna2ButtonImport_Click(object sender, EventArgs e)
        //{
        //    using (OpenFileDialog openFileDialog = new OpenFileDialog())
        //    {
        //        openFileDialog.Title = "Select an image";
        //        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
        //        string selectedFilePath;

        //        if (openFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            selectedFilePath = openFileDialog.FileName;
        //            Image selectedImage = Image.FromFile(selectedFilePath);
        //            pictureBoxItem.Image = selectedImage;
        //            imagePath = selectedFilePath; // store the path
        //        }
        //    }
        //}

        private byte[] imageBytes = null;  // store current image bytes

        //private byte[] ImageToByteArray(Image img)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        img.Save(ms, img.RawFormat);
        //        return ms.ToArray();
        //    }
        //}

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

        private void pictureBoxItem_Click_1(object sender, EventArgs e)
        {
            var db = dao.DBConnection.getInstance();
            using (SqlConnection cnn = db.GetConnection())
            {
                //cnn.Open();

                string query = "SELECT ProductName, Category, Price, Description, Image FROM FoodProduct";
                SqlCommand cmd = new SqlCommand(query, cnn);


                try
                {
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    PictureBox picture = new PictureBox
                    {
                        Width = 180,
                        Height = 140,
                        Top = 10,
                        Left = 20,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    if (reader["Image"] != DBNull.Value)
                    {
                        byte[] imageData = reader["Image"] as byte[];
                        if (imageData != null && imageData.Length > 0)
                        {
                            using (var ms = new MemoryStream(imageData))
                            {
                                picture.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    cnn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading menu items: " + ex.Message);
                }

            }

        }

        private void guna2ButtonUpdate_Click_1(object sender, EventArgs e)
        {
            var db = dao.DBConnection.getInstance();
            using (SqlConnection cnn = db.GetConnection())
            {
                cnn.Open();
                string query = @"UPDATE FoodProducts 
                 SET ProductName = @name, Category = @addFor, Price = @price, Description = @description, Image = @imagePath 
                 WHERE name = @originalName";



                SqlCommand cmd = new SqlCommand(query, cnn);
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
                    cnn.Open();
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
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void guna2ButtonImport_Click(object sender, EventArgs e)
        {

        }
    }
}

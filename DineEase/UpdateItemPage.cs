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
        string connectionString = @"Server=dineease.chc86qwacnkf.eu-north-1.rds.amazonaws.com;Database=DineEase;User Id=admin;Password=DineEase;";
        string originalName;
        public UpdateItemPage(string name)
        {
            InitializeComponent();
            originalName = name;

            guna2ComboBox1.Items.AddRange(new string[] { "Breakfast", "Lunch", "Dinner", "Drinks", "Dessert" });

            LoadItemData(); // Call method to load from DB
        }

        private void LoadItemData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductName, Category, Price, Description, Image FROM FoodProduct WHERE ProductName = @name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", originalName);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        guna2TextBoxName.Text = reader["ProductName"].ToString();
                        guna2TextBoxPrice.Text = reader["Price"].ToString();
                        guna2TextBoxDescription.Text = reader["Description"].ToString();


                        // Set selected category
                        string category = reader["Category"].ToString();
                        guna2ComboBox1.SelectedItem = category;

                        // Load image from byte[]
                        if (reader["Image"] != DBNull.Value)
                        {
                            byte[] imageData = (byte[])reader["Image"];
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pictureBoxItem.Image = Image.FromStream(ms);
                                imageBytes = imageData; // Store current image bytes
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Item not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading item: " + ex.Message);
                }
            }
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

        private void pictureBoxItem_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                string query = "SELECT ProductName, Category, Price, Description, Image FROM FoodProduct";
                SqlCommand cmd = new SqlCommand(query, conn);


                try
                {
                    conn.Open();
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading menu items: " + ex.Message);
                }
            }

        }

        private void guna2ButtonUpdate_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE FoodProduct 
                         SET ProductName = @name, 
                             Category = @category, 
                             Price = @price, 
                             Description = @description, 
                             Image = @image 
                         WHERE ProductName = @originalName";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", guna2TextBoxName.Text.Trim());
                cmd.Parameters.AddWithValue("@category", guna2ComboBox1.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@price", guna2TextBoxPrice.Text.Trim());
                cmd.Parameters.AddWithValue("@description", guna2TextBoxDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@originalName", originalName);

                // Set image parameter
                if (!string.IsNullOrEmpty(imagePath))
                {
                    byte[] imgBytes = File.ReadAllBytes(imagePath);
                    cmd.Parameters.AddWithValue("@image", imgBytes);
                }
                else if (imageBytes != null)
                {
                    cmd.Parameters.AddWithValue("@image", imageBytes);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@image", DBNull.Value);
                }

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Item updated successfully.");
                        this.Close();
                        new AdminHomePage().Show(); // Go back to admin
                    }
                    else
                    {
                        MessageBox.Show("Update failed. No rows affected.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating item: " + ex.Message);
                }
            }
        }


        //string imagePath = "";
        private void guna2ButtonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagePath = ofd.FileName;
                pictureBoxItem.Image = Image.FromFile(imagePath);
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

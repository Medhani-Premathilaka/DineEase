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
        //string originalName;
        int prodid;
        public UpdateItemPage(int id)//string name
        {
            InitializeComponent();
            //originalName = name;
            prodid = id;
            this.ControlBox = true;
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // or FormBorderStyle.Sizable
            this.TopMost = true;

            guna2ComboBox1.Items.AddRange(new string[] { "Breakfast", "Lunch", "Dinner", "Drinks", "Dessert" });

            LoadItemData(); // Call method to load from DB
        }

        private void LoadItemData()
        {
            string query = "SELECT ProductName, Category, Price, Description, Image FROM FoodProduct WHERE ProductID = @prodid";


            var db = dao.DBConnection.getInstance();
            using (SqlConnection cnn = db.GetConnection())

            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cnn.Open();

                //SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@prodid", prodid);

                try
                {
                    //cnn.Open();
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
                    // ✅ Add this before cnn.Close();
                    else
                    {
                        MessageBox.Show("Item not found.");
                    }
                    reader.Close();
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


        private byte[] imageBytes = null;  // store current image bytes



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
                string query = @"UPDATE FoodProduct 
                         SET ProductName = @name, Category = @addFor, Price = @price, 
                             Description = @description, Image = @image
                         WHERE ProductID = @prodid";

                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@name", guna2TextBoxName.Text);
                    cmd.Parameters.AddWithValue("@addFor", guna2ComboBox1.Text);
                    cmd.Parameters.AddWithValue("@price", guna2TextBoxPrice.Text);
                    cmd.Parameters.AddWithValue("@description", guna2TextBoxDescription.Text);
                    cmd.Parameters.AddWithValue("@prodid", prodid);

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
                        cnn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            DialogResult result = MessageBox.Show("Are you sure you want to Update Item?",
                                       "Item Update Confirmation",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                this.Hide();
                                MessageBox.Show("Updated Successfully!");
                            }
                            else
                            {
                                // do nothing, stay on the current form
                            }
                        }
                        else
                        {
                            MessageBox.Show("No matching item found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating item: " + ex.Message);
                    }
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

        private void UpdateItemPage_Load(object sender, EventArgs e)
        {

        }
    }
}

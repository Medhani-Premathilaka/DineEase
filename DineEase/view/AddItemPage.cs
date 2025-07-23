using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DineEase
{
    public partial class AddItemPage : Form
    {
        public AddItemPage()
        {
            InitializeComponent();
            guna2ComboBox1.Items.AddRange(new object[]
            {
                "Breakfast",
                "Lunch",
                "Dinner",
                "Drinks",
                "Dessert"
            });

            guna2ComboBox1.SelectedIndex = 0;
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }


        private void guna2Panel3_Validating(object sender, CancelEventArgs e)
        {

        }

        private void pictureBoxItem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        string imagePath = "";
        private void btnImportImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagePath = ofd.FileName;
                pictureBoxItem.Image = Image.FromFile(imagePath);
            }

        }

        private void guna2ButtonCreate_Click_1(object sender, EventArgs e)
        {
            string itemName = guna2TextBoxName.Text;
            string addFor = guna2ComboBox1.SelectedItem?.ToString() ?? "";
            decimal price;
            string description = guna2TextBoxDescription.Text;


            if (!decimal.TryParse(guna2TextBoxPrice.Text, out price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            byte[] imageBytes = null;
            if (!string.IsNullOrEmpty(imagePath))
            {
                imageBytes = System.IO.File.ReadAllBytes(imagePath);
            }
            var db = dao.DBConnection.getInstance();
            using (SqlConnection cnn = db.GetConnection())
            {
                //cnn.Open();
                string query = "INSERT INTO FoodProduct ( ProductName,Category, Price, Description ,Image) VALUES (@itemName, @addFor, @price, @description , @imageBytes)";

                //using (SqlConnection conn = new SqlConnection(connectionString))

                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@itemName", itemName);
                    cmd.Parameters.AddWithValue("@addFor", addFor);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@imageBytes", (object)imageBytes ?? DBNull.Value);

                    try
                    {
                        cnn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Menu item added successfully.");
                            guna2TextBoxName.Clear();
                            guna2ComboBox1.Items.Clear();
                            guna2TextBoxPrice.Clear();
                            guna2TextBoxDescription.Clear();

                            //// Show read form and load updated data
                            //read readForm = new read();
                            //readForm.Show();
                            //readForm.LoadMenuData(); // Call method to populate the grid
                        }
                        else
                        {
                            MessageBox.Show("No rows inserted.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

            }
        }

        private void guna2ButtonReset_Click_1(object sender, EventArgs e)
        {
            guna2TextBoxName.Clear();
            guna2ComboBox1.Items.Clear();
            guna2TextBoxPrice.Clear();
            guna2TextBoxDescription.Clear();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxItem_Click(object sender, EventArgs e)
        {

        }
    }
}


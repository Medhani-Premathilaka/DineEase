using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DineEase
{
    public partial class FoodDetails : Form
    {
        int productId;
        string productName = "";
        decimal price = 0;
        int quantity = 1;

        string connectionString = @"Server=dineease.chc86qwacnkf.eu-north-1.rds.amazonaws.com;Database=DineEase;User Id=admin;Password=DineEase;";

        public FoodDetails(int id)
        {
            InitializeComponent();
            productId = id;
        }

        private void LoadDetails()
        {
            string query = "SELECT * FROM FoodProduct WHERE ProductID = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", productId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    productName = reader["ProductName"].ToString();
                    price = Convert.ToDecimal(reader["Price"]);
                    lblName.Text = productName;
                    lblPrice.Text = "Price: Rs. " + price.ToString("0.00");
                    lblDesc.Text = reader["Description"].ToString();

                    byte[] imgData = (byte[])reader["Image"];
                    using (MemoryStream ms = new MemoryStream(imgData))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
            }
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void FoodDetails_Load(object sender, EventArgs e)
        {
            LoadDetails();
            lblQuantity.Text = quantity.ToString();
        }
        
        private void btnAddToOrder_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomer.Text))
            {
                MessageBox.Show("Enter customer name.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Orders (CustomerName, ProductName, Price, Quantity , OrderDate , OrderStatus) VALUES (@cust, @name, @price, @qty ,@date ,@status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cust", txtCustomer.Text);
                cmd.Parameters.AddWithValue("@name", productName);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@status", "Pending");

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Item added to order.");
                this.Close();
            }
        }

        private void Closebtn_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnIncrease_Click_1(object sender, EventArgs e)
        {
            quantity++;
            lblQuantity.Text = quantity.ToString();
        }

        private void btnDecrease_Click_1(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                quantity--;
                lblQuantity.Text = quantity.ToString();
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            quantity++;
            lblQuantity.Text = quantity.ToString();
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                quantity--;
                lblQuantity.Text = quantity.ToString();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            userViewFood frm = new userViewFood();
            frm.ShowDialog();
            
        }
    }
}

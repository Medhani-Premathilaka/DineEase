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

namespace DineEase
{
    public partial class FoodDetailsForm : Form
    {
        int productId;
        string productName = "";
        decimal price = 0;
        int quantity = 1;

        string connectionString = @"Data Source=DESKTOP-U1Q76M8\SQLEXPRESS; Initial Catalog=res_db; Integrated Security=True";

        public FoodDetailsForm(int id)
        {
            InitializeComponent();
            productId = id;
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomer.Text))
            {
                MessageBox.Show("Enter customer name.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Orders (CustomerName, ProductName, Price, Quantity) VALUES (@cust, @name, @price, @qty)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cust", txtCustomer.Text);
                cmd.Parameters.AddWithValue("@name", productName);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@qty", quantity);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Item added to order.");
                this.Close();
            }
        }

        private void FoodDetailsForm_Load(object sender, EventArgs e)
        {
            LoadDetails();
            lblQuantity.Text = quantity.ToString();
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

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            quantity++;
            lblQuantity.Text = quantity.ToString();
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                quantity--;
                lblQuantity.Text = quantity.ToString();
            }
        }
    }   
}

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


        public FoodDetails(int id)
        {
            InitializeComponent();
            this.TopMost = true;
            this.ControlBox = false;
            productId = id;
        }

        private void LoadDetails()
        {
            var db = dao.DBConnection.getInstance();
            using (SqlConnection cnn = db.GetConnection())
            {
                cnn.Open();
                string query = "SELECT * FROM FoodProduct WHERE ProductID = @id";
                //using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    //cnn.Open();
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
            var db = dao.DBConnection.getInstance();
            using (SqlConnection cnn = db.GetConnection())
            {
                cnn.Open();
                string query = "INSERT INTO Orders (CustomerName, ProductName, Price, Quantity , OrderDate , OrderStatus) VALUES (@cust, @name, @price, @qty ,@date ,@status)";
                SqlCommand sqlCommand = new SqlCommand(query, cnn);
                using (SqlCommand cmd = sqlCommand)
                {


                    cmd.Parameters.AddWithValue("@cust", txtCustomer.Text);
                    cmd.Parameters.AddWithValue("@name", productName);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@qty", quantity);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@status", "Pending");

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    MessageBox.Show("Item added to order.");
                    this.Close();
                }
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

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void increaseBtn_Click(object sender, EventArgs e)
        {
            quantity++;
            lblQuantity.Text = quantity.ToString();
        }

        private void reduceBtn_Click(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                quantity--;
                lblQuantity.Text = quantity.ToString();
            }
        }

        private void lblDesc_Click(object sender, EventArgs e)
        {

        }
    }
}

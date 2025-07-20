using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DineEase
{
    //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DineEaseDb;Integrated Security=True;";

    public partial class AdminProfile : Form
    {
        // Moved the connectionString field inside the class to fix CS0116
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DineEaseDb;Integrated Security=True;";

        public AdminProfile()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdminProfile_Load(object sender, EventArgs e)
        {
            LoadAdminDetails();
        }

        private void LoadAdminDetails()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT TOP 1 * FROM Admin"; // adjust WHERE clause as needed
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        guna2TextBox1.Text = reader["CanteenID"].ToString();
                        guna2TextBox2.Text = reader["OwnerName"].ToString();
                        guna2TextBox3.Text = reader["ContactNumber"].ToString();
                        guna2TextBox4.Text = Convert.ToDateTime(reader["ValidTill"]).ToShortDateString();
                        guna2TextBox7.Text = reader["TotalRevenue"].ToString();
                        // Load more fields if you have them
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading admin data: " + ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AdminProfile detailsForm = new AdminProfile();
            detailsForm.ShowDialog(); // or Show()

        }
    }
}

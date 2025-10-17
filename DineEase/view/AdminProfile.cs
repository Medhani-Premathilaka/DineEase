using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DineEase
{
    //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DineEaseDb;Integrated Security=True;";

    public partial class AdminProfile : Form
    {
        private string userId;

        // Moved the connectionString field inside the class to fix CS0116
        //private string connectionString = @"Server=dineease.chc86qwacnkf.eu-north-1.rds.amazonaws.com;Database=DineEase;User Id=admin;Password=DineEase;";

        public AdminProfile(string adminId = "sc12842")
        {
            InitializeComponent();
            this.userId = adminId;
            this.ControlBox = true;
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // or FormBorderStyle.Sizable
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
                var db = dao.DBConnection.getInstance();
                using (SqlConnection cnn = db.GetConnection())
                {
                    cnn.Open();
                    //conn.Open();
                    string query = "SELECT TOP 1 * FROM Admin"; // adjust WHERE clause as needed
                    SqlCommand cmd = new SqlCommand(query, cnn);
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
                    cnn.Close();
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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

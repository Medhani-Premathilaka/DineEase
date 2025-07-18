using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DineEase
{
    public partial class UserProfile : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=YourDBName;Integrated Security=True";
        private string currentStudentId; // set this from login or pass via constructor

        public UserProfile(string studentId)
        {
            InitializeComponent();
            currentStudentId = studentId;
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Name, StudentId FROM Users WHERE StudentId = @StudentId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", currentStudentId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    guna2TextBox1.Text = reader["Name"].ToString();
                    guna2TextBox2.Text = reader["StudentId"].ToString();
                    guna2TextBox2.Enabled = false; // prevent editing
                }
                reader.Close();
            }
        
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox3.Text != guna2TextBox4.Text)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE Users SET Name = @Name, Password = @Password WHERE StudentId = @StudentId";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@Name", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@Password", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@StudentId", currentStudentId);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Profile updated successfully!");
                else
                    MessageBox.Show("Update failed.");
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

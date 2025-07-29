using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DineEase.view;

namespace DineEase
{
    public partial class UserProfile : Form
    {

        private string currentStudentId = CurrentUser.UserId;// set this from login or pass via constructor
                                                             // Example after login

        public UserProfile(string studentId)
        {
            InitializeComponent();
            currentStudentId = studentId;
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            var db = dao.DBConnection.getInstance();
            using (SqlConnection cnn = db.GetConnection())
            {
                cnn.Open();
                string query = "SELECT Name, UserId FROM Users WHERE UserId = @StudentId";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@StudentId", currentStudentId);
                //cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    guna2TextBox1.Text = reader["Name"].ToString();
                    guna2TextBox2.Text = reader["UserId"].ToString();
                    guna2TextBox2.Enabled = false; // prevent editing
                }
                reader.Close();
                cnn.Close();
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

            var db = dao.DBConnection.getInstance();
            using (SqlConnection cnn = db.GetConnection())
            {
                cnn.Open();
                string updateQuery = "UPDATE Users SET Name = @Name, Password = @Password WHERE UserId = @StudentId";
                SqlCommand cmd = new SqlCommand(updateQuery, cnn);
                cmd.Parameters.AddWithValue("@Name", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@Password", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@StudentId", currentStudentId);

                //conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Profile updated successfully!");
                else
                    MessageBox.Show("Update failed.");

                cnn.Close();

            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserProfile_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DineEase
{
    public partial class UserProfile : Form
    {

        //private string currentStudentId = CurrentUser.UserId;// set this from login or pass via constructor
        private string userId;
        // Example after login

        public UserProfile(string studentId)
        {
            //Console.WriteLine($"Profile loading for: {studentId}"); // Debug
            InitializeComponent();
            this.userId = studentId;
            lblDebug.Text = $"Debug: UserID = {userId}";
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
                cmd.Parameters.AddWithValue("@StudentId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    username.Text = reader["Name"].ToString(); // Name field
                    password.Text = reader["UserId"].ToString(); // UserID field (disabled)
                    guna2TextBox2.Enabled = false;

                }
                //reader.Close();
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
                cmd.Parameters.AddWithValue("@Name", username.Text);
                cmd.Parameters.AddWithValue("@Password", password.Text); // Should hash this in production!
                cmd.Parameters.AddWithValue("@StudentId", userId);

                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Profile updated successfully!" : "Update failed.");

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

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click_2(object sender, EventArgs e)
        {

        }

        private void moreinfo_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}

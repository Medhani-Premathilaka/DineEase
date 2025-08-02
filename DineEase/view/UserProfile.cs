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
            // lblDebug.Text = $"Debug: UserID = {userId}";
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

        private void update_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            guna2TextBox6.Visible = false;
            guna2TextBox5.Visible = false;
            update.Visible = false;
            guna2HtmlLabel4.Visible = false;
            guna2HtmlLabel3.Visible = false;
            lblError.Visible = false;
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

            guna2TextBox6.Visible = true;
            guna2TextBox5.Visible = true;
            update.Visible = true;
            guna2HtmlLabel4.Visible = true;
            guna2HtmlLabel3.Visible = true;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string newpassword = guna2TextBox6.Text.Trim();
            string confrimpassword = guna2TextBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(newpassword) || string.IsNullOrWhiteSpace(confrimpassword))
            {
                lblError.Text = "Required both feilds";
                lblError.Visible = true;
            }

            if (guna2TextBox6.Text == guna2TextBox5.Text)
            {
                Security security = new Security();
                string hashedpassword = security.HashPassword(newpassword);

                var db = dao.DBConnection.getInstance();
                using (SqlConnection cnn = db.GetConnection())
                {
                    cnn.Open();
                    string update = "UPDATE Users set Password = @password where UserId = @StudentId";
                    SqlCommand cmd = new SqlCommand(update, cnn);
                    cmd.Parameters.AddWithValue("@password", hashedpassword);
                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Profile updated successfully!" : "Update failed.");

                    cnn.Close();
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

        }

        private void guna2TextBox6_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

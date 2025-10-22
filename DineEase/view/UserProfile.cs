using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DineEase.view;

namespace DineEase
{
    public partial class UserProfile : Form
    {

        //private string currentStudentId = CurrentUser.UserId;// set this from login or pass via constructor
        private string userId;
        // Example after login

        public UserProfile(string studentId)
        {
            InitializeComponent(); // only once
            this.ControlBox = true;
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.userId = studentId;



            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            try
            {
                var db = dao.DBConnection.getInstance();
                using (SqlConnection cnn = db.GetConnection())
                {
                    cnn.Open();
                    string query = "SELECT * FROM Users WHERE UserId = @StudentId";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // make sure these match your control names!
                                username.Text = reader["Name"].ToString();
                                studentid.Text = reader["UserId"].ToString();
                                guna2TextBox6.Text = reader["Email"].ToString();
                                guna2TextBox5.Text = reader["Role"].ToString();
                                guna2TextBox5.ReadOnly = true;
                                studentid.ReadOnly = true;
                                // guna2TextBox2.Enabled = false;
                                MessageBox.Show("User ID received: " + userId);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
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
            //guna2TextBox6.Visible = false;
            //guna2TextBox5.Visible = false;
            //update.Visible = false;
            //guna2HtmlLabel4.Visible = false;
            //guna2HtmlLabel3.Visible = false;
            //lblError.Visible = false;
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
            var changePasswordForm = new DineEase.view.ChangePassword(CurrentUser.UserId);
            changePasswordForm.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {


        }

        private void guna2TextBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

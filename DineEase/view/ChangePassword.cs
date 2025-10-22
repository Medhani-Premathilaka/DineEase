using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DineEase.view
{
    public partial class ChangePassword : Form
    {
        string userId = CurrentUser.UserId; // set this from login or pass via constructor
        //string userId = "sc12394";
        public ChangePassword(string studentId)
        {
            //this.userId = studentId;
            InitializeComponent();

            guna2TextBox5.PasswordChar = '●';
            guna2TextBox6.PasswordChar = '●';
        }

        private void update_Click_1(object sender, EventArgs e)
        {
            string newpassword = guna2TextBox6.Text.Trim();
            string confrimpassword = guna2TextBox5.Text.Trim();
            string strongPasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            if (string.IsNullOrWhiteSpace(newpassword) || string.IsNullOrWhiteSpace(confrimpassword))
            {
                lblError.Text = "Required both feilds";
                lblError.Visible = true;

                return;
            }
            if (!Regex.IsMatch(newpassword, strongPasswordPattern))
            {
                lblError.Text = "Enter a STRONG PASSWORD";
                lblError.Visible = true;
                return;
            }
            if (newpassword == confrimpassword)
            {
                Security security = new Security();
                string hashedpassword = security.HashPassword(newpassword);

                try
                {
                    var db = dao.DBConnection.getInstance();
                    using (SqlConnection cnn = db.GetConnection())
                    {
                        cnn.Open();
                        //MessageBox.Show("User ID for update: " + userId);
                        string update = "UPDATE Users SET Password = @password WHERE UserId = @StudentId";
                        SqlCommand cmd = new SqlCommand(update, cnn);
                        cmd.Parameters.AddWithValue("@password", hashedpassword);
                        cmd.Parameters.AddWithValue("@StudentId", userId);
                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(rows > 0 ? "Profile updated successfully!" : "Update failed.");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating password: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            //  guna2HtmlLabel5.Visible = false;
            lblError.Visible = false;
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }


    }
}

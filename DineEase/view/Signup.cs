using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DineEase
{
    public partial class Signup : Form
    {
        private bool isEmailHintVisible = true;
        public Signup()
        {
            InitializeComponent();
            password.PasswordChar = '●';      // Displays dots for password input
            confirmpwd.PasswordChar = '●';    // Displays dots for confirm password input

            email.Text = "example@gmail.com";
            email.Enter += Email_Enter;
            email.Leave += Email_Leave;
        }
        private void Email_Enter(object sender, EventArgs e)
        {
            if (isEmailHintVisible)
            {
                email.Text = "";
                isEmailHintVisible = false;
            }
        }

        public void Email_Leave(Object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(email.Text))
            {
                email.Text = "example@gmail.com";
                isEmailHintVisible = true;
            }
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void register_Click(object sender, EventArgs e)
        {
            string enteredUsername = username.Text.Trim();
            string enteredPassword = password.Text;
            string confirmPassword = confirmpwd.Text;
            string enteredName = name.Text.Trim();
            string enterdemail = email.Text.Trim();
            string role = "USER";

            if (string.IsNullOrWhiteSpace(enteredUsername) ||
        string.IsNullOrWhiteSpace(enteredPassword) ||
        string.IsNullOrWhiteSpace(confirmPassword) ||
        string.IsNullOrWhiteSpace(enteredName) ||
        string.IsNullOrWhiteSpace(enterdemail))
            {
                lblError1.Text = "All fields are required.";
                lblError1.Visible = true;
                return;
            }

            if (!IsValidEmail(enterdemail))
            {
                lblError.Text = "Please enter a valid email address.";
                lblError.Visible = true;
                return;
            }
            if (enteredPassword == confirmPassword)
            {
                Security security = new Security();
                string hashedPassword = security.HashPassword(enteredPassword);
                var db = dao.DBConnection.getInstance();
                using (SqlConnection cnn = db.GetConnection())
                {
                    cnn.Open();

                    //cnn.Open();
                    string query = "INSERT INTO Users(UserId, Password, Role, Email,Name) VALUES (@username, @password, @role, @email, @name)";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@username", enteredUsername);
                        cmd.Parameters.AddWithValue("password", hashedPassword);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@email", enterdemail);
                        cmd.Parameters.AddWithValue("@name", enteredName);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            lblError.Text = "Registration Successfull!";
                            lblError.Visible = true;

                            Form1 loginForm = new Form1();
                            loginForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            lblError.Text = "Registration failed. Please try again.";
                            lblError.Visible = true;
                        }
                    }
                    cnn.Close();

                }

            }
            else
            {
                lblError.Text = "Passwords do not match. Try Again";
                lblError.Visible = true;
                return;
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void Signup_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblError1.Visible = false;
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void confirmpwd_TextChanged(object sender, EventArgs e)
        {

        }



    }
}

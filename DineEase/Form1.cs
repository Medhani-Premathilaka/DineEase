using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DineEase
{
    public partial class Form1 : Form

    {

        private bool isUsernameHintVisible = true;
        private bool isPasswordHintVisible = true;
        private Color HashToColor(string input)
        {
            // Get a hash code for the string
            int hash = input.GetHashCode();

            // Use the hash to generate RGB values
            byte r = (byte)((hash & 0xFF0000) >> 16);
            byte g = (byte)((hash & 0x00FF00) >> 8);
            byte b = (byte)(hash & 0x0000FF);

            return Color.FromArgb(r, g, b);
        }

        public Form1()
        {
            InitializeComponent();
            password.PasswordChar = '\0';

            username.Text = "Enter username";
            password.Text = "Enter password";
            username.ForeColor = Color.Gray;
            password.ForeColor = Color.Gray;

            username.Enter += Username_Enter;
            username.Leave += Username_Leave;
            password.Enter += Password_Enter;
            password.Leave += Password_Leave;
        }
        private void Username_Enter(object sender, EventArgs e)
        {
            if (isUsernameHintVisible)
            {
                username.Text = "";
                username.ForeColor = Color.Gray;
                isUsernameHintVisible = false;
            }
        }
        private void Username_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(username.Text))
            {
                username.Text = "Enter username";
                username.ForeColor = Color.Gray;
                isUsernameHintVisible = true;
            }
        }
        private void Password_Enter(object sender, EventArgs e)
        {
            if (isPasswordHintVisible)
            {
                password.Text = "";
                password.ForeColor = Color.Gray;
                password.PasswordChar = '●'; // Hide password
                isPasswordHintVisible = false;
            }
        }
        private void Password_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(password.Text))
            {
                password.PasswordChar = '\0'; // Show hint as plain text
                password.Text = "Enter password";
                password.ForeColor = Color.Gray;
                isPasswordHintVisible = true;
            }
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:ruh.ac.lk@gmail.com?subject=Support%20Request&body=Hello");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
        }

        private void signin_Click(object sender, EventArgs e)
        {

        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {

            string connectionString;
            SqlConnection cnn;


            connectionString = @"Data Source=medhani-pc\sqlexpress;Initial Catalog=DineEase;Integrated Security=True";
            string enteredUsername = username.Text.Trim();
            string enteredPassword = password.Text.Trim();
            Security security = new Security();
            string hashedPassword = security.HashPassword(enteredPassword);



            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string query = "SELECT Role FROM Users WHERE Username = @username AND Password = @password";
            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cmd.Parameters.AddWithValue("@username", enteredUsername);
                cmd.Parameters.AddWithValue("@password", hashedPassword);


                var role = cmd.ExecuteScalar() as string;


                //if (role == "ADMIN")
                //{
                //    AdminHomePage adminForm = new AdminHomePage();
                //    adminForm.Show();
                //    this.Hide();
                //}
                //else if (role == "USER")
                //{
                //    User userForm = new User();
                //    userForm.Show();
                //    this.Hide();
                //}
                //else
                //{
                //    lblerror.Text = "Invalid username or password.";
                //    lblerror.Visible = true;
                //}
            }


            cnn.Close();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();

        }
    }
}

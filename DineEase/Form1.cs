using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DineEase
{
    public partial class Form1 : Form
    {
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
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string query = "SELECT Role FROM Users WHERE Username = @username AND Password = @password";
            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cmd.Parameters.AddWithValue("@username", enteredUsername);
                cmd.Parameters.AddWithValue("@password", enteredPassword);

                var role = cmd.ExecuteScalar() as string;

                if (role == "ADMIN")
                {
                    Admin adminForm = new Admin();
                    adminForm.Show();
                    this.Hide();
                }
                else if (role == "USER")
                {
                    User userForm = new User();
                    userForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
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

        }
    }
}

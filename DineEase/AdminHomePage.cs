using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DineEase
{
    public partial class AdminHomePage : Form
    {
        string connectionString = @"Data Source=DESKTOP-TAR59NP\SQLEXPRESS;Initial Catalog=dineEase;Integrated Security=True";

        public AdminHomePage()
        {
            InitializeComponent();
            this.Load += AdminHomePage_Load;
        }

        private void LoadMenuItemsAsCards()
        {
            flowLayoutPanel1.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT name, addFor, price, description, imagePath FROM menu";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string name = reader["name"].ToString();
                        string addFor = reader["addFor"].ToString();
                        string price = reader["price"].ToString();
                        string description = reader["description"].ToString();
                        string imagePath = reader["imagePath"].ToString();

                        Panel card = new Panel
                        {
                            Width = 200,
                            Height = 280,
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = Color.White,
                            Margin = new Padding(10)
                        };

                        PictureBox picture = new PictureBox
                        {
                            Width = 180,
                            Height = 140,
                            Top = 10,
                            Left = 10,
                            SizeMode = PictureBoxSizeMode.Zoom,
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        if (File.Exists(imagePath))
                        {
                            using (var bmpTemp = new Bitmap(imagePath))
                            {
                                picture.Image = new Bitmap(bmpTemp);
                            }
                        }

                        Label nameLabel = new Label
                        {
                            Text = "Name: " + name,
                            Top = 160,
                            Left = 10,
                            Width = 180,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold)
                        };

                        Label priceLabel = new Label
                        {
                            Text = "Price: Rs. " + price,
                            Top = 185,
                            Left = 10,
                            Width = 180
                        };

                        Label addForLabel = new Label
                        {
                            Text = "Add For: " + addFor,
                            Top = 210,
                            Left = 10,
                            Width = 180
                        };

                        Label descLabel = new Label
                        {
                            Text = "Desc: " + description,
                            Top = 235,
                            Left = 10,
                            Width = 180,
                            Height = 40,
                            AutoSize = false
                        };

                        card.Controls.Add(picture);
                        card.Controls.Add(nameLabel);
                        card.Controls.Add(priceLabel);
                        card.Controls.Add(addForLabel);
                        card.Controls.Add(descLabel);

                        flowLayoutPanel1.Controls.Add(card);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading menu items: " + ex.Message);
                }
            }
        }


        private void AdminHomePage_Load(object sender, EventArgs e)
        {
            LoadMenuItemsAsCards();

        }




        private void guna2ButtonAddNewItem_Click(object sender, EventArgs e)
        {
            AddItemPage addItemPage = new AddItemPage();
            addItemPage.Show();
            this.Hide();
        }


        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {
            // Optional: remove or customize if unused
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void historyButton_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void profileButton_Click(object sender, EventArgs e)
        {

        }
    }
}

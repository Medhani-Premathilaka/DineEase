using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;


namespace DineEase
{
    public partial class AdminHomePage : Form
    {
        string connectionString = @"Server=dineease.chc86qwacnkf.eu-north-1.rds.amazonaws.com;Database=DineEase;User Id=admin;Password=DineEase;";

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
                string query = "SELECT ProductName, Category, Price, Description, Image FROM FoodProduct";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string name = reader["ProductName"].ToString();
                        string addFor = reader["Category"].ToString();
                        string price = reader["Price"].ToString();
                        string description = reader["Description"].ToString();



                        Guna2Panel card = new Guna2Panel
                        {
                            Width = 220,
                            Height = 340,
                            BorderRadius = 15,
                            FillColor = Color.White,
                            ShadowDecoration = { Enabled = true, BorderRadius = 15, Shadow = new Padding(5) },
                            Margin = new Padding(15),
                            BackColor = Color.Transparent // Ensure shadow shows properly
                        };


                        PictureBox picture = new PictureBox
                        {
                            Width = 180,
                            Height = 140,
                            Top = 10,
                            Left = 20,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BackColor = Color.White, // Match card background
                            BorderStyle = BorderStyle.None, // Remove old border
                            Margin = new Padding(10),
                            Padding = new Padding(5)
                        };


                        if (reader["Image"] != DBNull.Value)
                        {
                            byte[] imageData = reader["Image"] as byte[];
                            if (imageData != null && imageData.Length > 0)
                            {
                                using (var ms = new MemoryStream(imageData))
                                {
                                    picture.Image = Image.FromStream(ms);
                                }
                            }
                        }

                        Label nameLabel = new Label
                        {
                            Text =  name,
                            Top = 160,
                            Left = 10,
                            Width = 200,
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                            ForeColor = Color.FromArgb(40, 40, 40) // Dark gray for readability
                        };

                        Label priceLabel = new Label
                        {
                            Text = "Price: Rs. " + price,
                            Top = 185,
                            Left = 10,
                            Width = 200,
                            Font = new Font("Segoe UI", 9, FontStyle.Regular),
                            ForeColor = Color.FromArgb(70, 70, 70)
                        };

                        Label addForLabel = new Label
                        {
                            Text = "Category: " + addFor,
                            Top = 210,
                            Left = 10,
                            Width = 200,
                            Font = new Font("Segoe UI", 9, FontStyle.Regular),
                            ForeColor = Color.FromArgb(70, 70, 70)
                        };

                        Label descLabel = new Label
                        {
                            Text = "Details: " + description,
                            Top = 235,
                            Left = 10,
                            Width = 200,
                            Height = 40,
                            AutoSize = false,
                            Font = new Font("Segoe UI", 8, FontStyle.Italic),
                            ForeColor = Color.FromArgb(100, 100, 100)
                        };

                        Guna2Button editButton = new Guna2Button
                        {
                            Text = "✏️ Edit",
                            Width = 90,
                            Height = 30,
                            Left = 10,
                            Top = 285,
                            BorderRadius = 10,
                            FillColor = Color.FromArgb(0, 191, 255),
                            Font = new Font("Segoe UI", 9, FontStyle.Bold),
                            ForeColor = Color.White,
                            Cursor = Cursors.Hand
                        };

                        editButton.Click += (s, e) =>
                        {
                            UpdateItemPage updatePage = new UpdateItemPage(name);
                            updatePage.Show();
                            this.Hide();
                        };

                        Guna2Button deleteButton = new Guna2Button
                        {
                            Text = "🗑️ Delete",
                            Width = 90,
                            Height = 30,
                            Left = 115,
                            Top = 285,
                            BorderRadius = 10,
                            FillColor = Color.IndianRed,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold),
                            ForeColor = Color.White,
                            Cursor = Cursors.Hand
                        };

                        deleteButton.Click += (s, e) =>
                        {
                            DeleteMenuItem(name);
                        };

                        card.MouseEnter += (s, e) =>
                        {
                            card.FillColor = Color.FromArgb(245, 245, 245);
                        };
                        card.MouseLeave += (s, e) =>
                        {
                            card.FillColor = Color.White;
                        };


                        card.Controls.Add(picture);
                        card.Controls.Add(nameLabel);
                        card.Controls.Add(priceLabel);
                        card.Controls.Add(addForLabel);
                        card.Controls.Add(descLabel);
                        card.Controls.Add(editButton);
                        card.Controls.Add(deleteButton);

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

        private void DeleteMenuItem(string itemName)
        {
            DialogResult dialogResult = MessageBox.Show(
                $"Are you sure you want to delete '{itemName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.No)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM menu WHERE name = @name";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@name", itemName);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item deleted successfully.");
                            LoadMenuItemsAsCards(); // Refresh UI
                        }
                        else
                        {
                            MessageBox.Show("Item not found or already deleted.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting item: " + ex.Message);
                    }
                }
            }
        }



        private void AdminHomePage_Load(object sender, EventArgs e)
        {
            LoadMenuItemsAsCards();

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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminHomePage_Load_1(object sender, EventArgs e)
        {

        }

        private void guna2ButtonAddNewItem_Click_1(object sender, EventArgs e)
        {
            AddItemPage addItemPage = new AddItemPage();
            addItemPage.Show();
            this.Hide();

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}

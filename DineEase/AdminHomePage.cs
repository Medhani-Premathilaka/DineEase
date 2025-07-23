using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


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

                    var itemsByCategory = new Dictionary<string, List<Dictionary<string, object>>>();

                    while (reader.Read())
                    {
                        string category = reader["Category"].ToString();

                        if (!itemsByCategory.ContainsKey(category))
                            itemsByCategory[category] = new List<Dictionary<string, object>>();

                        var item = new Dictionary<string, object>();
                        foreach (var col in new[] { "ProductName", "Price", "Description", "Image", "Category" })
                            item[col] = reader[col];

                        itemsByCategory[category].Add(item);
                    }
                    reader.Close();

                    // Your desired display order:
                    string[] displayOrder = { "Breakfast", "Lunch", "Dinner", "Drinks", "Desserts" };

                    foreach (string category in displayOrder)
                    {
                        if (!itemsByCategory.ContainsKey(category))
                            continue;

                        // Add category label once per category
                        Label categoryLabel = new Label
                        {
                            Text = category,
                            Font = new Font("Segoe UI Semibold", 16, FontStyle.Bold),
                            ForeColor = Color.White, // White text stands out on dark purple
                            BackColor = Color.FromArgb(102, 51, 153), // Dark purple background
                            AutoSize = false,
                            Width = flowLayoutPanel1.Width - 30,
                            Height = 45,
                            TextAlign = ContentAlignment.MiddleCenter, // Center align text
                            Margin = new Padding(10, 20, 10, 5),
                            Padding = new Padding(0),
                            BorderStyle = BorderStyle.None, // Optional: FixedSingle if you want a border
                        };


                        flowLayoutPanel1.Controls.Add(categoryLabel);

                        // Add cards under this category
                        foreach (var item in itemsByCategory[category])
                        {
                            string name = item["ProductName"].ToString();
                            string addFor = item["Category"].ToString();
                            string price = item["Price"].ToString();
                            string description = item["Description"].ToString();
                            byte[] imageData = item["Image"] != DBNull.Value ? (byte[])item["Image"] : null;

                            Guna2Panel card = CreateCard(name, addFor, price, description, imageData);
                            flowLayoutPanel1.Controls.Add(card);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading menu items: " + ex.Message);
                }
            }
        }




        private Guna2Panel CreateCard(string name, string addFor, string price, string description, byte[] imageData)
        {
            Guna2Panel card = new Guna2Panel
            {
                Width = 220,
                Height = 340,
                BorderRadius = 15,
                FillColor = Color.White,
                ShadowDecoration = { Enabled = true, BorderRadius = 15, Shadow = new Padding(5) },
                Margin = new Padding(15),
                BackColor = Color.Transparent
            };

            PictureBox picture = new PictureBox
            {
                Width = 180,
                Height = 140,
                Top = 10,
                Left = 20,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                Padding = new Padding(5)
            };

            if (imageData != null && imageData.Length > 0)
            {
                using (var ms = new MemoryStream(imageData))
                {
                    picture.Image = Image.FromStream(ms);
                }
            }

            Label nameLabel = new Label
            {
                Text = name,
                Top = 160,
                Left = 10,
                Width = 200,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 40)
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

            card.MouseEnter += (s, e) => card.FillColor = Color.FromArgb(245, 245, 245);
            card.MouseLeave += (s, e) => card.FillColor = Color.White;

            card.Controls.Add(picture);
            card.Controls.Add(nameLabel);
            card.Controls.Add(priceLabel);
            card.Controls.Add(addForLabel);
            card.Controls.Add(descLabel);
            card.Controls.Add(editButton);
            card.Controls.Add(deleteButton);

            return card;
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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            
        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Form is maximized
                Console.WriteLine("Maximized!");
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                // Form is restored
                Console.WriteLine("Restored!");
            }
        }
    }
}

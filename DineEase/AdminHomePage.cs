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
                            Width = 220,
                            Height = 340,
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = Color.White,
                            Margin = new Padding(10)
                        };

                        PictureBox picture = new PictureBox
                        {
                            Width = 180,
                            Height = 140,
                            Top = 10,
                            Left = 20,
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
                            Width = 200,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold)
                        };

                        Label priceLabel = new Label
                        {
                            Text = "Price: Rs. " + price,
                            Top = 185,
                            Left = 10,
                            Width = 200
                        };

                        Label addForLabel = new Label
                        {
                            Text = "Add For: " + addFor,
                            Top = 210,
                            Left = 10,
                            Width = 200
                        };

                        Label descLabel = new Label
                        {
                            Text = "Desc: " + description,
                            Top = 235,
                            Left = 10,
                            Width = 200,
                            Height = 40,
                            AutoSize = false
                        };

                        Button editButton = new Button
                        {
                            Text = "Edit",
                            Width = 80,
                            Height = 30,
                            Left = 10,
                            Top = 285,
                            BackColor = Color.LightBlue
                        };
                        editButton.Click += (s, e) =>
                        {
                            UpdateItemPagecs updatePage = new UpdateItemPagecs(name, addFor, price, description);
                            updatePage.Show();
                            this.Hide();
                        };

                        Button deleteButton = new Button
                        {
                            Text = "Delete",
                            Width = 80,
                            Height = 30,
                            Left = 110,
                            Top = 285,
                            BackColor = Color.IndianRed,
                            ForeColor = Color.White
                        };
                        deleteButton.Click += (s, e) =>
                        {
                            DeleteMenuItem(name);
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

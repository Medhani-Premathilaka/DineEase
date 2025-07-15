using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

<<<<<<< HEAD
        private void LoadMenuItemsAsCards()
        {
            flowLayoutPanel1.Controls.Clear();
=======
        private void guna2ButtonAddNewItem_Click(object sender, EventArgs e)
        {
            AddItemPage addItemPage = new AddItemPage(); // create instance of form2
            addItemPage.Show(); // open the AddItemPage
            this.Hide(); // optional: hide AdminHomePage
        }

        private void AdminHomePage_Load(object sender, EventArgs e)
        {
            LoadItemsIntoGrid();
        }

        private void LoadItemsIntoGrid()
        {
            guna2DataGridView1.Columns.Clear(); // 🔴 Clear existing columns first
            guna2DataGridView1.DataSource = null; // 🔴 Clear existing data
>>>>>>> 73cd2abff29f01b5c453785eb554b2e94d247ba4

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT name, addFor, price, description FROM menu";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
<<<<<<< HEAD
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
                            UpdateItemPagecs updateItemPage = new UpdateItemPagecs(name, addFor, price, description);
                            UpdateItemPagecs updatePage = updateItemPage;
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
=======
                    adapter.Fill(dt);
                    guna2DataGridView1.DataSource = dt;
>>>>>>> 73cd2abff29f01b5c453785eb554b2e94d247ba4
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading menu items: " + ex.Message);
                }
            }
        }

<<<<<<< HEAD
        private void DeleteMenuItem(string itemName)
        {
=======

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ButtonDelete_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            // Get the 'name' value of the selected row
            int selectedRowIndex = guna2DataGridView1.SelectedRows[0].Index;
            string itemName = guna2DataGridView1.Rows[selectedRowIndex].Cells["name"].Value.ToString();

            // Confirm deletion
>>>>>>> 73cd2abff29f01b5c453785eb554b2e94d247ba4
            DialogResult dialogResult = MessageBox.Show(
                $"Are you sure you want to delete '{itemName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.No)
                return;

            // Delete the selected item from the database
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
<<<<<<< HEAD
                            LoadMenuItemsAsCards(); // Refresh UI
=======
                            LoadItemsIntoGrid(); // Refresh the table
>>>>>>> 73cd2abff29f01b5c453785eb554b2e94d247ba4
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


<<<<<<< HEAD


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

=======
            UpdateItemPagecs updatePage = new UpdateItemPagecs(name, addFor, price, description);
            updatePage.Show();
            this.Hide(); // Optional
>>>>>>> 73cd2abff29f01b5c453785eb554b2e94d247ba4
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

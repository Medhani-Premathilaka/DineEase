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

        private void AdminHomePage_Load(object sender, EventArgs e)
        {
            //if (guna2DataGridView1.Columns.Contains("image"))
            //{
            //    DataGridViewImageColumn imgCol = (DataGridViewImageColumn)guna2DataGridView1.Columns["image"];
            //    imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            //}


            guna2DataGridView1.RowTemplate.Height = 100; // For image display
            guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            guna2DataGridView1.MultiSelect = false;

            LoadItemsIntoGrid();
        }

        private void LoadItemsIntoGrid()
        {
            guna2DataGridView1.Columns.Clear(); // Clear all columns
            guna2DataGridView1.Rows.Clear();    // Clear existing rows
            guna2DataGridView1.RowTemplate.Height = 100;

            // 🔵 Manually add columns (match this order with .Rows.Add)
            guna2DataGridView1.Columns.Add("name", "Name");

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.Name = "image";
            imgCol.HeaderText = "Image";
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            guna2DataGridView1.Columns.Add(imgCol);

            guna2DataGridView1.Columns.Add("addFor", "Add For");
            guna2DataGridView1.Columns.Add("price", "Price");
            guna2DataGridView1.Columns.Add("description", "Description");

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

                        // Load image safely
                        Image img = null;
                        if (File.Exists(imagePath))
                        {
                            using (var bmpTemp = new Bitmap(imagePath))
                            {
                                img = new Bitmap(bmpTemp); // clone to avoid locking
                            }
                        }

                        // 🔵 Order must match the columns
                        guna2DataGridView1.Rows.Add(name, img, addFor, price, description);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }


        private void guna2ButtonAddNewItem_Click(object sender, EventArgs e)
        {
            AddItemPage addItemPage = new AddItemPage();
            addItemPage.Show();
            this.Hide();
        }

        private void guna2ButtonDelete_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            int selectedRowIndex = guna2DataGridView1.SelectedRows[0].Index;
            string itemName = guna2DataGridView1.Rows[selectedRowIndex].Cells["name"].Value.ToString();

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
                            LoadItemsIntoGrid();
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

        private void guna2ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to update.");
                return;
            }

            DataGridViewRow row = guna2DataGridView1.SelectedRows[0];

            string name = row.Cells["name"].Value.ToString();
            string addFor = row.Cells["addFor"].Value.ToString();
            string price = row.Cells["price"].Value.ToString();
            string description = row.Cells["description"].Value.ToString();

            UpdateItemPagecs updatePage = new UpdateItemPagecs(name, addFor, price, description);
            updatePage.Show();
            this.Hide();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle image clicks or row interaction here
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {
            // Optional: remove or customize if unused
        }
    }
}

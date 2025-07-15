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

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT name, addFor, price, description FROM menu";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dt);
                    guna2DataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }


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
                            LoadItemsIntoGrid(); // Refresh the table
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
            this.Hide(); // Optional
        }
    }
}

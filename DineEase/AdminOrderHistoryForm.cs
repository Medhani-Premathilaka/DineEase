using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DineEase
{
    public partial class AdminOrderHistoryForm : Form
    {
        private string connectionString = @"Data Source=LAPTOP-M18U5G4F\SQLEXPRESS;Initial Catalog=DineEase;Integrated Security=True";

        public AdminOrderHistoryForm()
        {
            InitializeComponent();
            this.Load += AdminOrderHistoryForm_Load;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            dgvOrders.CellClick += dgvOrders_CellClick;
        }

        private void AdminOrderHistoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Database connection successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message);
            }

            // Add filter options to ComboBox
            cmbFilter.Items.AddRange(new string[] { "All", "Confirmed", "Rejected", "Recent", "Last Month" });
            cmbFilter.SelectedIndex = 0; // Default to All

            LoadOrders("All");
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbFilter.SelectedItem.ToString();
            LoadOrders(selected);
        }

        private void LoadOrders(string filter)
        {
            string query = "";

            switch (filter)
            {
                case "Confirmed":
                    query = "SELECT * FROM ORDERS WHERE Status = 'Confirmed'";
                    break;
                case "Rejected":
                    query = "SELECT * FROM ORDERS WHERE Status = 'Rejected'";
                    break;
                case "Recent":
                    query = "SELECT * FROM ORDERS WHERE OrderDate >= DATEADD(DAY, -7, GETDATE())";
                    break;
                case "Last Month":
                    query = @"SELECT * FROM ORDERS 
                              WHERE MONTH(OrderDate) = MONTH(DATEADD(MONTH, -1, GETDATE()))
                              AND YEAR(OrderDate) = YEAR(DATEADD(MONTH, -1, GETDATE()))";
                    break;
                default:
                    query = "SELECT * FROM ORDERS";
                    break;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Add Action column to determine button text
                if (!dt.Columns.Contains("Action"))
                    dt.Columns.Add("Action", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    string status = row["Status"].ToString();
                    row["Action"] = status == "Pending" ? "Accept" : status;
                }

                dgvOrders.DataSource = dt;

                // Add button column if not already present
                if (!dgvOrders.Columns.Contains("ActionButton"))
                {
                    DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                    btnColumn.HeaderText = "Action";
                    btnColumn.Name = "ActionButton";
                    btnColumn.UseColumnTextForButtonValue = false;
                    dgvOrders.Columns.Add(btnColumn);
                }

                // Set text for buttons
                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    row.Cells["ActionButton"].Value = row.Cells["Action"].Value;
                }

                // Hide helper column
                dgvOrders.Columns["Action"].Visible = false;
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrders.Columns[e.ColumnIndex].Name == "ActionButton")
            {
                int orderId = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["OrderID"].Value);
                string action = dgvOrders.Rows[e.RowIndex].Cells["ActionButton"].Value.ToString();

                MessageBox.Show($"Order {orderId} is currently {action}", "Order Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optional: Update the status if action == "Accept"
                if (action == "Accept")
                {
                    UpdateOrderStatus(orderId, "Confirmed");
                    LoadOrders(cmbFilter.SelectedItem.ToString()); // Reload the current filter
                }
            }
        }

        private void UpdateOrderStatus(int orderId, string newStatus)
        {
            string query = "UPDATE ORDERS SET Status = @status WHERE OrderID = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", orderId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

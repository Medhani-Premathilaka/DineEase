using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DineEase
{
    public partial class ViewUserHistory : Form
    {
        private readonly int _userId;

        //private readonly string _connectionString = @"Data Source=LAPTOP-M18U5G4F\SQLEXPRESS;Initial Catalog=DINEASE;Integrated Security=True;";

        public ViewUserHistory(int userId)
        {
            InitializeComponent();
            _userId = userId;
            InitializeFilterCombo();
            dgvOrders.AutoGenerateColumns = false;
            SetupDataGridViewColumns();
        }

        private void ViewUserHistory_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void InitializeFilterCombo()
        {
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("All");
            cmbFilter.Items.Add("Confirmed");
            cmbFilter.Items.Add("Rejected");
            cmbFilter.Items.Add("Recent");      // last 7 days
            cmbFilter.Items.Add("Last Month");  // last 30 days
            cmbFilter.SelectedIndex = 0;
            cmbFilter.SelectedIndexChanged += (s, e) => LoadOrders();
        }

        private void SetupDataGridViewColumns()
        {
            dgvOrders.Columns.Clear();

            // OrderID (hidden)
            var colId = new DataGridViewTextBoxColumn();
            colId.DataPropertyName = "OrderID";
            colId.Name = "OrderID";
            colId.Visible = false;
            dgvOrders.Columns.Add(colId);

            // OrderDate
            var colDate = new DataGridViewTextBoxColumn();
            colDate.DataPropertyName = "OrderDate";
            colDate.HeaderText = "Order Date";
            colDate.Name = "OrderDate";
            colDate.ReadOnly = true;
            dgvOrders.Columns.Add(colDate);

            // Total
            var colTotal = new DataGridViewTextBoxColumn();
            colTotal.DataPropertyName = "Total";
            colTotal.HeaderText = "Total (LKR)";
            colTotal.Name = "Total";
            colTotal.ReadOnly = true;
            dgvOrders.Columns.Add(colTotal);

            // Status
            var colStatus = new DataGridViewTextBoxColumn();
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Status";
            colStatus.Name = "Status";
            colStatus.ReadOnly = true;
            dgvOrders.Columns.Add(colStatus);

            // Items (short)
            var colItems = new DataGridViewTextBoxColumn();
            colItems.DataPropertyName = "Items";
            colItems.HeaderText = "Items";
            colItems.Name = "Items";
            colItems.ReadOnly = true;
            dgvOrders.Columns.Add(colItems);

            // Action button (Details)
            var btnCol = new DataGridViewButtonColumn();
            btnCol.HeaderText = "Action";
            btnCol.Name = "Action";
            btnCol.Text = "Details";
            btnCol.UseColumnTextForButtonValue = true;
            dgvOrders.Columns.Add(btnCol);

            dgvOrders.CellClick += DgvOrders_CellClick;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.ReadOnly = false; // button column needs editable false per-row handling
        }

        private void DgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvOrders.Columns[e.ColumnIndex].Name == "Action")
            {
                // Show details of the selected order
                var row = dgvOrders.Rows[e.RowIndex];
                var orderId = row.Cells["OrderID"].Value;
                var orderDate = row.Cells["OrderDate"].Value;
                var total = row.Cells["Total"].Value;
                var status = row.Cells["Status"].Value?.ToString() ?? "";
                var items = row.Cells["Items"].Value?.ToString() ?? "";

                string msg = $"Order ID: {orderId}\nDate: {orderDate}\nTotal: {total}\nStatus: {status}\n\nItems:\n{items}";
                MessageBox.Show(msg, "Order Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            string selectedFilter = cmbFilter.SelectedItem?.ToString() ?? "All";

            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;

                    // Base query: filter by user id always
                    string sql = "SELECT OrderID, OrderDate, Total, Status, Items FROM dbo.ORDERS WHERE UserID = @UserID";

                    // Apply filter
                    if (selectedFilter == "Confirmed")
                    {
                        sql += " AND Status = 'Confirmed'";
                    }
                    else if (selectedFilter == "Rejected")
                    {
                        sql += " AND Status = 'Rejected'";
                    }
                    else if (selectedFilter == "Recent")
                    {
                        // last 7 days
                        sql += " AND OrderDate >= DATEADD(day, -7, GETDATE())";
                    }
                    else if (selectedFilter == "Last Month")
                    {
                        // last 30 days
                        sql += " AND OrderDate >= DATEADD(day, -30, GETDATE())";
                    }
                    // else All -> no extra condition

                    sql += " ORDER BY OrderDate DESC";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@UserID", _userId);

                    var adapter = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    // Format OrderDate column as readable string before bind
                    if (!dt.Columns.Contains("OrderDateFormatted"))
                    {
                        dt.Columns.Add("OrderDateFormatted", typeof(string));
                    }
                    foreach (DataRow r in dt.Rows)
                    {
                        var dtValue = Convert.ToDateTime(r["OrderDate"]);
                        r["OrderDateFormatted"] = dtValue.ToString("yyyy-MM-dd HH:mm");
                    }

                    // We will bind to a copy table with formatted date column to show friendly date
                    var dtDisplay = new DataTable();
                    dtDisplay.Columns.Add("OrderID", typeof(int));
                    dtDisplay.Columns.Add("OrderDate", typeof(string));
                    dtDisplay.Columns.Add("Total", typeof(decimal));
                    dtDisplay.Columns.Add("Status", typeof(string));
                    dtDisplay.Columns.Add("Items", typeof(string));

                    foreach (DataRow r in dt.Rows)
                    {
                        dtDisplay.Rows.Add(
                            r["OrderID"],
                            r["OrderDateFormatted"],
                            r["Total"],
                            r["Status"],
                            r["Items"]
                        );
                    }

                    dgvOrders.DataSource = dtDisplay;
                }
            }
        }
    }
}



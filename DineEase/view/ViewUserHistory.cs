using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DineEase
{
    public partial class ViewUserHistory : Form
    {
        private readonly string _userId;

        public ViewUserHistory(string userId)
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
            cmbFilter.Items.Add("Cancelled");
            cmbFilter.Items.Add("Recent");      // last 7 days
            cmbFilter.Items.Add("Last Month");  // last 30 days
            cmbFilter.SelectedIndex = 0;
            cmbFilter.SelectedIndexChanged += (s, e) => LoadOrders();
        }

        private void SetupDataGridViewColumns()
        {
            dgvOrders.Columns.Clear();

            // OrderID (hidden)
            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderID",
                Name = "OrderID",
                Visible = false
            };
            dgvOrders.Columns.Add(colId);

            // OrderDate
            var colDate = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderDate",
                HeaderText = "Order Date",
                Name = "OrderDate",
                ReadOnly = true
            };
            dgvOrders.Columns.Add(colDate);

            // Total
            var colTotal = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "Total (LKR)",
                Name = "Total",
                ReadOnly = true
            };
            dgvOrders.Columns.Add(colTotal);

            // Status
            var colStatus = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Status",
                Name = "Status",
                ReadOnly = true
            };
            dgvOrders.Columns.Add(colStatus);

            // Items (short)
            var colItems = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Items",
                HeaderText = "Items",
                Name = "Items",
                ReadOnly = true
            };
            dgvOrders.Columns.Add(colItems);

            // Action button (Details)
            var btnCol = new DataGridViewButtonColumn
            {
                HeaderText = "Action",
                Name = "Action",
                Text = "Details",
                UseColumnTextForButtonValue = true
            };
            dgvOrders.Columns.Add(btnCol);

            dgvOrders.CellClick += DgvOrders_CellClick;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.ReadOnly = false; // keep as-is for button column behavior
        }

        private void DgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvOrders.Columns[e.ColumnIndex].Name == "Action")
            {
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

            var db = dao.DBConnection.getInstance();
            using (SqlConnection con = db.GetConnection())
            {
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;

                    // Base query: filter by user id always
                    string sql = "SELECT OrderID, OrderDate, Price, OrderStatus, Quantity FROM dbo.Orders WHERE UserId = @UserID AND OrderStatus IN ('Confirmed', 'Cancelled')";

                    // Apply filter (use OrderStatus consistently)
                    if (selectedFilter == "Confirmed")
                    {
                        sql += " AND OrderStatus = 'Confirmed'";
                    }
                    else if (selectedFilter == "Cancelled")
                    {
                        sql += " AND OrderStatus = 'Cancelled'";
                    }
                    else if (selectedFilter == "Recent")
                    {
                        sql += " AND OrderDate >= DATEADD(day, -7, GETDATE())";
                    }
                    else if (selectedFilter == "Last Month")
                    {
                        sql += " AND OrderDate >= DATEADD(day, -30, GETDATE())";
                    }

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

                    // Display table with friendly columns
                    var dtDisplay = new DataTable();
                    dtDisplay.Columns.Add("OrderID", typeof(int));
                    dtDisplay.Columns.Add("OrderDate", typeof(string));
                    dtDisplay.Columns.Add("Total", typeof(decimal));
                    dtDisplay.Columns.Add("Status", typeof(string));
                    dtDisplay.Columns.Add("Items", typeof(string));

                    foreach (DataRow r in dt.Rows)
                    {
                        var price = r["Price"] == DBNull.Value ? 0m : Convert.ToDecimal(r["Price"]);
                        var qty = r["Quantity"] == DBNull.Value ? 0m : Convert.ToDecimal(r["Quantity"]);
                        var total = price * qty;

                        // Items: left empty until product names are fetched via a join or separate query
                        dtDisplay.Rows.Add(
                            r["OrderID"],
                            r["OrderDateFormatted"],
                            total,
                            r["OrderStatus"],
                            string.Empty
                        );
                    }

                    dgvOrders.DataSource = dtDisplay;
                }
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {

        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
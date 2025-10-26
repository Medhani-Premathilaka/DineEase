using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DineEase
{
    public partial class AdminOrderHistoryForm : Form
    {
        private FlowLayoutPanel flowOrders;
        private ComboBox cmbFilter;

        public AdminOrderHistoryForm()
        {
            InitializeComponent();
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            // --- Header Panel ---
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10)
            };

            Label lblTitle = new Label
            {
                Text = "Admin Order History",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 15)
            };
            headerPanel.Controls.Add(lblTitle);

            cmbFilter = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10),
                Location = new Point(600, 15),
                Width = 150
            };
            cmbFilter.Items.AddRange(new string[] { "All", "Done", "Rejected", "Recent", "Last Month" });
            cmbFilter.SelectedIndex = 0;
            cmbFilter.SelectedIndexChanged += (s, e) => LoadOrders();
            headerPanel.Controls.Add(cmbFilter);



            // --- Flow Layout for Cards ---
            flowOrders = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(15),
                BackColor = Color.FromArgb(245, 245, 250)
            };
            Controls.Add(flowOrders);
            Controls.Add(headerPanel);
            // --- Form Properties ---
            this.Size = new Size(900, 650);
            this.MinimumSize = new Size(800, 550);
            this.Text = "Admin Order History";
            this.Load += (s, e) => LoadOrders();
        }

        private void LoadOrders()
        {
            flowOrders.Controls.Clear();
            string filter = cmbFilter.SelectedItem?.ToString() ?? "All";

            string query = @"SELECT OrderID, UserId, CustomerName, ProductName, Quantity, Price, OrderStatus, OrderDate
                             FROM dbo.Orders
                             WHERE Finished = 1 ";

            if (filter == "Done")
                query += " AND OrderStatus = 'Done'";
            else if (filter == "Rejected")
                query += " AND OrderStatus = 'Rejected'";
            else if (filter == "Recent")
                query += " AND OrderDate >= DATEADD(DAY, -7, GETDATE())";
            else if (filter == "Last Month")
                query += " AND OrderDate >= DATEADD(DAY, -30, GETDATE())";

            query += " ORDER BY OrderDate DESC";

            var db = dao.DBConnection.getInstance();
            using (SqlConnection con = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    bool hasData = false;
                    while (reader.Read())
                    {
                        hasData = true;
                        CreateOrderCard(reader);
                    }

                    if (!hasData)
                    {
                        var lblEmpty = new Label
                        {
                            Text = "No orders found.",
                            Font = new Font("Segoe UI", 12, FontStyle.Italic),
                            ForeColor = Color.DimGray,
                            AutoSize = true,
                            Margin = new Padding(10, 30, 10, 10)
                        };
                        flowOrders.Controls.Add(lblEmpty);
                    }
                }
            }
        }

        private void CreateOrderCard(SqlDataReader reader)
        {
            int orderId = Convert.ToInt32(reader["OrderID"]);
            string userId = reader["UserId"].ToString();
            string customer = reader["CustomerName"].ToString();
            string product = reader["ProductName"].ToString();
            decimal qty = Convert.ToDecimal(reader["Quantity"]);
            decimal price = Convert.ToDecimal(reader["Price"]);
            decimal total = qty * price;
            string status = reader["OrderStatus"].ToString();
            DateTime orderDate = Convert.ToDateTime(reader["OrderDate"]);

            // --- Card Panel ---
            Panel card = new Panel
            {
                Size = new Size(700, 150),
                BackColor = Color.White,
                Margin = new Padding(5, 5, 5, 15),
                BorderStyle = BorderStyle.None
            };

            card.Paint += (s, e) =>
            {
                Rectangle rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                ControlPaint.DrawBorder(e.Graphics, rect, Color.LightGray, ButtonBorderStyle.Solid);
            };

            // --- Labels ---
            Label lblId = new Label
            {
                Text = $"Order #{orderId}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            card.Controls.Add(lblId);

            Label lblDate = new Label
            {
                Text = orderDate.ToString("f"),
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.Gray,
                Location = new Point(15, 40),
                AutoSize = true
            };
            card.Controls.Add(lblDate);

            Label lblCustomer = new Label
            {
                Text = $"Customer: {customer} ({userId})",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 70),
                AutoSize = true
            };
            card.Controls.Add(lblCustomer);

            Label lblDetails = new Label
            {
                Text = $"Product: {product} | Qty: {qty} | Total: Rs. {total:N2}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 95),
                AutoSize = true
            };
            card.Controls.Add(lblDetails);

            // --- Status Button ---
            Button btnStatus = new Button
            {
                Text = status,
                Size = new Size(100, 30),
                Location = new Point(card.Width - 120, 50),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnStatus.FlatAppearance.BorderSize = 0;
            btnStatus.BackColor = status == "Done"
                ? Color.FromArgb(75, 181, 67)
                : status == "Rejected"
                    ? Color.FromArgb(219, 82, 77)
                    : Color.Gray;
            card.Controls.Add(btnStatus);

            // --- Adjust on resize ---
            card.Resize += (s, e) => btnStatus.Left = card.Width - 120;

            flowOrders.Controls.Add(card);
        }

        private void AdminOrderHistoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}

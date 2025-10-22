using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DineEase
{
    public partial class ViewUserHistory : Form
    {
        private readonly string _userId;
        private FlowLayoutPanel flowOrders;
        private ComboBox cmbFilter;

        public ViewUserHistory(string userId)
        {
            InitializeComponent();
            _userId = userId;

            InitializeLayout();

        }

        private void InitializeLayout()
        {
            // Header panel
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10)
            };

            //Label lblTitle = new Label
            //{
            //    Text = "My Orders",
            //    Font = new Font("Segoe UI", 14, FontStyle.Bold),
            //    AutoSize = true,
            //    Location = new Point(550, 15)
            //};
            //headerPanel.Controls.Add(lblTitle);

            cmbFilter = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10),
                Location = new Point(600, 15),
                Width = 150
            };
            cmbFilter.Items.AddRange(new string[] { "All", "Confirmed", "Cancelled", "Recent", "Last Month" });
            cmbFilter.SelectedIndex = 0;
            cmbFilter.SelectedIndexChanged += (s, e) => LoadOrders();
            headerPanel.Controls.Add(cmbFilter);

            Controls.Add(headerPanel);

            // Flow layout for cards
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

            this.Load += (s, e) => LoadOrders();
        }

        private void LoadOrders()
        {
            flowOrders.Controls.Clear();

            string filter = cmbFilter.SelectedItem?.ToString() ?? "All";
            string query = @"SELECT OrderID, OrderDate, Price, Quantity, OrderStatus
                             FROM dbo.Orders WHERE UserId = @UserId";

            if (filter == "Confirmed")
                query += " AND OrderStatus = 'Confirmed'";
            else if (filter == "Cancelled")
                query += " AND OrderStatus = 'Cancelled'";
            else if (filter == "Recent")
                query += " AND OrderDate >= DATEADD(DAY, -7, GETDATE())";
            else if (filter == "Last Month")
                query += " AND OrderDate >= DATEADD(DAY, -30, GETDATE())";

            query += " ORDER BY OrderDate DESC";

            var db = dao.DBConnection.getInstance();
            using (SqlConnection con = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserId", _userId);
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
            decimal price = Convert.ToDecimal(reader["Price"]);
            decimal qty = Convert.ToDecimal(reader["Quantity"]);
            decimal total = price * qty;
            string status = reader["OrderStatus"].ToString();
            DateTime orderDate = Convert.ToDateTime(reader["OrderDate"]);

            // Create the card panel
            Panel card = new Panel
            {
                Size = new Size(560, 140), // fixed size, not tied to panel width
                BackColor = Color.White,
                Margin = new Padding(5, 5, 5, 15),
                BorderStyle = BorderStyle.None
            };

            // Draw border shadow
            card.Paint += (s, e) =>
            {
                Rectangle rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                ControlPaint.DrawBorder(e.Graphics, rect, Color.LightGray, ButtonBorderStyle.Solid);
            };

            // Order ID
            Label lblId = new Label
            {
                Text = $"Order #{orderId}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            card.Controls.Add(lblId);

            // Order Date
            Label lblDate = new Label
            {
                Text = orderDate.ToString("f"),
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.Gray,
                Location = new Point(15, 40),
                AutoSize = true
            };
            card.Controls.Add(lblDate);

            // Quantity and Total
            Label lblTotal = new Label
            {
                Text = $"Qty: {qty}   |   Total: Rs. {total:N2}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 70),
                AutoSize = true
            };
            card.Controls.Add(lblTotal);

            // Status button
            Button btnStatus = new Button
            {
                Text = status,
                Size = new Size(100, 30),
                Location = new Point(card.Width - 120, 40),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnStatus.FlatAppearance.BorderSize = 0;
            btnStatus.BackColor = status == "Confirmed"
                ? Color.FromArgb(75, 181, 67)
                : status == "Cancelled"
                    ? Color.FromArgb(219, 82, 77)
                    : Color.Gray;
            card.Controls.Add(btnStatus);

            // Adjust when resizing
            card.Resize += (s, e) => btnStatus.Left = card.Width - 120;

            flowOrders.Controls.Add(card);
        }

        private void ViewUserHistory_Load(object sender, EventArgs e)
        {

        }
    }
}

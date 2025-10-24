using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DineEase.view
{
    public partial class UserViewOrders : Form
    {
        private FlowLayoutPanel flowOrders;
        private ComboBox cmbFilter;

        public UserViewOrders()
        {
            InitializeComponent();

            // Embed-friendly
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = false;
            this.ShowInTaskbar = false;

            InitializeLayout();
        }

        private void InitializeLayout()
        {
            // Header panel
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

            // Important: add flowOrders first
            Controls.Add(flowOrders);

            // Header panel (added after to stay on top)
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10)
            };

            cmbFilter = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10),
                Location = new Point(600, 15),
                Width = 150
            };
            cmbFilter.Items.AddRange(new string[] { "All", "Done", "Rejected", "Cancelled", "Recent", "Last Month" });
            cmbFilter.SelectedIndex = 0;
            cmbFilter.SelectedIndexChanged += (s, e) => LoadOrders();
            headerPanel.Controls.Add(cmbFilter);

            // Add header after flowOrders so it stays on top
            Controls.Add(headerPanel);



            this.Load += (s, e) => LoadOrders();
        }

        private void LoadOrders()
        {
            flowOrders.Controls.Clear();

            string filter = cmbFilter.SelectedItem?.ToString() ?? "All";
            string query = @"
                SELECT OrderId, ProductName, Quantity, OrderDate, OrderStatus 
                FROM Orders
                WHERE UserId = @userId";

            if (filter == "Pending")
                query += " AND OrderStatus = 'Pending'";
            else if (filter == "Confirmed")
                query += " AND OrderStatus = 'Confirmed'";

            query += " ORDER BY OrderDate DESC";

            var db = dao.DBConnection.getInstance();
            using (SqlConnection cnn = db.GetConnection())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@userId", CurrentUser.UserId ?? string.Empty);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bool any = false;
                        while (reader.Read())
                        {
                            any = true;
                            CreateOrderCard(reader);
                        }

                        if (!any)
                        {
                            var lblEmpty = new Label
                            {
                                Text = "No active orders.",
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
        }

        private void CreateOrderCard(SqlDataReader reader)
        {
            int orderId = Convert.ToInt32(reader["OrderId"]);
            string product = reader["ProductName"].ToString();
            int qty = Convert.ToInt32(reader["Quantity"]);
            string status = reader["OrderStatus"].ToString();
            DateTime orderDate = Convert.ToDateTime(reader["OrderDate"]);

            // Create card
            Panel card = new Panel
            {
                Size = new Size(560, 140),
                BackColor = Color.White,
                Margin = new Padding(5, 5, 5, 15),
                BorderStyle = BorderStyle.None
            };

            card.Paint += (s, e) =>
            {
                Rectangle rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                ControlPaint.DrawBorder(e.Graphics, rect, Color.LightGray, ButtonBorderStyle.Solid);
            };
            Label lblId = new Label
            {
                Text = $"Order #{orderId}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            card.Controls.Add(lblId);
            // Order title
            Label lblTitle = new Label
            {
                Text = $"{product}  (x{qty})",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),

                Location = new Point(15, 40),
                AutoSize = true
            };
            card.Controls.Add(lblTitle);

            // Date
            Label lblDate = new Label
            {
                Text = orderDate.ToString("f"),
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.Gray,
                Location = new Point(15, 70),
                AutoSize = true
            };
            card.Controls.Add(lblDate);

            // Status button
            Button btnStatus = new Button
            {
                Text = status,
                Size = new Size(100, 30),
                Location = new Point(card.Width - 120, 40),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = status == "Pending" ? Color.Gold : Color.LightGreen,
                Enabled = true,

            };
            btnStatus.FlatAppearance.BorderSize = 0;
            card.Controls.Add(btnStatus);

            // Cancel button (only for Pending)
            if (status == "Pending")
            {
                Button btnCancel = new Button
                {
                    Text = "Cancel",
                    Size = new Size(100, 30),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.IndianRed
                };
                btnCancel.FlatAppearance.BorderSize = 0;

                card.Controls.Add(btnCancel);

                Action positionButtons = () =>
                {
                    btnCancel.Left = card.Width - btnCancel.Width - 15;
                    btnStatus.Left = btnCancel.Left - btnStatus.Width - 10;
                    btnCancel.Top = btnStatus.Top = 40;
                };
                card.Resize += (s, e) => positionButtons();
                positionButtons();

                btnCancel.Click += (s, e) => CancelOrder(orderId, card);
            }
            else
            {
                card.Resize += (s, e) =>
                {
                    btnStatus.Left = card.Width - btnStatus.Width - 15;
                };
            }

            flowOrders.Controls.Add(card);
        }

        private void CancelOrder(int orderId, Panel panel)
        {
            var result = MessageBox.Show("Do you really want to cancel this order?",
                "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var db = dao.DBConnection.getInstance();
                    using (SqlConnection cnn = db.GetConnection())
                    {
                        cnn.Open();
                        string query = "UPDATE Orders SET OrderStatus = 'Cancelled', Finished = 1 WHERE OrderId = @orderId";
                        using (SqlCommand cmd = new SqlCommand(query, cnn))
                        {
                            cmd.Parameters.AddWithValue("@orderId", orderId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Order cancelled successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                StartFadeOut(panel);
                            }
                            else
                            {
                                MessageBox.Show("Failed to cancel order. Please try again.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error cancelling order: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void StartFadeOut(Panel row)
        {
            row.Enabled = false;
            EnableDoubleBuffering(row);

            int steps = 20;
            int shrinkPerStep = Math.Max(1, row.Height / steps);
            var t = new Timer { Interval = 15 };

            t.Tick += (s, e) =>
            {
                if (row.Height > shrinkPerStep)
                {
                    row.Height -= shrinkPerStep;
                    row.Invalidate();
                }
                else
                {
                    t.Stop();
                    flowOrders.Controls.Remove(row);
                    row.Dispose();
                    t.Dispose();
                }
            };

            t.Start();
        }

        private void EnableDoubleBuffering(Panel panel)
        {
            var prop = typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            prop?.SetValue(panel, true, null);
        }

        private void UserViewOrders_Load(object sender, EventArgs e)
        {

        }

        private void UserViewOrders_Load_1(object sender, EventArgs e)
        {

        }
    }
}

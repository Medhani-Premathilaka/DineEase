using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DineEase.view
{
    public partial class UserViewOrders : Form
    {
        public UserViewOrders()
        {
            InitializeComponent();

            // Embed-friendly
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = false;
            this.ShowInTaskbar = false;

            // Make flow panel behave like a page
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Resize += (s, e) => FitChildPanels();

            LoadOrders();
        }

        public void LoadOrders()
        {
            flowLayoutPanel1.SuspendLayout();
            try
            {
                flowLayoutPanel1.Controls.Clear();

                var db = dao.DBConnection.getInstance();
                using (SqlConnection cnn = db.GetConnection())
                {
                    cnn.Open();
                    string query = @"
                        SELECT OrderId, ProductName, Quantity, OrderDate, OrderStatus 
                        FROM Orders
                        WHERE UserId = @userId AND OrderStatus IN ('Pending', 'Confirmed')
                        ORDER BY OrderDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@userId", CurrentUser.UserId ?? string.Empty);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            bool any = false;

                            while (reader.Read())
                            {
                                any = true;

                                Panel row = new Panel
                                {
                                    Width = 700, // Make panel stretch across
                                    Height = 90,
                                    BackColor = Color.White,
                                    BorderStyle = BorderStyle.FixedSingle,
                                    Margin = new Padding(10)
                                };



                                var lblItems = new Label
                                {
                                    Text = $"{reader["ProductName"]}: {reader["Quantity"]}",
                                    AutoSize = true,
                                    Font = new Font("Segoe UI", 10),
                                    Left = 10,
                                    Top = 10
                                };

                                var lblDate = new Label
                                {

                                    Text = Convert.ToDateTime(reader["OrderDate"]).ToString("f"),
                                    AutoSize = true,
                                    Left = 10,
                                    Top = 35,
                                    ForeColor = Color.Gray
                                };
                                var lblnewDate = new Label
                                {

                                    Text = Convert.ToDateTime(reader["OrderDate"]).AddMinutes(30).ToString("f"),
                                    AutoSize = true,
                                    Left = 10,
                                    Top = 35,
                                    ForeColor = Color.Gray
                                };
                                var btnStatus = new Button
                                {
                                    Text = reader["OrderStatus"].ToString(),
                                    BackColor = reader["OrderStatus"].ToString() == "Pending" ? Color.Gold : Color.LightGreen,
                                    ForeColor = Color.Black,
                                    Width = 90,
                                    Height = 28,
                                    Top = 26,
                                    Anchor = AnchorStyles.Top | AnchorStyles.Right
                                };

                                // Inside while (reader.Read()) just after creating btnStatus
                                if (reader["OrderStatus"].ToString() == "Pending")
                                {
                                    int orderId = Convert.ToInt32(reader["OrderId"]);
                                    Button btnCancel = new Button
                                    {
                                        Text = "Cancel",
                                        BackColor = Color.IndianRed,
                                        ForeColor = Color.White,
                                        Width = 90,
                                        Height = 28,
                                        Top = 26
                                    };

                                    // Fixed: Properly wire up the click event with orderId and panel reference
                                    btnCancel.Click += (s, e) => CancelOrder(orderId, row);

                                    // Add content first so the button isn't hidden under labels
                                    row.Controls.Add(lblItems);
                                    row.Controls.Add(lblDate);
                                    row.Controls.Add(btnStatus);
                                    row.Controls.Add(btnCancel);
                                    btnCancel.BringToFront();

                                    // Position buttons now and on resize
                                    Action position = () =>
                                    {
                                        btnCancel.Left = row.ClientSize.Width - btnCancel.Width - 10;
                                        btnStatus.Left = btnCancel.Left - btnStatus.Width - 10;
                                    };
                                    row.Resize += (s, e) => position();
                                    position();
                                }
                                else
                                {
                                    row.Controls.Add(lblItems);
                                    row.Controls.Add(lblDate);
                                    row.Controls.Add(btnStatus);
                                    row.Resize += (s, e) =>
                                    {
                                        btnStatus.Left = row.ClientSize.Width - btnStatus.Width - 10;
                                    };
                                }

                                flowLayoutPanel1.Controls.Add(row);
                                FitRowWidth(row);
                            }

                            if (!any)
                            {
                                var empty = new Label
                                {
                                    Text = "No active orders.",
                                    AutoSize = true,
                                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                                    ForeColor = Color.DimGray,
                                    Margin = new Padding(10, 20, 10, 0)
                                };
                                flowLayoutPanel1.Controls.Add(empty);
                            }
                        }
                    }
                }
            }
            finally
            {
                flowLayoutPanel1.ResumeLayout();
            }
        }

        private void FitChildPanels()
        {
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is Panel p) FitRowWidth(p);
            }
        }

        private void FitRowWidth(Panel row)
        {
            // Keep rows full-width inside the flow panel
            int scrollbar = SystemInformation.VerticalScrollBarWidth;
            int target = Math.Max(200,
                flowLayoutPanel1.ClientSize.Width - flowLayoutPanel1.Padding.Horizontal - 4);

            row.Width = target;
        }

        private void CancelOrder(int orderId, Panel panel)
        {
            var result = MessageBox.Show("Do you really want to cancel this order?",
                "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Fixed: Changed condition to check for Yes instead of No
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
            // Smooth collapse animation (works reliably in WinForms)
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
                    flowLayoutPanel1.Controls.Remove(row);
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void UserViewOrders_Load(object sender, EventArgs e) { }
    }
}
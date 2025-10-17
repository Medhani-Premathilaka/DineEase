using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DineEase
{
    public partial class AdminOrderHistoryForm : Form
    {
        private FlowLayoutPanel flowLayoutPanel1;

        public AdminOrderHistoryForm()
        {
            InitializeComponent();

            // Set form dimensions
            this.Size = new Size(800, 600);
            this.MinimumSize = new Size(750, 500);

            // Create header panel for filter controls
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10)
            };

            Label lblFilter = new Label
            {
                Text = "Filter Orders:",
                AutoSize = true,
                Location = new Point(10, 20),
                Font = new Font("Segoe UI", 10)
            };
            headerPanel.Controls.Add(lblFilter);

            ComboBox cmbFilter = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 150,
                Location = new Point(110, 18)
            };
            headerPanel.Controls.Add(cmbFilter);

            this.Controls.Add(headerPanel);

            flowLayoutPanel1 = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(15, 10, 15, 10),
                BackColor = Color.FromArgb(245, 245, 250)
            };
            this.Controls.Add(flowLayoutPanel1);

            this.ControlBox = true;
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = "Order History";
            this.Load += AdminOrderHistoryForm_Load;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
        }

        private void AdminOrderHistoryForm_Load(object sender, EventArgs e)
        {
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
            flowLayoutPanel2.Controls.Clear();
            string query = "";

            switch (filter)
            {
                case "Confirmed":
                    query = "SELECT * FROM Orders WHERE OrderStatus = 'Confirmed'";
                    break;
                case "Rejected":
                    query = "SELECT * FROM Orders WHERE OrderStatus = 'Rejected'";
                    break;
                case "Recent":
                    query = "SELECT * FROM Orders WHERE OrderDate >= DATEADD(DAY, -7, GETDATE())";
                    break;
                case "Last Month":
                    query = @"SELECT * FROM Orders 
                              WHERE MONTH(OrderDate) = MONTH(DATEADD(MONTH, -1, GETDATE()))
                              AND YEAR(OrderDate) = YEAR(DATEADD(MONTH, -1, GETDATE()))";
                    break;
                default:
                    query = "SELECT * FROM Orders";
                    break;
            }

            var db = dao.DBConnection.getInstance();
            using (SqlConnection cnn = db.GetConnection())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    bool any = false;

                    while (reader.Read())
                    {
                        any = true;
                        int isFinished = Convert.ToInt32(reader["Finished"]);
                        int orderId = Convert.ToInt32(reader["OrderID"]);

                        if (isFinished == 1)
                        {
                            // Calculate panel width based on form width
                            int panelWidth = flowLayoutPanel1.ClientSize.Width - 30; // Account for padding

                            Panel orderPanel = new Panel
                            {
                                Width = panelWidth,
                                Height = 100,
                                BackColor = Color.White,
                                BorderStyle = BorderStyle.None,
                                Margin = new Padding(0, 0, 0, 10)
                            };

                            // Add shadow effect
                            orderPanel.Paint += (s, e) =>
                            {
                                Rectangle rect = new Rectangle(0, 0, orderPanel.Width, orderPanel.Height);
                                using (Brush brush = new SolidBrush(Color.White))
                                {
                                    e.Graphics.FillRectangle(brush, rect);
                                }
                                ControlPaint.DrawBorder(e.Graphics, rect, Color.LightGray, ButtonBorderStyle.Solid);
                            };

                            Label lblNumber = new Label
                            {
                                Text = orderId.ToString() + ".",
                                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                Location = new Point(15, 15),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblNumber);

                            Label lblDetails = new Label
                            {
                                Text = reader["ProductName"] + " : " + reader["Quantity"],
                                Font = new Font("Segoe UI", 10),
                                Location = new Point(45, 15),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblDetails);

                            Label lblPrice = new Label
                            {
                                Text = "Price: Rs. " + reader["Price"],
                                Font = new Font("Segoe UI", 9),
                                Location = new Point(300, 35),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblPrice);

                            Label innerLblTime = new Label
                            {
                                Text = Convert.ToDateTime(reader["OrderDate"]).ToString("f"),
                                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                                ForeColor = Color.Gray,
                                AutoSize = true,
                                Location = new Point(45, 40)
                            };
                            orderPanel.Controls.Add(innerLblTime);

                            Label lblCustomer = new Label
                            {
                                Text = "Customer: " + reader["UserId"].ToString() + " - " + reader["CustomerName"].ToString(),
                                Font = new Font("Segoe UI", 9),
                                Location = new Point(45, 65),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblCustomer);

                            string orderStatus = Convert.ToString(reader["OrderStatus"]);
                            Button btnStatus = new Button
                            {
                                Text = orderStatus,
                                BackColor = orderStatus == "Confirmed" ? Color.FromArgb(75, 181, 67) :
                                           orderStatus == "Rejected" ? Color.FromArgb(219, 82, 77) : Color.Gray,
                                ForeColor = Color.White,
                                FlatStyle = FlatStyle.Flat,
                                Size = new Size(90, 30),
                                Location = new Point(panelWidth - 110, 35)
                            };
                            btnStatus.FlatAppearance.BorderSize = 0;
                            orderPanel.Controls.Add(btnStatus);

                            flowLayoutPanel2.Controls.Add(orderPanel);
                        }
                    }

                    if (!any)
                    {
                        var empty = new Label
                        {
                            Text = "No active orders.",
                            AutoSize = true,
                            Font = new Font("Segoe UI", 12, FontStyle.Italic),
                            ForeColor = Color.DimGray,
                            Margin = new Padding(0, 50, 0, 0)
                        };
                        // Center the label
                        empty.Left = (flowLayoutPanel1.Width - empty.Width) / 2;
                        flowLayoutPanel2.Controls.Add(empty);
                    }
                }
            }
        }

        private void ShowInFlow(Form child)
        {
            flowLayoutPanel1.Controls.Clear();
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Visible = true;
            child.Size = flowLayoutPanel1.ClientSize;
            flowLayoutPanel1.Controls.Add(child);
            child.Show();
        }

        private void UpdateOrderStatus(int orderId, string newStatus)
        {
            string query = "UPDATE Orders SET OrderStatus = @status WHERE OrderID = @id";

            var db = dao.DBConnection.getInstance();
            using (SqlConnection cnn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", orderId);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
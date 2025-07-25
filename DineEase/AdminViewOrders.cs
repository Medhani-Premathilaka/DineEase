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
using Guna.UI2.WinForms;


namespace DineEase
{
    public partial class AdminViewOrders : Form
    {

        string connectionString = @"Data Source=DESKTOP-TAR59NP\SQLEXPRESS;Initial Catalog=dineEase;Integrated Security=True";
        public AdminViewOrders()
        {
            InitializeComponent();
            this.Load += AdminViewOrder_Load; // Attach event handler

            timer1.Tick += timer_Tick_1;
            timer1.Interval = 10;

            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
        }

        private void AdminViewOrder_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            flowLayoutPanel1.Controls.Clear(); // Clear existing cards

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Orders ORDER BY OrderDate DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int orderNumber = 1;

                while (reader.Read())
                {
                    string orderStatus = reader["OrderStatus"].ToString();
                    int orderId = Convert.ToInt32(reader["OrderID"]);

                    Guna.UI2.WinForms.Guna2Panel orderPanel = new Guna.UI2.WinForms.Guna2Panel
                    {
                        Width = 1200,
                        Height = 110,
                        BorderRadius = 15,
                        FillColor = Color.FromArgb(231, 222, 240),
                        ShadowDecoration = { Enabled = true, BorderRadius = 15, Color = Color.LightGray },
                        Padding = new Padding(10),
                        Margin = new Padding(10)
                    };



                    // Prepare formatted date safely
                    string formattedDate = "";
                    if (!(reader["OrderDate"] is DBNull))
                    {
                        DateTime orderDateTime = Convert.ToDateTime(reader["OrderDate"]);
                        formattedDate = (orderDateTime.Date == DateTime.Today)
                            ? "Today " + orderDateTime.ToString("h.mm tt").ToLower()
                            : orderDateTime.ToString("dd MMM yyyy h.mm tt").ToLower();
                    }


                    if (orderStatus.ToLower() == "done")
                    {
                        {
                            Label lblNumber = new Label
                            {
                                Text = orderNumber.ToString() + ".",
                                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                Location = new Point(10, 10),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblNumber);

                            Label lblProduct = new Label
                            {
                                Text = $"{reader["ProductName"]}  ×  {reader["Qauntity"]}",
                                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                                ForeColor = Color.FromArgb(40, 40, 40),
                                Location = new Point(40, 10),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblProduct);

                            Label lblCustomer = new Label
                            {
                                Text = $"👤 Customer: {reader["CustomerID"]} - {reader["CustomerName"]}",
                                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                                ForeColor = Color.FromArgb(70, 70, 70),
                                Location = new Point(40, 30),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblCustomer);


                            DateTime orderDateTime = Convert.ToDateTime(reader["OrderDate"]);
                            formattedDate = (orderDateTime.Date == DateTime.Today)
                            ? "Today " + orderDateTime.ToString("h:mm tt").ToLower()
                            : orderDateTime.ToString("dd MMM yyyy h:mm tt").ToLower();


                            Label lblTime = new Label
                            {
                                Text = formattedDate,
                                Font = new Font("Segoe UI", 9.5f, FontStyle.Italic),
                                ForeColor = Color.FromArgb(120, 120, 120), // Softer gray
                                AutoSize = true,
                                Location = new Point(40, 50),
                                Margin = new Padding(0, 5, 0, 0)
                            };
                            orderPanel.Controls.Add(lblTime);

                            Label lblPrice = new Label
                            {
                                Text = "Price: Rs. " + reader["Price"],
                                Font = new Font("Segoe UI", 9),
                                Location = new Point(200, 30),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblPrice);

                            Guna2Button btnDone = new Guna2Button
                            {
                                Text = "Done",
                                Size = new Size(80, 35),
                                Location = new Point(orderPanel.Width - 90, 30),
                                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                                FillColor = Color.FromArgb(96, 125, 139),
                                ForeColor = Color.White,
                                BorderRadius = 10,
                                Cursor = Cursors.Hand
                            };

                            btnDone.Click += (s, e) =>
                            {
                                using (SqlConnection deleteConn = new SqlConnection(connectionString))
                                {
                                    string deleteQuery = "DELETE FROM Orders WHERE OrderID = @OrderID";
                                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, deleteConn);
                                    deleteCmd.Parameters.AddWithValue("@OrderID", orderId);

                                    deleteConn.Open();
                                    int rowsAffected = deleteCmd.ExecuteNonQuery();
                                    deleteConn.Close();

                                    if (rowsAffected > 0)
                                    {
                                        flowLayoutPanel1.Controls.Remove(orderPanel);
                                        MessageBox.Show("Order removed.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to remove order.");
                                    }
                                }
                            };

                            orderPanel.Controls.Add(btnDone);

                            // Adjust position on resize
                            orderPanel.Resize += (s, e) =>
                            {
                                btnDone.Location = new Point(orderPanel.Width - 90, 30);
                            };

                            flowLayoutPanel1.Controls.Add(orderPanel);
                            orderNumber++;
                        }
                    }

                    else
                    {
                        Label lblNumber = new Label
                        {
                            Text = orderNumber.ToString() + ".",
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                            Location = new Point(10, 10),
                            AutoSize = true
                        };
                        orderPanel.Controls.Add(lblNumber);

                        Label lblDetails = new Label
                        {

                            Text = $"{reader["ProductName"]}  ×  {reader["Qauntity"]}",
                            Font = new Font("Segoe UI", 11, FontStyle.Bold),
                            ForeColor = Color.FromArgb(40, 40, 40),
                            Location = new Point(40, 10),
                            AutoSize = true
                        };
                        orderPanel.Controls.Add(lblDetails);

                        Label lblCustomer = new Label
                        {
                            Text = $"👤 Customer: {reader["CustomerID"]} - {reader["CustomerName"]}",
                            Font = new Font("Segoe UI", 9, FontStyle.Regular),
                            ForeColor = Color.FromArgb(70, 70, 70),
                            Location = new Point(40, 30), // Below the date
                            AutoSize = true
                        };
                        orderPanel.Controls.Add(lblCustomer);


                        // Date formatting logic
                        DateTime innerOrderDateTime = Convert.ToDateTime(reader["OrderDate"]);
                        string innerFormattedDate = (innerOrderDateTime.Date == DateTime.Today)
                            ? "Today " + innerOrderDateTime.ToString("h:mm tt")
                            : innerOrderDateTime.ToString("dd MMM yyyy h:mm tt");

                        // Date label
                        Label innerLblTime = new Label
                        {
                            Text = formattedDate,
                            Font = new Font("Segoe UI", 9.5f, FontStyle.Italic),
                            ForeColor = Color.FromArgb(120, 120, 120), // Softer gray
                            AutoSize = true,
                            Location = new Point(40, 50),
                            Margin = new Padding(0, 5, 0, 0)
                        };
                        orderPanel.Controls.Add(innerLblTime);

                        Guna2Button btnAccept = new Guna2Button
                        {
                            Text = "Accept",
                            Size = new Size(90, 36),
                            Location = new Point(orderPanel.Width - 200, 30),
                            BorderRadius = 10,
                            FillColor = Color.FromArgb(76, 175, 80), // Light green
                            ForeColor = Color.White,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold),
                            HoverState = { FillColor = Color.FromArgb(56, 142, 60) },
                            Cursor = Cursors.Hand
                        };

                        btnAccept.Click += (s, e) =>
                        {
                            using (SqlConnection updateConn = new SqlConnection(connectionString))
                            {
                                string updateQuery = "UPDATE Orders SET OrderStatus = 'confirm' WHERE OrderID = @OrderID";
                                SqlCommand updateCmd = new SqlCommand(updateQuery, updateConn);
                                updateCmd.Parameters.AddWithValue("@OrderID", orderId);

                                updateConn.Open();
                                updateCmd.ExecuteNonQuery();
                                updateConn.Close();

                                MessageBox.Show("Order accepted!");
                                LoadOrders();
                            }
                        };
                        orderPanel.Controls.Add(btnAccept);

                        Guna2Button btnReject = new Guna2Button
                        {
                            Text = "Reject",
                            Size = new Size(90, 36),
                            Location = new Point(orderPanel.Width - 100, 30),
                            BorderRadius = 10,
                            FillColor = Color.FromArgb(244, 67, 54), // Light red
                            ForeColor = Color.White,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold),
                            HoverState = { FillColor = Color.FromArgb(211, 47, 47) },
                            Cursor = Cursors.Hand
                        };


                        btnReject.Click += (s, e) =>
                        {
                            using (SqlConnection updateConn = new SqlConnection(connectionString))
                            {
                                string updateQuery = "UPDATE Orders SET OrderStatus = 'Rejected' WHERE OrderID = @OrderID";
                                SqlCommand updateCmd = new SqlCommand(updateQuery, updateConn);
                                updateCmd.Parameters.AddWithValue("@OrderID", orderId);

                                updateConn.Open();
                                updateCmd.ExecuteNonQuery();
                                updateConn.Close();

                                MessageBox.Show("Order rejected.");
                                LoadOrders();
                            }
                        };
                        orderPanel.Controls.Add(btnReject);

                        orderPanel.Resize += (s, e) =>
                        {
                            btnAccept.Location = new Point(orderPanel.Width - 200, 30);
                            btnReject.Location = new Point(orderPanel.Width - 100, 30);
                        };

                        orderNumber++;
                    }

                    flowLayoutPanel1.Controls.Add(orderPanel);
                }

                conn.Close();
            }
        }




        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelOverlay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {

        }

        private void profileButton_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private int panelExpandedWidth = 200;  // Width when expanded
        private int panelCollapsedWidth = 120;  // Width when collapsed
        private bool isCollapsed = true;


        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer_Tick_1(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                guna2Panel1.Width += 60;  // Increase width step-by-step
                if (guna2Panel1.Width >= panelExpandedWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;

                    // Show labels after fully expanded
                    addButton.Visible = true;
                    viewOrderButton.Visible = true;
                    historyButton.Visible = true;
                    settingButton.Visible = true;
                    profileButton.Visible = true;
                    //DineEaseLabel.Visible = true;

                    guna2ImageButton1.Image = Image.FromFile(@"C:\Users\IMASHA THARUSHI\Desktop\rad3\DineEase\DineEase\Resources\iconoir_sidebar-collapse.png");

                    AdjustControlPositions();
                }
            }
            else
            {
                // Hide labels first to avoid visual glitches
                addButton.Visible = false;
                viewOrderButton.Visible = false;
                historyButton.Visible = false;
                settingButton.Visible = false;
                profileButton.Visible = false;
                //DineEaseLabel.Visible = false;

                guna2ImageButton1.Image = Image.FromFile(@"C:\Users\IMASHA THARUSHI\Desktop\rad3\DineEase\DineEase\Resources\icon-park-outline_expand-left.png");

                guna2Panel1.Width -= 60; // Decrease width step-by-step
                if (guna2Panel1.Width <= panelCollapsedWidth)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    AdjustControlPositions();
                }
            }
        }

        private void AdjustControlPositions()
        {
            foreach (Control ctrl in guna2Panel1.Controls)
            {
                if (ctrl is Guna2ImageButton)
                {
                    if (isCollapsed)
                        ctrl.Location = new Point(10, ctrl.Location.Y);
                    else
                        ctrl.Location = new Point(guna2Panel1.Width - ctrl.Width - 10, ctrl.Location.Y);
                }
                else if (!isCollapsed)
                {
                    ctrl.Location = new Point(10, ctrl.Location.Y);
                }
            }
        }

        private void historyButton_Click(object sender, EventArgs e)
        {

        }

        private void settingButton_Click(object sender, EventArgs e)
        {

        }

        private void viewOrderButton_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}

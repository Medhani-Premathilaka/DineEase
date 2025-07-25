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
    public partial class AdminViewOrders : Form
    {

        string connectionString = @"Data Source=DESKTOP-TAR59NP\SQLEXPRESS;Initial Catalog=dineEase;Integrated Security=True";
        public AdminViewOrders()
        {
            InitializeComponent();
            this.Load += AdminViewOrder_Load; // Attach event handler

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
                        Width = 1300,
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
                                Text = reader["ProductName"] + " : " + reader["Qauntity"],
                                Font = new Font("Segoe UI", 10),
                                Location = new Point(40, 10),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblProduct);

                            Label lblCustomer = new Label
                            {
                                Text = "Customer: " + reader["CustomerID"] + " - " + reader["CustomerName"],
                                Font = new Font("Segoe UI", 9),
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
                                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                                ForeColor = Color.Gray,
                                AutoSize = true,
                                Location = new Point(40, 50)
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

                            Button btnDone = new Button
                            {
                                Text = "Done",
                                BackColor = Color.Gray,
                                ForeColor = Color.White,
                                FlatStyle = FlatStyle.Flat,
                                Size = new Size(70, 30),
                                Location = new Point(orderPanel.Width - 90, 30)
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
                            Text = reader["ProductName"] + " : " + reader["Qauntity"],
                            Font = new Font("Segoe UI", 10),
                            Location = new Point(40, 10),
                            AutoSize = true
                        };
                        orderPanel.Controls.Add(lblDetails);

                        Label lblCustomer = new Label
                        {
                            Text = "Customer: " + reader["CustomerID"].ToString() + " - " + reader["CustomerName"].ToString(),
                            Font = new Font("Segoe UI", 9),
                            Location = new Point(40, 55), // Below the date
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
                            Text = innerFormattedDate,
                            Font = new Font("Segoe UI", 9, FontStyle.Italic),
                            ForeColor = Color.Gray,
                            AutoSize = true,
                            Location = new Point(40, 35) // adjust Y if needed
                        };
                        orderPanel.Controls.Add(innerLblTime);

                        Button btnAccept = new Button
                        {
                            Text = "Accept",
                            BackColor = Color.Green,
                            ForeColor = Color.White,
                            FlatStyle = FlatStyle.Flat,
                            Size = new Size(70, 30),
                            Location = new Point(orderPanel.Width - 160, 30)
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

                        Button btnReject = new Button
                        {
                            Text = "Reject",
                            BackColor = Color.Red,
                            ForeColor = Color.White,
                            FlatStyle = FlatStyle.Flat,
                            Size = new Size(70, 30),
                            Location = new Point(orderPanel.Width - 80, 30)
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
                            btnAccept.Location = new Point(orderPanel.Width - 160, 30);
                            btnReject.Location = new Point(orderPanel.Width - 80, 30);
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

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

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

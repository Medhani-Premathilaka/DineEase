using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DineEase.view
{
    public partial class AdminViewOrdersnew : Form
    {
        public AdminViewOrdersnew()
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
        private void PositionTxtNone()
        {
            int left = Math.Max(0, (flowLayoutPanel1.ClientSize.Width - txtnone.Width) / 2);
            txtnone.Margin = new Padding(left, 20, 0, 0); // adjust top as needed
        }
        private void FlowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            if (txtnone.Visible && flowLayoutPanel1.Controls.Contains(txtnone))
                PositionTxtNone();
        }
        private void LoadOrders()
        {
            flowLayoutPanel1.Controls.Clear(); // Clear existing cards
            txtnone.Visible = false; // hide by default
            string query = "SELECT * FROM Orders WHERE Finished = 0 ORDER BY OrderDate DESC";



            var db = dao.DBConnection.getInstance();
            using (SqlConnection cnn = db.GetConnection())
            {

                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        if (!flowLayoutPanel1.Controls.Contains(txtnone))
                            flowLayoutPanel1.Controls.Add(txtnone);

                        txtnone.AutoSize = true; // let FlowLayoutPanel size around it
                        PositionTxtNone();       // set margin for placement
                        txtnone.Visible = true;
                        return;
                    }

                    int orderNumber = 1;



                    while (reader.Read())
                    {
                        string orderStatus = reader["OrderStatus"].ToString();
                        int orderId = Convert.ToInt32(reader["OrderID"]);

                        Panel orderPanel = new Panel
                        {
                            Width = 700, // Make panel stretch across
                            Height = 90,
                            BackColor = Color.White,
                            BorderStyle = BorderStyle.FixedSingle,
                            Margin = new Padding(5)
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
                                    using (SqlConnection deleteConn = db.GetConnection())
                                    {
                                        string deleteQuery = "UPDATE Orders SET Finished = 1 WHERE OrderID = @OrderID";
                                        SqlCommand deleteCmd = new SqlCommand(deleteQuery, deleteConn);
                                        deleteCmd.Parameters.AddWithValue("@OrderID", orderId);

                                        deleteConn.Open();
                                        int rowsAffected = deleteCmd.ExecuteNonQuery();
                                        deleteConn.Close();

                                        //if (rowsAffected > 0)
                                        //{
                                        //    flowLayoutPanel1.Controls.Remove(orderPanel);
                                        //    MessageBox.Show("Order removed.");
                                        //}
                                        //else
                                        //{
                                        //    MessageBox.Show("Failed to remove order.");
                                        //}
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
                        else if (orderStatus.ToLower() == "ongoing" || orderStatus.ToLower() == "confirmed")

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
                                Text = reader["ProductName"] + " : " + reader["Quantity"],

                                Font = new Font("Segoe UI", 10),
                                Location = new Point(40, 10),
                                AutoSize = true
                            };

                            orderPanel.Controls.Add(lblDetails);

                            Label lblCustomer = new Label
                            {
                                Text = "Customer: " + reader["UserId"].ToString() + " - " + reader["CustomerName"].ToString(),
                                Font = new Font("Segoe UI", 9),
                                Location = new Point(40, 55), // Below the date

                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblCustomer);


                            Label lblPrice = new Label
                            {
                                Text = "Price: Rs. " + reader["Price"],
                                Font = new Font("Segoe UI", 9),
                                Location = new Point(200, 30),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblPrice);

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

                            Button btnOngoing = new Button
                            {
                                Text = "Ongoing",
                                BackColor = Color.Orange,
                                ForeColor = Color.White,
                                FlatStyle = FlatStyle.Flat,
                                Size = new Size(70, 30),
                                Location = new Point(orderPanel.Width - 80, 30),
                                Enabled = true // Not clickable
                            };
                            orderPanel.Controls.Add(btnOngoing);
                            orderPanel.Resize += (sender2, e2) =>
                            {
                                btnOngoing.Location = new Point(orderPanel.Width - 80, 30);
                            };
                            btnOngoing.Click += (os, oe) =>
                            {
                                using (SqlConnection doneConn = db.GetConnection())
                                {
                                    string doneQuery = "UPDATE Orders SET OrderStatus = 'Done' , Finished = 1 WHERE OrderID = @OrderID";
                                    SqlCommand doneCmd = new SqlCommand(doneQuery, doneConn);
                                    doneCmd.Parameters.AddWithValue("@OrderID", orderId);

                                    doneConn.Open();
                                    doneCmd.ExecuteNonQuery();
                                    doneConn.Close();
                                }

                                btnOngoing.Text = "Done";
                                btnOngoing.BackColor = Color.Gray;
                                btnOngoing.Enabled = false;

                                // Fade out (remove) the card after 5 seconds
                                Timer fadeTimer = new Timer();
                                fadeTimer.Interval = 5000; // 5 seconds
                                fadeTimer.Tick += (sender2, e2) =>
                                {
                                    fadeTimer.Stop();
                                    flowLayoutPanel1.Controls.Remove(orderPanel);
                                    fadeTimer.Dispose();
                                };
                                fadeTimer.Start();
                            };

                            //orderPanel.Resize += (s, e) =>
                            //{
                            //    btnOngoing.Location = new Point(orderPanel.Width - 80, 30);
                            //};
                        }
                        // Inside the else block of while (reader.Read())


                        else
                        {
                            // Existing Accept/Reject logic
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
                                Text = reader["ProductName"] + " : " + reader["Quantity"],
                                Font = new Font("Segoe UI", 10),
                                Location = new Point(40, 10),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblDetails);

                            Label lblCustomer = new Label
                            {
                                Text = "Customer: " + reader["UserId"].ToString() + " - " + reader["CustomerName"].ToString(),
                                Font = new Font("Segoe UI", 9),
                                Location = new Point(40, 55), // Below the date
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblCustomer);

                            Label lblPrice = new Label
                            {
                                Text = "Price: Rs. " + reader["Price"],
                                Font = new Font("Segoe UI", 9),
                                Location = new Point(200, 30),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblPrice);

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
                            Button btnReject = new Button
                            {
                                Text = "Reject",
                                BackColor = Color.Red,
                                ForeColor = Color.White,
                                FlatStyle = FlatStyle.Flat,
                                Size = new Size(70, 30),
                                Location = new Point(orderPanel.Width - 80, 30)
                            };
                            btnAccept.Click += (s, e) =>
                            {
                                using (SqlConnection updateConn = db.GetConnection())
                                {
                                    // Set status to 'Ongoing'
                                    string updateQuery = "UPDATE Orders SET OrderStatus = 'Confirmed' WHERE OrderID = @OrderID";
                                    SqlCommand updateCmd = new SqlCommand(updateQuery, updateConn);
                                    updateCmd.Parameters.AddWithValue("@OrderID", orderId);

                                    updateConn.Open();
                                    updateCmd.ExecuteNonQuery();
                                    updateConn.Close();

                                    // Hide Accept and Reject buttons
                                    btnAccept.Visible = false;
                                    btnReject.Visible = false;

                                    // Create Ongoing button
                                    Button btnOngoing = new Button
                                    {
                                        Text = "Ongoing",
                                        BackColor = Color.Orange,
                                        ForeColor = Color.White,
                                        FlatStyle = FlatStyle.Flat,
                                        Size = new Size(70, 30),
                                        Location = new Point(orderPanel.Width - 80, 30),
                                        Enabled = true // Not clickable
                                    };
                                    orderPanel.Controls.Add(btnOngoing);
                                    orderPanel.Resize += (sender2, e2) =>
                                    {
                                        btnOngoing.Location = new Point(orderPanel.Width - 80, 30);
                                    };
                                    btnOngoing.Click += (os, oe) =>
                                    {
                                        using (SqlConnection doneConn = db.GetConnection())
                                        {
                                            string doneQuery = "UPDATE Orders SET OrderStatus = 'Done' , Finished = 1 WHERE OrderID = @OrderID";
                                            SqlCommand doneCmd = new SqlCommand(doneQuery, doneConn);
                                            doneCmd.Parameters.AddWithValue("@OrderID", orderId);

                                            doneConn.Open();
                                            doneCmd.ExecuteNonQuery();
                                            doneConn.Close();
                                        }

                                        btnOngoing.Text = "Done";
                                        btnOngoing.BackColor = Color.Gray;
                                        btnOngoing.Enabled = false;

                                        // Fade out (remove) the card after 5 seconds
                                        Timer fadeTimer = new Timer();
                                        fadeTimer.Interval = 5000; // 5 seconds
                                        fadeTimer.Tick += (sender2, e2) =>
                                        {
                                            fadeTimer.Stop();
                                            flowLayoutPanel1.Controls.Remove(orderPanel);
                                            fadeTimer.Dispose();
                                        };
                                        fadeTimer.Start();
                                    };
                                }

                                MessageBox.Show("Order accepted!");
                                // Optionally: LoadOrders();
                            };


                            orderPanel.Controls.Add(btnAccept);

                            btnReject.Click += (s, e) =>
                            {
                                using (SqlConnection updateCon = db.GetConnection())
                                {
                                    updateCon.Open();
                                    string updateQuery = "UPDATE Orders SET OrderStatus = 'Rejected' , Finished = 1 WHERE OrderID = @OrderID";
                                    SqlCommand updateCmd = new SqlCommand(updateQuery, updateCon);
                                    updateCmd.Parameters.AddWithValue("@OrderID", orderId);

                                    updateCmd.ExecuteNonQuery();
                                    updateCon.Close();

                                    MessageBox.Show("Order rejected.");
                                    Timer fadeTimer = new Timer();
                                    fadeTimer.Interval = 300; // milliseconds
                                    fadeTimer.Tick += (sender2, e2) =>
                                    {
                                        fadeTimer.Stop();
                                        flowLayoutPanel1.Controls.Remove(orderPanel);
                                        fadeTimer.Dispose();
                                    };
                                    fadeTimer.Start();
                                }
                            };
                            orderPanel.Controls.Add(btnReject);

                            orderPanel.Resize += (s, e) =>
                            {
                                btnAccept.Location = new Point(orderPanel.Width - 160, 30);
                                btnReject.Location = new Point(orderPanel.Width - 80, 30);
                            };


                        }
                        orderNumber++;
                        flowLayoutPanel1.Controls.Add(orderPanel);

                        //flowLayoutPanel1.Controls.Add(orderPanel);
                    }

                    cnn.Close();
                }


            }

        }
    }
}

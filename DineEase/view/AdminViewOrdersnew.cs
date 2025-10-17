using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DineEase.view
{
    public partial class AdminViewOrdersnew : Form, ShowPage
    {
        private int panelExpandedWidth = 180;  // Width when expanded
        private int panelCollapsedWidth = 70;  // Width when collapsed
        private bool isCollapsed = true;
        private string studentId;

        public AdminViewOrdersnew()
        {
            InitializeComponent();
            this.Load += AdminViewOrder_Load; // Attach event handler
            this.Resize += AdminViewOrdersnew_Resize;
            //flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            //flowLayoutPanel1.WrapContents = false;
            //flowLayoutPanel1.AutoScroll = true;
            //InitializeComponent();
            this.ControlBox = true;
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Configure flow panel
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.BackColor = Color.FromArgb(240, 240, 240); // Light gray background

            LoadOrders();
        }

        private void AdminViewOrder_Load(object sender, EventArgs e)
        {
            guna2Panel1.Width = panelCollapsedWidth; // ensure collapsed at start
            LoadOrders();
        }
        //private void PositionTxtNone()
        //{
        //    int left = Math.Max(0, (flowLayoutPanel1.ClientSize.Width - txtnone.Width) / 2);
        //    txtnone.Margin = new Padding(left, 20, 0, 0); // adjust top as needed
        //}
        //private void FlowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        //{
        //    if (txtnone.Visible && flowLayoutPanel1.Controls.Contains(txtnone))
        //        PositionTxtNone();
        //}
        private void LoadOrders()
        {
            flowLayoutPanel1.Controls.Clear(); // Clear existing cards
            //txtnone.Visible = false; // hide by default
            string query = "SELECT * FROM Orders WHERE Finished = 0 ORDER BY OrderDate DESC";



            var db = dao.DBConnection.getInstance();
            using (SqlConnection cnn = db.GetConnection())
            {

                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //if (!reader.HasRows)
                    //{
                    //    if (!flowLayoutPanel1.Controls.Contains(txtnone))
                    //        flowLayoutPanel1.Controls.Add(txtnone);

                    //    txtnone.AutoSize = true; // let FlowLayoutPanel size around it
                    //    PositionTxtNone();       // set margin for placement
                    //    txtnone.Visible = true;
                    //    return;
                    //}

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
                            Margin = new Padding(10)
                        };



                        // Prepare formatted date safely
                        //string formattedDate = "";
                        //if (!(reader["OrderDate"] is DBNull))
                        //{
                        //    DateTime orderDateTime = Convert.ToDateTime(reader["OrderDate"]);
                        //    formattedDate = (orderDateTime.Date == DateTime.Today)
                        //        ? "Today " + orderDateTime.ToString("h.mm tt").ToLower()
                        //        : orderDateTime.ToString("dd MMM yyyy h.mm tt").ToLower();
                        //}
                        //var lblDate = new Label
                        //{

                        //    Text = Convert.ToDateTime(reader["OrderDate"]).ToString("f"),
                        //    AutoSize = true,
                        //    Left = 10,
                        //    Top = 35,
                        //    ForeColor = Color.Gray
                        //};


                        if (orderStatus.ToLower() == "done")
                        {
                            {


                                Label lblPrice = new Label
                                {
                                    Text = "Price: Rs. " + reader["Price"],
                                    Font = new Font("Segoe UI", 9),
                                    Location = new Point(300, 30),
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
                                Location = new Point(300, 30),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblPrice);

                            // Date formatting logic
                            //DateTime innerOrderDateTime = Convert.ToDateTime(reader["OrderDate"]);
                            //string innerFormattedDate = (innerOrderDateTime.Date == DateTime.Today)
                            //    ? "Today " + innerOrderDateTime.ToString("h:mm tt")
                            //    : innerOrderDateTime.ToString("dd MMM yyyy h:mm tt");

                            // Date label
                            Label innerLblTime = new Label
                            {
                                Text = Convert.ToDateTime(reader["OrderDate"]).ToString("f"),
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
                                Location = new Point(300, 30),
                                AutoSize = true
                            };
                            orderPanel.Controls.Add(lblPrice);

                            // Date formatting logic

                            // Date label
                            Label innerLblTime = new Label
                            {
                                Text = Convert.ToDateTime(reader["OrderDate"]).ToString("f"),
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
        private void AdminViewOrdersnew_Resize(object sender, EventArgs e)
        {
            // Resize the flowLayoutPanel to fill the form's client area
            // You may need to adjust margins/paddings as needed
            flowLayoutPanel1.Width = this.ClientSize.Width - flowLayoutPanel1.Left - 20;
            flowLayoutPanel1.Height = this.ClientSize.Height - flowLayoutPanel1.Top - 20;

            // Resize any child form that's in the flowLayoutPanel
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Form)
                {
                    control.Size = flowLayoutPanel1.ClientSize;
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
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void showPage()
        {
            this.Show();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ordersBtn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Orders button clicked!");
            var adminHomePagenew = new AdminHomePagenew();
            ShowInFlow(adminHomePagenew);

        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            navTimer.Start();
        }
        private void navTimer_Tick_1(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                guna2Panel1.Width += 10;  // Increase width step-by-step
                if (guna2Panel1.Width >= panelExpandedWidth)
                {
                    navTimer.Stop();
                    isCollapsed = false;

                    // Show labels after fully expanded
                    homeBtn.Visible = true;
                    ordersBtn.Visible = true;
                    historyBtn.Visible = true;
                    settingBtn.Visible = true;
                    profileBtn.Visible = true;
                    logo.Visible = true;
                    guna2ImageButton1.Image = Image.FromFile("Resources\\collaps.png");

                    AdjustControlPositions();
                }
            }
            else
            {
                // Hide labels first to avoid visual glitches
                logo.Visible = false;
                homeBtn.Visible = false;
                ordersBtn.Visible = false;
                historyBtn.Visible = false;
                settingBtn.Visible = false;
                profileBtn.Visible = false;
                guna2ImageButton1.Image = Image.FromFile("Resources\\expand.png");

                guna2Panel1.Width -= 10; // Decrease width step-by-step
                if (guna2Panel1.Width <= panelCollapsedWidth)
                {
                    navTimer.Stop();
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

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            string adminId = CurrentUser.UserId;

            try
            {
                AdminProfile prf = new AdminProfile(adminId);
                //prf.TopLevel = false;
                //prf.FormBorderStyle = FormBorderStyle.None;
                //prf.Dock = DockStyle.Fill;

                //flowLayoutPanel1.Controls.Add(prf);
                prf.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying profile: " + ex.Message);
            }
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void historyBtn_Click(object sender, EventArgs e)
        {
            var adminOrderHistoryForm = new AdminOrderHistoryForm();
            //adminOrderHistoryForm.Show();
            ShowInFlow(adminOrderHistoryForm);
        }
    }
}

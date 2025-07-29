using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DineEase.view
{
    public partial class UserViewOrders : Form
    {
        public UserViewOrders()
        {
            InitializeComponent();
            LoadOrders();
        }
        private void LoadOrders()
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
                    cmd.Parameters.AddWithValue("@userId", CurrentUser.UserId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guna2ShadowPanel p = new Guna2ShadowPanel
                            {
                                Width = flowLayoutPanel1.ClientSize.Width - 25, // Fill available width
                                Height = 100,
                                FillColor = Color.FromArgb(228, 244, 252),
                                Margin = new Padding(10, 5, 10, 5),
                                BorderStyle = BorderStyle.None,
                                ShadowColor = Color.FromArgb(0, 0, 0, 0),
                                ShadowDepth = 10,
                                ShadowShift = 5
                            };
                            /*
                            var panel = new Panel {
                                //Width = 500, Height = 80, Margin = new Padding(10), BackColor = Color.Yellow 
                                Height = 100,
                                Width = flowLayoutPanel1.ClientSize.Width - 25, // Fill available width
                                BackColor = Color.FromArgb(228, 244, 252),
                                Margin = new Padding(10, 5, 10, 5),
                                BorderStyle = BorderStyle.FixedSingle

                            };
                            */
                            flowLayoutPanel1.Resize += (s, e) =>
                            {
                                p.Width = flowLayoutPanel1.ClientSize.Width - 25;
                            };



                            var lblItems = new System.Windows.Forms.Label // Specify the full namespace
                            {
                                Text = $"{reader["ProductName"]}: {reader["Quantity"]}",
                                AutoSize = true,
                                //Font = new Font("verdana", 20)

                               
                                Font = new Font("Verdana", 12, FontStyle.Bold),
                                Location = new Point(10, 10),
                            
                            };
                            var lblDate = new System.Windows.Forms.Label // Specify the full namespace
                            {
                                Text = Convert.ToDateTime(reader["OrderDate"]).ToString("f"),
                                AutoSize = true,
                                //Top = 30

                                
                                Font = new Font("Verdana", 10),
                                Location = new Point(10, 40),
                                

                            };
                            var btnStatus = new System.Windows.Forms.Button
                            {
                                Text = reader["OrderStatus"].ToString(),
                                //BackColor = reader["OrderStatus"].ToString() == "Pending" ? Color.Gold : Color.LightGreen,
                                //Left = 300

                               
                                BackColor = reader["OrderStatus"].ToString() == "Pending" ? Color.Goldenrod : Color.LightGreen,
                                ForeColor = Color.Black,
                                Font = new Font("Verdana", 10, FontStyle.Bold),
                                Size = new Size(80, 30),
                                Location = new Point(p.Width - 180, 30),
                                Anchor = AnchorStyles.Top | AnchorStyles.Right


                            };


                            




                            if (reader["OrderStatus"].ToString() == "Pending")
                            {
                                //var btnCancel = new System.Windows.Forms.Button
                                //{
                                //    Text = "Cancel",
                                //    BackColor = Color.Red,
                                //    Left = 380
                                //};
                                //int orderId = Convert.ToInt32(reader["OrderId"]);
                                //btnCancel.Click += (s, e) => CancelOrder(orderId, panel);
                                //panel.Controls.Add(btnCancel);

                                var btnCancel = new Button
                                {
                                    Text = "Cancel",
                                    BackColor = Color.IndianRed,
                                    ForeColor = Color.White,
                                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                    Size = new Size(80, 30),
                                    Location = new Point(p.Width - 90, 30),
                                    Anchor = AnchorStyles.Top | AnchorStyles.Right
                                };

                                int orderId = Convert.ToInt32(reader["OrderId"]);
                                btnCancel.Click += (s, e) => CancelOrder(orderId, p);

                                p.Controls.Add(btnCancel);


                            }
                            p.Controls.Add(lblItems);
                            p.Controls.Add(lblDate);
                            p.Controls.Add(btnStatus);
                            flowLayoutPanel1.Controls.Add(p);
                        }
                    }
                }
            }
        }
        private void CancelOrder(int orderId, System.Windows.Forms.Panel panel)
        {
            var result = MessageBox.Show("Do you really want to cancel this order?", "Confirm Cancellation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var db = dao.DBConnection.getInstance();
                using (SqlConnection cnn = db.GetConnection())
                {
                    cnn.Open();

                    string query = "UPDATE Orders SET OrderStatus = 'Cancelled' WHERE OrderId = @orderId";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        cmd.ExecuteNonQuery();
                    }
                    cnn.Close();
                }
                flowLayoutPanel1.Controls.Remove(panel);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserViewOrders_Load(object sender, EventArgs e)
        {

        }
    }
}

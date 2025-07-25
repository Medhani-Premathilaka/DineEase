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
                            var panel = new System.Windows.Forms.Panel { Width = 500, Height = 80, Margin = new Padding(10) };
                            var lblItems = new System.Windows.Forms.Label // Specify the full namespace
                            {
                                Text = $"{reader["ProductName"]}: {reader["Quantity"]}",
                                AutoSize = true,
                                Font = new Font("Segoe UI", 10)
                            };
                            var lblDate = new System.Windows.Forms.Label // Specify the full namespace
                            {
                                Text = Convert.ToDateTime(reader["OrderDate"]).ToString("f"),
                                AutoSize = true,
                                Top = 30
                            };
                            var btnStatus = new System.Windows.Forms.Button
                            {
                                Text = reader["OrderStatus"].ToString(),
                                BackColor = reader["OrderStatus"].ToString() == "Pending" ? Color.Gold : Color.LightGreen,
                                Left = 300
                            };
                            panel.Controls.Add(lblItems);
                            panel.Controls.Add(lblDate);
                            panel.Controls.Add(btnStatus);

                            if (reader["OrderStatus"].ToString() == "Pending")
                            {
                                var btnCancel = new System.Windows.Forms.Button
                                {
                                    Text = "Cancel",
                                    BackColor = Color.Red,
                                    Left = 380
                                };
                                int orderId = Convert.ToInt32(reader["OrderId"]);
                                btnCancel.Click += (s, e) => CancelOrder(orderId, panel);
                                panel.Controls.Add(btnCancel);
                            }
                            flowLayoutPanel1.Controls.Add(panel);
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

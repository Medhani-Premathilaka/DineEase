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
                    WHERE UserId = @userId
                    ORDER BY OrderDate DESC";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@userId", CurrentUser.UserId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var panel = new Panel { Width = 500, Height = 80, Margin = new Padding(10) };
                            var lblItems = new Label
                            {
                                Text = $"{reader["ProductName"]}: {reader["Quantity"]}",
                                AutoSize = true,
                                Font = new Font("Segoe UI", 10)
                            };
                            var lblDate = new Label
                            {
                                Text = Convert.ToDateTime(reader["OrderDate"]).ToString("f"),
                                AutoSize = true,
                                Top = 30
                            };
                            var btnStatus = new Button
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
                                var btnCancel = new Button
                                {
                                    Text = "Cancel",
                                    BackColor = Color.Red,
                                    Left = 380
                                };
                                int orderId = Convert.ToInt32(reader["OrderId"]);
                                btnCancel.Click += (s, e) => CancelOrder(orderId);
                                panel.Controls.Add(btnCancel);
                            }
                            flowLayoutPanel1.Controls.Add(panel);
                        }
                    }
                }
            }
        }
        private void CancelOrder(int orderId)
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
            }
            LoadOrders();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

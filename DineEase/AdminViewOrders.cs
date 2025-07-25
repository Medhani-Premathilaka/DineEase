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
                    while (reader.Read())
                    {
                        string orderStatus = reader["OrderStatus"].ToString();

                        Panel orderPanel = new Panel
                        {
                            Width = 480,
                            Height = 90,
                            BackColor = Color.White,
                            BorderStyle = BorderStyle.FixedSingle,
                            Margin = new Padding(10),
                        };

                        int orderId = Convert.ToInt32(reader["OrderID"]);

                        if (orderStatus.ToLower() == "done")
                        {

                            // Show only "Done" button
                            Button btnDone = new Button
                            {
                                Text = "Done",
                                BackColor = Color.Gray,
                                ForeColor = Color.White,
                                FlatStyle = FlatStyle.Flat,
                                Size = new Size(70, 30),
                                Location = new Point((orderPanel.Width - 70) / 2, (orderPanel.Height - 30) / 2)
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
                                        MessageBox.Show("Order marked as done and removed.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to remove order.");
                                    }
                                }
                            };

                            orderPanel.Controls.Add(btnDone);


                        }
                        else
                        {
                            // Normal display for non-done orders
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

                            Button btnAccept = new Button
                            {
                                Text = "Accept",
                                BackColor = Color.Green,
                                ForeColor = Color.White,
                                FlatStyle = FlatStyle.Flat,
                                Size = new Size(70, 30),
                                Location = new Point(300, 30)
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
                                Location = new Point(380, 30)
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

                            orderNumber++;
                        }

                        flowLayoutPanel1.Controls.Add(orderPanel);
                    }

                }

                conn.Close();
            }



        }




        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}

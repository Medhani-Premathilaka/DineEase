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
                    Panel orderPanel = new Panel
                    {
                        Width = 480,
                        Height = 90,
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(10),
                    };

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



                    //   Label lblTime = new Label
                    //{
                    //    Text = reader["OrderDate"] != DBNull.Value && DateTime.TryParse(reader["OrderDate"].ToString(), out DateTime orderDate)
                    //        ? "Today " + orderDate.ToString("h:mm tt").ToLower()
                    //        : "No Date Available",
                    //    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                    //    ForeColor = Color.Gray,
                    //    Location = new Point(40, 40),
                    //    AutoSize = true
                    //};
                    //orderPanel.Controls.Add(lblTime);

                    Button btnAccept = new Button
                    {
                        Text = "Accept",
                        BackColor = Color.Green,
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Size = new Size(70, 30),
                        Location = new Point(300, 30)
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
                    orderPanel.Controls.Add(btnReject);

                    flowLayoutPanel1.Controls.Add(orderPanel);
                    orderNumber++;
                }

                conn.Close();
            }
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}

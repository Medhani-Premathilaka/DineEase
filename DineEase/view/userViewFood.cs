using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DineEase.view;
using Guna.UI2.WinForms;

namespace DineEase
{
    public partial class userViewFood : Form, ShowPage
    {
        public userViewFood()
        {
            InitializeComponent();
        }

        //string connectionString = @"Server=dineease.chc86qwacnkf.eu-north-1.rds.amazonaws.com;Database=DineEase;User Id=admin;Password=DineEase;";

        //private void UserViewProduct_Load(object sender, EventArgs e)
        //{
        //    //test commit
        //    LoadFoodItems();
        //}

        private void LoadFoodItems()
        {
            //flowLayoutPanel1.Controls.Clear();

            string query = "SELECT * FROM DineEase.dbo.FoodProduct";
            var db = dao.DBConnection.getInstance();
            using (SqlConnection cnn = db.GetConnection())


            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    Guna2ShadowPanel card = new Guna2ShadowPanel
                    {
                        Width = 180,
                        Height = 240,
                        BorderStyle = BorderStyle.None,
                        BackColor = Color.White,
                        Tag = reader["ProductID"], // Store ProductID                       
                        Radius = 5,

                    };


                    Label nameLabel = new Label
                    {
                        Text = reader["ProductName"].ToString(),
                        Top = 169,
                        Left = 15,
                        Width = 150,
                        Height = 30,
                        Font = new Font("Verdana", 10, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter,
                    };


                    Label priceLable = new Label
                    {
                        Text = "Rs." + reader["Price"].ToString(),
                        Top = 199,
                        Left = 25,
                        Width = 130,
                        Height = 30,
                        //BackColor = Color.FromArgb(106, 77, 126),
                        //BackColor = Color.FromArgb(213, 159, 252),
                        //BackColor = Color.FromArgb(147, 133, 227),
                        BackColor = Color.FromArgb(159, 182, 252),
                        //(13,31,102)
                        Font = new Font("Verdana", 10, FontStyle.Bold),
                        ForeColor = Color.White,

                        TextAlign = ContentAlignment.MiddleCenter
                    };


                    Guna2PictureBox picture = new Guna2PictureBox
                    {
                        Width = 158,
                        Height = 158,
                        Top = 11,
                        Left = 11,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderRadius = 5,
                    };

                    byte[] imageData = (byte[])reader["Image"];
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        picture.Image = Image.FromStream(ms);
                    }


                    card.Controls.Add(picture);
                    card.Controls.Add(nameLabel);
                    card.Controls.Add(priceLable);

                    // Add click event to the whole card
                    card.Click += Card_Click;
                    picture.Click += Card_Click;
                    nameLabel.Click += Card_Click;

                    flowLayoutPanel1.Controls.Add(card);

                    foreach (Control c in flowLayoutPanel1.Controls)
                    {
                        c.Margin = new Padding(5, 2, 5, 2);
                    }
                }
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {

            Control clicked = sender as Control;
            Panel panel = clicked is Panel ? (Panel)clicked : (Panel)clicked.Parent;
            int productId = (int)panel.Tag;

            string userId = CurrentUser.UserId;
            FoodDetails detailsForm = new FoodDetails(productId, userId);
            //ShowFoodDetails(productId);
            detailsForm.ShowDialog();
        }



        private void userViewFood_Load(object sender, EventArgs e)
        {
            LoadFoodItems();
            flowLayoutPanel1.Width = this.ClientSize.Width;
            guna2Panel1.Width = 70;

            flowLayoutPanel1.Padding = new Padding(10);
            foreach (Control card in flowLayoutPanel1.Controls)
            {
                card.Margin = new Padding(15); // 15px space between cards
            }

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int panelExpandedWidth = 180;  // Width when expanded
        private int panelCollapsedWidth = 70;  // Width when collapsed
        private bool isCollapsed = true;

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void showPage()
        {
            this.Show();
        }

        private void userViewOrders_Click(object sender, EventArgs e)
        {
            var userOrdersView = new UserViewOrders();
            userOrdersView.Show();
        }
        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            var userOrdersView = new UserViewOrders();
            userOrdersView.Show();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            navTimer.Start();
        }

        private void navTimer_Tick(object sender, EventArgs e)
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DineEase
{
    public partial class userViewFood : Form
    {
        public userViewFood()
        {
            InitializeComponent();
        }

        string connectionString = @"Server=dineease.chc86qwacnkf.eu-north-1.rds.amazonaws.com;Database=DineEase;User Id=admin;Password=DineEase;";

        //private void UserViewProduct_Load(object sender, EventArgs e)
        //{
        //    //test commit
        //    LoadFoodItems();
        //}

        private void LoadFoodItems()
        {
            flowLayoutPanel1.Controls.Clear();

            string query = "SELECT * FROM DineEase.dbo.FoodProduct";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    //Panel card = new Panel
                    Guna2ShadowPanel card = new Guna2ShadowPanel
                    {
                        Width = 176,
                        Height = 240,
                        BorderStyle = BorderStyle.None,
                        BackColor = Color.White,
                        Tag = reader["ProductID"], // Store ProductID
                        //ShadowColor = Color.DarkBlue
                        Radius = 5
                    };

                    

                    Label nameLabel = new Label
                    {
                        Text = reader["ProductName"].ToString(),
                        Top = 169,
                        Left = 13,
                        Width = 150,
                        Height=30,
                       // BackColor = Color.Brown,
                        Font = new Font("Verdana", 10, FontStyle.Bold ),
                        TextAlign = ContentAlignment.MiddleCenter,

                    };

                    //273F4F
                    Label priceLable = new Label
                    {
                        Text = "Rs." + reader["Price"].ToString(),
                        Top = 199,
                        Left = 23,
                        Width = 130,
                        Height = 30,
                        BackColor = Color.FromArgb(228, 244, 252),
                        //(13,31,102)
                        Font = new Font("Verdana", 10, FontStyle.Bold),
                        ForeColor = Color.Black,

                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    //PictureBox picture = new PictureBox
                    Guna2PictureBox picture = new Guna2PictureBox
                    {
                        Width = 150,
                        Height = 158,
                        Top = 11,
                        Left = 13,
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
                    card.Click +=  Card_Click;
                    picture.Click += Card_Click;
                    nameLabel.Click += Card_Click;

                    flowLayoutPanel1.Controls.Add(card);
                }
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            this.Hide();
            Control clicked = sender as Control;
            Panel panel = clicked is Panel ? (Panel)clicked : (Panel)clicked.Parent;
            int productId = (int)panel.Tag;

            FoodDetails detailsForm = new FoodDetails(productId);
            //ShowFoodDetails(productId);
            detailsForm.ShowDialog();
        }

        //private void ShowFoodDetails(int productId)
        //{
        //    string query = "SELECT * FROM FoodProduct WHERE ProductID = @id";
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    using (SqlCommand cmd = new SqlCommand(query, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@id", productId);
        //        conn.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            // Create or show a details form or panel
        //            Form detailsForm = new Form
        //            {
        //                Width = 400,
        //                Height = 500,
        //                Text = reader["ProductName"].ToString()
        //            };

        //            PictureBox pic = new PictureBox
        //            {
        //                Width = 200,
        //                Height = 200,
        //                Top = 20,
        //                Left = 100,
        //                SizeMode = PictureBoxSizeMode.StretchImage
        //            };

        //            byte[] imageData = (byte[])reader["Image"];
        //            using (MemoryStream ms = new MemoryStream(imageData))
        //            {
        //                pic.Image = Image.FromStream(ms);
        //            }

        //            Label nameLabel = new Label
        //            {
        //                Text = "Name: " + reader["ProductName"].ToString(),
        //                Top = 240,
        //                Left = 50,
        //                Width = 300
        //            };

        //            Label priceLabel = new Label
        //            {
        //                Text = "Price: Rs. " + reader["Price"].ToString(),
        //                Top = 270,
        //                Left = 50,
        //                Width = 300
        //            };

        //            Label descLabel = new Label
        //            {
        //                Text = "Description: " + reader["Description"].ToString(),
        //                Top = 300,
        //                Left = 50,
        //                Width = 300,
        //                Height = 100
        //            };

        //            detailsForm.Controls.Add(pic);
        //            detailsForm.Controls.Add(nameLabel);
        //            detailsForm.Controls.Add(priceLabel);
        //            detailsForm.Controls.Add(descLabel);
        //            detailsForm.ShowDialog();
        //        }
        //    }
        //}

        //private void guna2Button2_Click(object sender, EventArgs e)
        //{

        //}

        //private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        //{
        
        //}

        private void userViewFood_Load(object sender, EventArgs e)
        {
            LoadFoodItems();
            flowLayoutPanel1.Width = this.ClientSize.Width;
            guna2Panel1.Width = 70;
            
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private int panelExpandedWidth = 170;  // Width when expanded
        private int panelCollapsedWidth = 70;  // Width when collapsed
        private bool isCollapsed = true;

        //private void guna2PictureBox1_Click(object sender, EventArgs e)
        //{

        //}

        //private void guna2ImageButton1_Click(object sender, EventArgs e)
        //{
           


        //}

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            navTimer.Start();
        }

        private void navTimer_Tick_1(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                guna2Panel1.Width += 10;
                if (guna2Panel1.Width >= panelExpandedWidth)
                {
                    navTimer.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                guna2Panel1.Width -= 10;
                if (guna2Panel1.Width <= panelCollapsedWidth)
                {
                    navTimer.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

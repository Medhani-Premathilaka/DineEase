using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
                    Panel card = new Panel
                    {
                        Width = 158,
                        Height = 218,
                        BorderStyle = BorderStyle.Fixed3D,
                        BackColor = SystemColors.Window,
                        Tag = reader["ProductID"] // Store ProductID
                    };


                    Label nameLabel = new Label
                    {
                        Text = reader["ProductName"].ToString(),
                        Top = 158,
                        Left = 0,
                        Width = 158,
                        Height=30,
                       // BackColor = Color.Brown,
                        Font = new Font("Verdana", 10, FontStyle.Bold ),
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    //273F4F
                    Label priceLable = new Label
                    {
                        Text = "Rs." + reader["Price"].ToString(),
                        Top = 188,
                        Left = 0,
                        Width = 158,
                        Height=30,
                        BackColor = Color.Orange,
                        Font = new Font("Verdana", 10, FontStyle.Bold),
                        ForeColor = Color.White,
                        
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    PictureBox picture = new PictureBox
                    {
                        Width = 158,
                        Height = 158,
                        Top = 0,
                        Left = 0,
                        SizeMode = PictureBoxSizeMode.StretchImage
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
                }
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
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
            
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DineEase
{
    public partial class userViewFood : Form, ShowPage
    {
        public userViewFood()
        {
            InitializeComponent();
        }


        //private void UserViewProduct_Load(object sender, EventArgs e)
        //{
        //    //test commit
        //    LoadFoodItems();
        //}

        private void LoadFoodItems()
        {
            flowLayoutPanel1.Controls.Clear();

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
            this.Hide();
            Control clicked = sender as Control;
            Panel panel = clicked is Panel ? (Panel)clicked : (Panel)clicked.Parent;
            int productId = (int)panel.Tag;

            FoodDetails detailsForm = new FoodDetails(productId);
            detailsForm.ShowDialog();
        }



        private void userViewFood_Load(object sender, EventArgs e)
        {
            LoadFoodItems();
            flowLayoutPanel1.Width = this.ClientSize.Width;

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void showPage()
        {
            this.Show();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {

        }
    }
}
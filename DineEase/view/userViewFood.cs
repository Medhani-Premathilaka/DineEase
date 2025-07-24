using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
                        Height = 30,
                        // BackColor = Color.Brown,
                        Font = new Font("Verdana", 10, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    //273F4F
                    Label priceLable = new Label
                    {
                        Text = "Rs." + reader["Price"].ToString(),
                        Top = 188,
                        Left = 0,
                        Width = 158,
                        Height = 30,
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
    }
}
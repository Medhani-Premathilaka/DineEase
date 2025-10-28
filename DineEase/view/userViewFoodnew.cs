using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DineEase.view
{
    public partial class userViewFoodnew : Form, ShowPage
    {
        private int panelExpandedWidth = 180;  // Width when expanded
        private int panelCollapsedWidth = 70;  // Width when collapsed
        private bool isCollapsed = true;
        private string studentId;

        public userViewFoodnew()
        {
            InitializeComponent();

            // Ensure the nav panel starts collapsed with only icons visible
            guna2Panel1.Width = panelCollapsedWidth;
            isCollapsed = true;
            // Hide text labels while collapsed
            homeBtn.Visible = false;
            ordersBtn.Visible = false;
            historyBtn.Visible = false;
            settingBtn.Visible = false;
            profileBtn.Visible = false;
            logo.Visible = false;

            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = true; // allows wrapping to next row
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;

            //flowLayoutPanel1.AutoScroll = true; // allow scrolling

            AdjustControlPositions();

            this.ControlBox = true;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            LoadFoodItems();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            flowLayoutPanel1.Padding = new Padding(0, 20, 0, 20);
            foreach (Control card in flowLayoutPanel1.Controls)
            {
                card.Margin = new Padding(15); // 15px space between cards
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            Control clicked = sender as Control;
            Panel panel = clicked is Panel ? (Panel)clicked : (Panel)clicked.Parent;
            int productId = (int)panel.Tag;

            string userId = CurrentUser.UserId;
            FoodDetails detailsForm = new FoodDetails(productId, userId);

            BlurForm blur = new BlurForm(this);
            blur.Size = this.Size;
            blur.Location = this.Location;
            blur.Owner = this;
            blur.Show();

            detailsForm.StartPosition = FormStartPosition.CenterParent;
            detailsForm.ShowDialog();

            blur.Close();
        }

        private void ShowInFlow(Form child)
        {
            flowLayoutPanel1.Controls.Clear();
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Visible = true;
            child.Size = flowLayoutPanel1.ClientSize;
            flowLayoutPanel1.Controls.Add(child);

            child.Show();
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            LoadFoodItems();
        }

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
                        Tag = reader["ProductID"],
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
                        BackColor = Color.FromArgb(106, 77, 126),
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

                    card.Click += Card_Click;
                    picture.Click += Card_Click;
                    nameLabel.Click += Card_Click;

                    flowLayoutPanel1.Controls.Add(card);

                    foreach (Control c in flowLayoutPanel1.Controls)
                    {
                        c.Margin = new Padding(5, 2, 5, 2);
                    }
                }
                cnn.Close();
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
                        ctrl.Location = new Point(guna2Panel1.Width - ctrl.Width - 5, ctrl.Location.Y);
                }
                else if (!isCollapsed)
                {
                    ctrl.Location = new Point(10, ctrl.Location.Y);
                }
            }
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            var ordersView = new UserViewOrders();
            ShowInFlow(ordersView);
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            string studentId = CurrentUser.UserId;
            var viewUserHistory = new ViewUserHistory(studentId);
            ShowInFlow(viewUserHistory);
        }

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {
            string studentId = CurrentUser.UserId;

            try
            {
                BlurForm blur = new BlurForm(this)
                {
                    StartPosition = FormStartPosition.Manual,
                    Size = this.Size,
                    Location = this.Location,
                    Owner = this
                };
                blur.Show();

                UserProfile userProfile = new UserProfile(studentId)
                {
                    StartPosition = FormStartPosition.CenterParent
                };

                userProfile.FormClosed += (s2, e2) => blur.Close();
                userProfile.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying profile: " + ex.Message);
            }
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
                                       "Logout Confirmation",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form1 loginPage = new Form1();
                loginPage.Show();
            }
        }

        public void showPage()
        {
            this.Show();
        }

        private void navTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                guna2Panel1.Width += 10;
                if (guna2Panel1.Width >= panelExpandedWidth)
                {
                    navTimer.Stop();
                    isCollapsed = false;

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
                logo.Visible = false;
                homeBtn.Visible = false;
                ordersBtn.Visible = false;
                historyBtn.Visible = false;
                settingBtn.Visible = false;
                profileBtn.Visible = false;
                guna2ImageButton1.Image = Image.FromFile("Resources\\expand.png");

                guna2Panel1.Width -= 10;
                if (guna2Panel1.Width <= panelCollapsedWidth)
                {
                    navTimer.Stop();
                    isCollapsed = true;
                    AdjustControlPositions();
                }
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            navTimer.Start();
        }

        private void userViewFoodnew_Load(object sender, EventArgs e)
        {

        }
    }
}
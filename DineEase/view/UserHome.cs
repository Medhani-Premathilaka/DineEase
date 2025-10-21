using System;
using System.Windows.Forms;

namespace DineEase.view
{
    public partial class UserHome : Form
    {
        public UserHome()
        {
            InitializeComponent();
        }

        private void UserHome_Load(object sender, EventArgs e)
        {

            flowLayoutPanel1.Width = this.ClientSize.Width;
            //guna2Panel1.Width = 70;

            flowLayoutPanel1.Padding = new Padding(10);
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

            BlurForm blur = new BlurForm();
            blur.Size = this.Size;
            blur.Location = this.Location;
            blur.Owner = this;
            blur.Show();
            string userId = CurrentUser.UserId; // Example: static property or passed from login

            var foodDetailsForm = new FoodDetails(productId, userId);
            //FoodDetails detailsForm = new FoodDetails(UserId, productId);
            foodDetailsForm.StartPosition = FormStartPosition.CenterParent;
            foodDetailsForm.ShowDialog();

            blur.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

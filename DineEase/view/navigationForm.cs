using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DineEase.view
{
    public partial class navigationForm : Form
    {
        public navigationForm()
        {
            InitializeComponent();
        }


        private int panelExpandedWidth = 180;  // Width when expanded
        private int panelCollapsedWidth = 70;  // Width when collapsed
        private bool isCollapsed = true;


        private void navigationForm_Load(object sender, EventArgs e)
        {
            guna2Panel1.Width = 70;
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

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            navTimer.Start();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            guna2Panel3.Controls.Clear();

            UserHome home = new UserHome();
            home.TopLevel = false;
            // home.FormBorderStyle = FormBorderStyle.None;
            home.Dock = DockStyle.Fill;

            guna2Panel3.Controls.Add(home);
            home.Show();
        }
    }
}

namespace DineEase
{
    partial class AdminHomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminHomePage));
            this.addButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ImageButton6 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton5 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.profileButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ImageButton4 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton3 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton2 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.historyButton = new Guna.UI2.WinForms.Guna2Button();
            this.settingButton = new Guna.UI2.WinForms.Guna2Button();
            this.viewOrderButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.BorderRadius = 20;
            this.addButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.addButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(96, 154);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(126, 45);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add Item";
            this.addButton.Click += new System.EventHandler(this.guna2ButtonAddNewItem_Click_1);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("MV Boli", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(0, 13);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Padding = new System.Windows.Forms.Padding(4);
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(126, 44);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "DineEase";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Controls.Add(this.guna2ImageButton6);
            this.guna2Panel1.Controls.Add(this.guna2ImageButton5);
            this.guna2Panel1.Controls.Add(this.profileButton);
            this.guna2Panel1.Controls.Add(this.guna2ImageButton4);
            this.guna2Panel1.Controls.Add(this.guna2ImageButton3);
            this.guna2Panel1.Controls.Add(this.guna2ImageButton2);
            this.guna2Panel1.Controls.Add(this.guna2ImageButton1);
            this.guna2Panel1.Controls.Add(this.historyButton);
            this.guna2Panel1.Controls.Add(this.settingButton);
            this.guna2Panel1.Controls.Add(this.viewOrderButton);
            this.guna2Panel1.Controls.Add(this.addButton);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(228, 808);
            this.guna2Panel1.TabIndex = 3;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // guna2ImageButton6
            // 
            this.guna2ImageButton6.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton6.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton6.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton6.Image")));
            this.guna2ImageButton6.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton6.ImageRotate = 0F;
            this.guna2ImageButton6.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton6.Location = new System.Drawing.Point(16, 715);
            this.guna2ImageButton6.Name = "guna2ImageButton6";
            this.guna2ImageButton6.PressedState.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton6.Size = new System.Drawing.Size(64, 54);
            this.guna2ImageButton6.TabIndex = 13;
            // 
            // guna2ImageButton5
            // 
            this.guna2ImageButton5.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton5.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton5.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton5.Image")));
            this.guna2ImageButton5.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton5.ImageRotate = 0F;
            this.guna2ImageButton5.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton5.Location = new System.Drawing.Point(16, 268);
            this.guna2ImageButton5.Name = "guna2ImageButton5";
            this.guna2ImageButton5.PressedState.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton5.Size = new System.Drawing.Size(64, 54);
            this.guna2ImageButton5.TabIndex = 12;
            this.guna2ImageButton5.Click += new System.EventHandler(this.guna2ImageButton5_Click);
            // 
            // profileButton
            // 
            this.profileButton.BorderRadius = 20;
            this.profileButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.profileButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.profileButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.profileButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.profileButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.profileButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileButton.ForeColor = System.Drawing.Color.White;
            this.profileButton.Location = new System.Drawing.Point(86, 724);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(126, 45);
            this.profileButton.TabIndex = 11;
            this.profileButton.Text = "Profile";
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click_1);
            // 
            // guna2ImageButton4
            // 
            this.guna2ImageButton4.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton4.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton4.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton4.Image")));
            this.guna2ImageButton4.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton4.ImageRotate = 0F;
            this.guna2ImageButton4.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton4.Location = new System.Drawing.Point(16, 639);
            this.guna2ImageButton4.Name = "guna2ImageButton4";
            this.guna2ImageButton4.PressedState.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton4.Size = new System.Drawing.Size(64, 54);
            this.guna2ImageButton4.TabIndex = 10;
            this.guna2ImageButton4.Click += new System.EventHandler(this.guna2ImageButton4_Click);
            // 
            // guna2ImageButton3
            // 
            this.guna2ImageButton3.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton3.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton3.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton3.Image")));
            this.guna2ImageButton3.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton3.ImageRotate = 0F;
            this.guna2ImageButton3.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton3.Location = new System.Drawing.Point(22, 209);
            this.guna2ImageButton3.Name = "guna2ImageButton3";
            this.guna2ImageButton3.PressedState.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton3.Size = new System.Drawing.Size(51, 53);
            this.guna2ImageButton3.TabIndex = 9;
            this.guna2ImageButton3.Click += new System.EventHandler(this.guna2ImageButton3_Click);
            // 
            // guna2ImageButton2
            // 
            this.guna2ImageButton2.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton2.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton2.Image")));
            this.guna2ImageButton2.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton2.ImageRotate = 0F;
            this.guna2ImageButton2.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton2.Location = new System.Drawing.Point(28, 154);
            this.guna2ImageButton2.Name = "guna2ImageButton2";
            this.guna2ImageButton2.PressedState.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton2.Size = new System.Drawing.Size(45, 38);
            this.guna2ImageButton2.TabIndex = 8;
            this.guna2ImageButton2.Click += new System.EventHandler(this.guna2ImageButton2_Click);
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton1.Image")));
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton1.Location = new System.Drawing.Point(12, 12);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2ImageButton1.Size = new System.Drawing.Size(67, 45);
            this.guna2ImageButton1.TabIndex = 7;
            this.guna2ImageButton1.Click += new System.EventHandler(this.guna2ImageButton1_Click_1);
            // 
            // historyButton
            // 
            this.historyButton.BorderRadius = 20;
            this.historyButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.historyButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.historyButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.historyButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.historyButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.historyButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyButton.ForeColor = System.Drawing.Color.White;
            this.historyButton.Location = new System.Drawing.Point(96, 277);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(126, 45);
            this.historyButton.TabIndex = 6;
            this.historyButton.Text = "History";
            this.historyButton.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // settingButton
            // 
            this.settingButton.BorderRadius = 20;
            this.settingButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.settingButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.settingButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.settingButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.settingButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.settingButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingButton.ForeColor = System.Drawing.Color.White;
            this.settingButton.Location = new System.Drawing.Point(96, 648);
            this.settingButton.Name = "settingButton";
            this.settingButton.Size = new System.Drawing.Size(126, 45);
            this.settingButton.TabIndex = 5;
            this.settingButton.Text = "Setting";
            this.settingButton.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // viewOrderButton
            // 
            this.viewOrderButton.BorderRadius = 20;
            this.viewOrderButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.viewOrderButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.viewOrderButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.viewOrderButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.viewOrderButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.viewOrderButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewOrderButton.ForeColor = System.Drawing.Color.White;
            this.viewOrderButton.Location = new System.Drawing.Point(96, 217);
            this.viewOrderButton.Name = "viewOrderButton";
            this.viewOrderButton.Size = new System.Drawing.Size(126, 45);
            this.viewOrderButton.TabIndex = 3;
            this.viewOrderButton.Text = "View Order";
            this.viewOrderButton.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.Controls.Add(this.guna2ControlBox3);
            this.guna2Panel2.Controls.Add(this.guna2ControlBox2);
            this.guna2Panel2.Controls.Add(this.guna2ControlBox1);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(228, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(700, 29);
            this.guna2Panel2.TabIndex = 4;
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.Red;
            this.guna2ControlBox3.Location = new System.Drawing.Point(629, 0);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.Size = new System.Drawing.Size(37, 29);
            this.guna2ControlBox3.TabIndex = 2;
            this.guna2ControlBox3.Click += new System.EventHandler(this.guna2ControlBox3_Click);
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.Red;
            this.guna2ControlBox2.Location = new System.Drawing.Point(597, 0);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(37, 29);
            this.guna2ControlBox2.TabIndex = 1;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.Location = new System.Drawing.Point(663, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(37, 29);
            this.guna2ControlBox1.TabIndex = 0;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(228, 29);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(700, 779);
            this.flowLayoutPanel1.TabIndex = 5;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint_2);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            // 
            // AdminHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(928, 808);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminHomePage";
            this.Text = "AdminHome";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminHomePage_Load_1);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button addButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button historyButton;
        private Guna.UI2.WinForms.Guna2Button settingButton;
        private Guna.UI2.WinForms.Guna2Button viewOrderButton;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton2;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton3;
        private Guna.UI2.WinForms.Guna2Button profileButton;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton4;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton6;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton5;
        private System.Windows.Forms.Timer timer1;
    }
}
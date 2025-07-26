namespace DineEase
{
    partial class FoodDetails
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
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtCustomer = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddToOrder = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.reduceBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.increaseBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2ShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPrice.AutoSize = true;
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(88, 458);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(80, 29);
            this.lblPrice.TabIndex = 17;
            this.lblPrice.Text = "price";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblName.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(87, 334);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(103, 34);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderRadius = 10;
            this.pictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ImageRotate = 0F;
            this.pictureBox1.Location = new System.Drawing.Point(23, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 289);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseTransparentBackground = true;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.BackColor = System.Drawing.Color.Transparent;
            this.lblQuantity.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(182, 531);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(30, 29);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "1";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDesc
            // 
            this.lblDesc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDesc.AutoSize = true;
            this.lblDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblDesc.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblDesc.Location = new System.Drawing.Point(88, 398);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(77, 29);
            this.lblDesc.TabIndex = 16;
            this.lblDesc.Text = "Desc";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDesc.Click += new System.EventHandler(this.lblDesc_Click);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomer.DefaultText = "";
            this.txtCustomer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomer.Location = new System.Drawing.Point(161, 94);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.PlaceholderText = "";
            this.txtCustomer.SelectedText = "";
            this.txtCustomer.Size = new System.Drawing.Size(91, 31);
            this.txtCustomer.TabIndex = 19;
            // 
            // btnAddToOrder
            // 
            this.btnAddToOrder.AutoRoundedCorners = true;
            this.btnAddToOrder.BorderRadius = 22;
            this.btnAddToOrder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddToOrder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddToOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddToOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddToOrder.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAddToOrder.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddToOrder.ForeColor = System.Drawing.Color.White;
            this.btnAddToOrder.Location = new System.Drawing.Point(97, 616);
            this.btnAddToOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddToOrder.Name = "btnAddToOrder";
            this.btnAddToOrder.Size = new System.Drawing.Size(219, 46);
            this.btnAddToOrder.TabIndex = 18;
            this.btnAddToOrder.Text = "Order Now";
            this.btnAddToOrder.Click += new System.EventHandler(this.btnAddToOrder_Click);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.reduceBtn);
            this.guna2ShadowPanel1.Controls.Add(this.increaseBtn);
            this.guna2ShadowPanel1.Controls.Add(this.guna2ControlBox1);
            this.guna2ShadowPanel1.Controls.Add(this.pictureBox1);
            this.guna2ShadowPanel1.Controls.Add(this.lblName);
            this.guna2ShadowPanel1.Controls.Add(this.lblPrice);
            this.guna2ShadowPanel1.Controls.Add(this.btnAddToOrder);
            this.guna2ShadowPanel1.Controls.Add(this.txtCustomer);
            this.guna2ShadowPanel1.Controls.Add(this.lblQuantity);
            this.guna2ShadowPanel1.Controls.Add(this.lblDesc);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(3, 3);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 10;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(413, 700);
            this.guna2ShadowPanel1.TabIndex = 20;
            // 
            // reduceBtn
            // 
            this.reduceBtn.BackColor = System.Drawing.Color.Transparent;
            this.reduceBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.reduceBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.reduceBtn.BorderThickness = 3;
            this.reduceBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.reduceBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.reduceBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.reduceBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.reduceBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(117)))), ((int)(((byte)(187)))));
            this.reduceBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reduceBtn.ForeColor = System.Drawing.Color.White;
            this.reduceBtn.Location = new System.Drawing.Point(93, 523);
            this.reduceBtn.Name = "reduceBtn";
            this.reduceBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.reduceBtn.Size = new System.Drawing.Size(50, 50);
            this.reduceBtn.TabIndex = 22;
            this.reduceBtn.Text = "-";
            this.reduceBtn.Click += new System.EventHandler(this.reduceBtn_Click);
            // 
            // increaseBtn
            // 
            this.increaseBtn.BackColor = System.Drawing.Color.Transparent;
            this.increaseBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.increaseBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.increaseBtn.BorderThickness = 3;
            this.increaseBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.increaseBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.increaseBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.increaseBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.increaseBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(117)))), ((int)(((byte)(187)))));
            this.increaseBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.increaseBtn.ForeColor = System.Drawing.Color.White;
            this.increaseBtn.Location = new System.Drawing.Point(242, 523);
            this.increaseBtn.Name = "increaseBtn";
            this.increaseBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.increaseBtn.Size = new System.Drawing.Size(50, 50);
            this.increaseBtn.TabIndex = 21;
            this.increaseBtn.Text = "+";
            this.increaseBtn.Click += new System.EventHandler(this.increaseBtn_Click);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guna2ControlBox1.Location = new System.Drawing.Point(332, 36);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 20;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // FoodDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(117)))), ((int)(((byte)(187)))));
            this.ClientSize = new System.Drawing.Size(419, 706);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FoodDetails";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FoodDetails";
            this.Load += new System.EventHandler(this.FoodDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblName;
        private Guna.UI2.WinForms.Guna2PictureBox pictureBox1;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblDesc;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomer;
        private Guna.UI2.WinForms.Guna2Button btnAddToOrder;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2CircleButton reduceBtn;
        private Guna.UI2.WinForms.Guna2CircleButton increaseBtn;
    }
}
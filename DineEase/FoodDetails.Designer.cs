﻿namespace DineEase
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
            this.btnDecrease = new Guna.UI2.WinForms.Guna2Button();
            this.btnIncrease = new Guna.UI2.WinForms.Guna2Button();
            this.Closebtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtCustomer = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddToOrder = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(575, 178);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(75, 37);
            this.lblPrice.TabIndex = 17;
            this.lblPrice.Text = "price";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(575, 106);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(83, 37);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ImageRotate = 0F;
            this.pictureBox1.Location = new System.Drawing.Point(93, 92);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 316);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseTransparentBackground = true;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(158, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(55, 37);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "qty";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(585, 254);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(73, 37);
            this.lblDesc.TabIndex = 16;
            this.lblDesc.Text = "Desc";
            // 
            // btnDecrease
            // 
            this.btnDecrease.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDecrease.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDecrease.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDecrease.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDecrease.FillColor = System.Drawing.Color.MediumPurple;
            this.btnDecrease.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrease.ForeColor = System.Drawing.Color.White;
            this.btnDecrease.Location = new System.Drawing.Point(3, 1);
            this.btnDecrease.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(57, 36);
            this.btnDecrease.TabIndex = 8;
            this.btnDecrease.Text = "-";
            // 
            // btnIncrease
            // 
            this.btnIncrease.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIncrease.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIncrease.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIncrease.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIncrease.FillColor = System.Drawing.Color.MediumPurple;
            this.btnIncrease.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncrease.ForeColor = System.Drawing.Color.White;
            this.btnIncrease.Location = new System.Drawing.Point(317, 1);
            this.btnIncrease.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(58, 36);
            this.btnIncrease.TabIndex = 7;
            this.btnIncrease.Text = "+";
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click_1);
            // 
            // Closebtn
            // 
            this.Closebtn.AutoRoundedCorners = true;
            this.Closebtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Closebtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Closebtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Closebtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Closebtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Closebtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Closebtn.ForeColor = System.Drawing.Color.White;
            this.Closebtn.Location = new System.Drawing.Point(392, 510);
            this.Closebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(160, 36);
            this.Closebtn.TabIndex = 22;
            this.Closebtn.Text = "Close";
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click_1);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.AutoRoundedCorners = true;
            this.guna2Panel2.BackColor = System.Drawing.Color.MediumPurple;
            this.guna2Panel2.Controls.Add(this.btnDecrease);
            this.guna2Panel2.Controls.Add(this.btnIncrease);
            this.guna2Panel2.Controls.Add(this.lblQuantity);
            this.guna2Panel2.Location = new System.Drawing.Point(83, 438);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(378, 39);
            this.guna2Panel2.TabIndex = 21;
            this.guna2Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel2_Paint_1);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(75)))), ((int)(((byte)(222)))));
            this.guna2Panel1.Location = new System.Drawing.Point(62, 8);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(829, 65);
            this.guna2Panel1.TabIndex = 20;
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
            this.txtCustomer.Location = new System.Drawing.Point(557, 324);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.PlaceholderText = "";
            this.txtCustomer.SelectedText = "";
            this.txtCustomer.Size = new System.Drawing.Size(254, 48);
            this.txtCustomer.TabIndex = 19;
            // 
            // btnAddToOrder
            // 
            this.btnAddToOrder.AutoRoundedCorners = true;
            this.btnAddToOrder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddToOrder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddToOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddToOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddToOrder.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAddToOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToOrder.ForeColor = System.Drawing.Color.White;
            this.btnAddToOrder.Location = new System.Drawing.Point(568, 438);
            this.btnAddToOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddToOrder.Name = "btnAddToOrder";
            this.btnAddToOrder.Size = new System.Drawing.Size(160, 36);
            this.btnAddToOrder.TabIndex = 18;
            this.btnAddToOrder.Text = "Order";
            this.btnAddToOrder.Click += new System.EventHandler(this.btnAddToOrder_Click_1);
            // 
            // FoodDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 554);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.Closebtn);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.btnAddToOrder);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FoodDetails";
            this.Text = "FoodDetails";
            this.Load += new System.EventHandler(this.FoodDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblName;
        private Guna.UI2.WinForms.Guna2PictureBox pictureBox1;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblDesc;
        private Guna.UI2.WinForms.Guna2Button btnDecrease;
        private Guna.UI2.WinForms.Guna2Button btnIncrease;
        private Guna.UI2.WinForms.Guna2Button Closebtn;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomer;
        private Guna.UI2.WinForms.Guna2Button btnAddToOrder;
    }
}
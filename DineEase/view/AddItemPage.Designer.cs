namespace DineEase
{
    partial class AddItemPage
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
            this.pictureBoxItem = new Guna.UI2.WinForms.Guna2PictureBox();
            this.createbtn = new Guna.UI2.WinForms.Guna2Button();
            this.resetbtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TextBoxPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBoxName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2TextBoxDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnImportImage = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem)).BeginInit();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxItem
            // 
            this.pictureBoxItem.ImageRotate = 0F;
            this.pictureBoxItem.Location = new System.Drawing.Point(658, 94);
            this.pictureBoxItem.Name = "pictureBoxItem";
            this.pictureBoxItem.Size = new System.Drawing.Size(222, 200);
            this.pictureBoxItem.TabIndex = 12;
            this.pictureBoxItem.TabStop = false;
            this.pictureBoxItem.Click += new System.EventHandler(this.pictureBoxItem_Click);
            // 
            // createbtn
            // 
            this.createbtn.BorderRadius = 10;
            this.createbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.createbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.createbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.createbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.createbtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.createbtn.Font = new System.Drawing.Font("Sans Serif Collection", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createbtn.ForeColor = System.Drawing.Color.White;
            this.createbtn.Location = new System.Drawing.Point(612, 548);
            this.createbtn.Name = "createbtn";
            this.createbtn.Size = new System.Drawing.Size(125, 41);
            this.createbtn.TabIndex = 11;
            this.createbtn.Text = "Create";
            this.createbtn.Click += new System.EventHandler(this.guna2ButtonCreate_Click_1);
            // 
            // resetbtn
            // 
            this.resetbtn.BorderRadius = 10;
            this.resetbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.resetbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.resetbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.resetbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.resetbtn.FillColor = System.Drawing.Color.Red;
            this.resetbtn.Font = new System.Drawing.Font("Sans Serif Collection", 10.2F);
            this.resetbtn.ForeColor = System.Drawing.Color.White;
            this.resetbtn.Location = new System.Drawing.Point(755, 548);
            this.resetbtn.Name = "resetbtn";
            this.resetbtn.Size = new System.Drawing.Size(125, 41);
            this.resetbtn.TabIndex = 10;
            this.resetbtn.Text = "Reset";
            this.resetbtn.Click += new System.EventHandler(this.guna2ButtonReset_Click_1);
            // 
            // guna2TextBoxPrice
            // 
            this.guna2TextBoxPrice.BorderRadius = 10;
            this.guna2TextBoxPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBoxPrice.DefaultText = "";
            this.guna2TextBoxPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBoxPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBoxPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBoxPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxPrice.Location = new System.Drawing.Point(18, 300);
            this.guna2TextBoxPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBoxPrice.Name = "guna2TextBoxPrice";
            this.guna2TextBoxPrice.PlaceholderText = "";
            this.guna2TextBoxPrice.SelectedText = "";
            this.guna2TextBoxPrice.Size = new System.Drawing.Size(518, 38);
            this.guna2TextBoxPrice.TabIndex = 6;
            this.guna2TextBoxPrice.TextChanged += new System.EventHandler(this.guna2TextBoxPrice_TextChanged);
            // 
            // guna2TextBoxName
            // 
            this.guna2TextBoxName.BorderRadius = 10;
            this.guna2TextBoxName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBoxName.DefaultText = "";
            this.guna2TextBoxName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBoxName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBoxName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBoxName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxName.Location = new System.Drawing.Point(18, 108);
            this.guna2TextBoxName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBoxName.Name = "guna2TextBoxName";
            this.guna2TextBoxName.PlaceholderText = "";
            this.guna2TextBoxName.SelectedText = "";
            this.guna2TextBoxName.Size = new System.Drawing.Size(518, 38);
            this.guna2TextBoxName.TabIndex = 4;
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Sans Serif Collection", 10.2F);
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(18, 381);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(141, 60);
            this.guna2HtmlLabel4.TabIndex = 3;
            this.guna2HtmlLabel4.Text = "Food Description:";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Sans Serif Collection", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(18, 164);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(69, 60);
            this.guna2HtmlLabel2.TabIndex = 1;
            this.guna2HtmlLabel2.Text = "Add For:";
            this.guna2HtmlLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.guna2HtmlLabel2.Click += new System.EventHandler(this.guna2HtmlLabel2_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Sans Serif Collection", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(18, 70);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(99, 60);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Item Name:";
            this.guna2HtmlLabel1.Click += new System.EventHandler(this.guna2HtmlLabel1_Click_1);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.guna2TextBoxDescription);
            this.guna2Panel3.Controls.Add(this.guna2ComboBox1);
            this.guna2Panel3.Controls.Add(this.pictureBoxItem);
            this.guna2Panel3.Controls.Add(this.btnImportImage);
            this.guna2Panel3.Controls.Add(this.createbtn);
            this.guna2Panel3.Controls.Add(this.resetbtn);
            this.guna2Panel3.Controls.Add(this.guna2TextBoxPrice);
            this.guna2Panel3.Controls.Add(this.guna2TextBoxName);
            this.guna2Panel3.Controls.Add(this.guna2HtmlLabel4);
            this.guna2Panel3.Controls.Add(this.guna2HtmlLabel3);
            this.guna2Panel3.Controls.Add(this.guna2HtmlLabel2);
            this.guna2Panel3.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel3.Font = new System.Drawing.Font("MT Extra", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.guna2Panel3.Location = new System.Drawing.Point(108, 30);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(932, 605);
            this.guna2Panel3.TabIndex = 1;
            this.guna2Panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel3_Paint);
            // 
            // guna2TextBoxDescription
            // 
            this.guna2TextBoxDescription.BorderRadius = 10;
            this.guna2TextBoxDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBoxDescription.DefaultText = "";
            this.guna2TextBoxDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBoxDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBoxDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBoxDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxDescription.Location = new System.Drawing.Point(18, 422);
            this.guna2TextBoxDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBoxDescription.Multiline = true;
            this.guna2TextBoxDescription.Name = "guna2TextBoxDescription";
            this.guna2TextBoxDescription.PlaceholderText = "";
            this.guna2TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.guna2TextBoxDescription.SelectedText = "";
            this.guna2TextBoxDescription.Size = new System.Drawing.Size(518, 101);
            this.guna2TextBoxDescription.TabIndex = 27;
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.BorderRadius = 10;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox1.ItemHeight = 30;
            this.guna2ComboBox1.Location = new System.Drawing.Point(18, 204);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(518, 36);
            this.guna2ComboBox1.TabIndex = 24;
            this.guna2ComboBox1.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Sans Serif Collection", 10.2F);
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(18, 260);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(47, 60);
            this.guna2HtmlLabel3.TabIndex = 2;
            this.guna2HtmlLabel3.Text = "Price:";
            // 
            // btnImportImage
            // 
            this.btnImportImage.BorderRadius = 10;
            this.btnImportImage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnImportImage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnImportImage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnImportImage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnImportImage.FillColor = System.Drawing.Color.MediumPurple;
            this.btnImportImage.Font = new System.Drawing.Font("Sans Serif Collection", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportImage.ForeColor = System.Drawing.Color.White;
            this.btnImportImage.Location = new System.Drawing.Point(658, 300);
            this.btnImportImage.Name = "btnImportImage";
            this.btnImportImage.Size = new System.Drawing.Size(222, 42);
            this.btnImportImage.TabIndex = 1;
            this.btnImportImage.Text = "Import";
            this.btnImportImage.Click += new System.EventHandler(this.btnImportImage_Click);
            // 
            // AddItemPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 657);
            this.Controls.Add(this.guna2Panel3);
            this.Name = "AddItemPage";
            this.Text = "AddItem";
            this.Load += new System.EventHandler(this.AddItemPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem)).EndInit();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2PictureBox pictureBoxItem;
        private Guna.UI2.WinForms.Guna2Button createbtn;
        private Guna.UI2.WinForms.Guna2Button resetbtn;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBoxPrice;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBoxName;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBoxDescription;
        private Guna.UI2.WinForms.Guna2Button btnImportImage;
    }
}
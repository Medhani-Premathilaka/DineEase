using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DineEase
{
    public partial class UserViewProducts : Form
    {
        public static string con_string = @"Data Source=DESKTOP-U1Q76M8\SQLEXPRESS; Initial Catalog=res_db; Integrated Security=True";

        public static SqlConnection con = new SqlConnection(con_string);

        public UserViewProducts()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserViewProducts_Load(object sender, EventArgs e)
        {
            AddCategory();
            productPanel.Controls.Clear();
            LoadProducts();
        }

        public void AddCategory()
        {
            string qry = "select * from Category";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            categoryPanel.Controls.Clear();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.FillColor = Color.FromArgb(128, 128, 255);
                    b.Size = new Size(134, 45);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["catName"].ToString();

                    //event for click
                    b.Click += new EventHandler(_Click);


                    categoryPanel.Controls.Add(b);
                }
            }
        }

        private void _Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;

            foreach (var item in productPanel.Controls)
            {
                var pro = (Product)item;
                pro.Visible = pro.pcategory.ToLower().Contains(b.Text.Trim().ToLower());
            }
        }

        private void LoadProducts()
        {
            string qry = "select * from products inner join category on catID = CategoryId";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                Byte[] imageArray = (byte[])item["pImage"];
                byte[] imagebytearray = imageArray;

                AddItems(
                    item["pID"].ToString(),
                    item["pName"].ToString(),
                    item["catName"].ToString(),
                    item["pPrice"].ToString(),
                    Image.FromStream(new MemoryStream(imageArray))
                );
            }
        }

        private void AddItems(string id, string name, string cat, string price, Image pimage)
        {
            var w = new Product()
            {
                pname = name,
                pprice = price,
                pcategory = cat,
                pimg = pimage,
                id = Convert.ToInt32(id),
            };

            productPanel.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wgt = (Product)ss;


                //
            };
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in productPanel.Controls)
            {
                var pro = (Product)item;
                pro.Visible = pro.pname.ToLower().Contains(txtsearch.Text.Trim().ToLower());
            }
        }
    }
}

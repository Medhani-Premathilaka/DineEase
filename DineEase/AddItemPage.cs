﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DineEase
{
    public partial class AddItemPage : Form
    {
        string connectionString = @"Data Source=DESKTOP-TAR59NP\SQLEXPRESS;Initial Catalog=dineEase;Integrated Security=True";
        public AddItemPage()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ButtonAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void guna2ButtonCreate_Click(object sender, EventArgs e)
        {
            string itemName = guna2TextBoxName.Text;
            string addFor = guna2TextBoxAddFor.Text;
            decimal price;
            string description = guna2TextBoxDescription.Text;


            if (!decimal.TryParse(guna2TextBoxPrice.Text, out price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            string query = "INSERT INTO menu (name, addFor, price, description) VALUES (@itemName, @addFor, @price, @description)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@itemName", itemName);
                    cmd.Parameters.AddWithValue("@addFor", addFor);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@description", description);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Menu item added successfully.");

                            //// Show read form and load updated data
                            //read readForm = new read();
                            //readForm.Show();
                            //readForm.LoadMenuData(); // Call method to populate the grid
                        }
                        else
                        {
                            MessageBox.Show("No rows inserted.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void guna2ButtonReset_Click(object sender, EventArgs e)
        {
            guna2TextBoxName.Clear();
            guna2TextBoxAddFor.Clear();
            guna2TextBoxPrice.Clear();
            guna2TextBoxDescription.Clear();

        }
    }
}


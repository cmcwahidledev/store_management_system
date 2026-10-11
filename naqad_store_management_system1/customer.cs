using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace naqad_store_management_system1
{
    public partial class customer : Form
    {

        public customer()
        {
            InitializeComponent();
        }

        public customer(string username, string role)
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new product().Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new dashboard().Show();
        }

        void cust()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Customers ", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-K1FL43D;Integrated Security=SSPI;Initial Catalog=NaqadStoreDB;Integrated Security=true");

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Customers(fullname, phone, email, Address) VALUES (@name, @phone, @email, @add)", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@add", txtaddress.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Customers saved success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cust();
                txtname.Clear();
                txtphone.Clear();
                txtemail.Clear();
                txtaddress.Clear();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void customer_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cust();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cust();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


                SqlCommand cmd = new SqlCommand("update Customers set fullname=@name ,phone=@phone,email=@email, Address=@add where id=@ID", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@add", txtaddress.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Customers success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                cust();
                txtname.Clear();
                txtphone.Clear();
                txtemail.Clear();
                txtaddress.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Customers where id='" + txtsearch.Text + "'", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


            SqlCommand cmd = new SqlCommand("delete from Customers where id=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete Customers success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            cust();
        }

        private void label11_Click(object sender, EventArgs e)
        {
       
        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
            new employee().Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
            new sales().Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Hide();
            new payment().Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new dashboard().Show();
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Supplier().Show();
        }

        private void label11_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new product().Show();
        }

        private void label15_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new employee().Show();
        }

        private void label17_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new sales().Show();
        }

        private void label19_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new payment().Show();
        }

        private void label28_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }
    }
}

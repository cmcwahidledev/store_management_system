using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using System.Xml.Linq;

namespace naqad_store_management_system1
{
    public partial class sales : Form
    {
        public sales()
        {
            InitializeComponent();
        }

        public sales(string username, string role)
        {
            InitializeComponent();
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

        private void label11_Click(object sender, EventArgs e)
        {
           
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new customer().Show();
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

        void sls()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Sales ", conn);

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
                SqlCommand cmd = new SqlCommand("INSERT INTO Sales(CustomerID, productID, price, quantity, total) VALUES (@cid, @pid, @pr, @quan, @total)", conn);

                cmd.Parameters.AddWithValue("@cid", txtcid.Text);
                cmd.Parameters.AddWithValue("@pid", txtpid.Text);
                cmd.Parameters.AddWithValue("@pr", txtprice.Text);
                cmd.Parameters.AddWithValue("@quan", txtquan.Text);
                cmd.Parameters.AddWithValue("@total", txttotal.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Sales saved success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sls();
                txtcid.Clear();
                txtpid.Clear();
                txtprice.Clear();
                txtquan.Clear();
                txttotal.Clear();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void salary_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            sls();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sls();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Sales where id='" + txtsearch.Text + "'", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


            SqlCommand cmd = new SqlCommand("delete from Sales where id=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete Sales success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            sls();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Hide();
            new payment().Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


                SqlCommand cmd = new SqlCommand("update Sales set CustomerID=@cid, productID=@pid, price=@pr, quantity=@quan, total=@total where id=@ID", conn);

                cmd.Parameters.AddWithValue("@cid", txtcid.Text);
                cmd.Parameters.AddWithValue("@pid", txtpid.Text);
                cmd.Parameters.AddWithValue("@pr", txtprice.Text);
                cmd.Parameters.AddWithValue("@quan", txtquan.Text);
                cmd.Parameters.AddWithValue("@total", txttotal.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Sales success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                sls();
                txtcid.Clear();
                txtpid.Clear();
                txtprice.Clear();
                txtquan.Clear();
                txttotal.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private void label19_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new payment().Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
            new employee().Show();
        }

        private void label13_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new customer().Show();
        }

        private void label11_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new product().Show();
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Supplier().Show();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new dashboard().Show();
        }
    }
}

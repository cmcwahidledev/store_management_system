using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace naqad_store_management_system1
{
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
        }

        public payment(string username, string role)
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
            new sales().Show();
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

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private void report_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            sld();
            txtpy.SelectedIndex = 0;

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void comSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
     
        }

        void sld()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from payment ", conn);

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
                SqlCommand cmd = new SqlCommand("INSERT INTO payment(saleID, customerID, productID, total, discount, subtotal, paymentMethod) VALUES (@sid, @cid, @pid, @total, @dis, @sub, @py)", conn);

                cmd.Parameters.AddWithValue("@sid", txtsid.Text);
                cmd.Parameters.AddWithValue("@cid", txtcid.Text);
                cmd.Parameters.AddWithValue("@pid", txtpid.Text);
                cmd.Parameters.AddWithValue("@total", txttotal.Text);
                cmd.Parameters.AddWithValue("@dis", txtdis.Text);
                cmd.Parameters.AddWithValue("@sub", txtsub.Text);
                cmd.Parameters.AddWithValue("@py", txtpy.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("payment saved success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sld();
                txtsid.Clear();
                txtcid.Clear();
                txtpid.Clear();
                txttotal.Clear();
                txtdis.Clear();
                txtsub.Clear();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


                SqlCommand cmd = new SqlCommand("update payment set saleID=@sid ,customerID=@cid,productID=@pid, total=@total, discount=@dis, subtotal=@sub, paymentMethod=@py where id=@ID", conn);
                cmd.Parameters.AddWithValue("@sid", txtsid.Text);
                cmd.Parameters.AddWithValue("@cid", txtcid.Text);
                cmd.Parameters.AddWithValue("@pid", txtpid.Text);
                cmd.Parameters.AddWithValue("@total", txttotal.Text);
                cmd.Parameters.AddWithValue("@dis", txtdis.Text);
                cmd.Parameters.AddWithValue("@sub", txtsub.Text);
                cmd.Parameters.AddWithValue("@py", txtpy.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update payment success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                sld();
                txtsid.Clear();
                txtcid.Clear();
                txtpid.Clear();
                txttotal.Clear();
                txtdis.Clear();
                txtsub.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


            SqlCommand cmd = new SqlCommand("delete from payment where id=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete payment success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            sld();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from payment where id='" + txtsearch.Text + "'", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label28_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Hide();
            new sales().Show();
        }

        private void label15_Click_1(object sender, EventArgs e)
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

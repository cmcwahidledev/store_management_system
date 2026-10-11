using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using System.Xml.Linq;

namespace naqad_store_management_system1
{
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }

        public Supplier(string username, string role)
        {
            InitializeComponent();
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

        private void room_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inv();
        }

        void inv()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from supplier ", conn);

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
                SqlCommand cmd = new SqlCommand("INSERT INTO supplier(supplier_name, phone, address) VALUES (@name, @ph, @add)", conn);

                cmd.Parameters.AddWithValue("@name", txtsupp.Text);
                cmd.Parameters.AddWithValue("@ph", txtph.Text);
                cmd.Parameters.AddWithValue("@add", txtadd.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("supplier saved success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                inv();
                txtsupp.Clear();
                txtph.Clear();
                txtadd.Clear();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from supplier where id='" + txtsearch.Text + "'", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


            SqlCommand cmd = new SqlCommand("delete from supplier where id=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete supplier success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            inv();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            inv();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


                SqlCommand cmd = new SqlCommand("update supplier set supplier_name=@name ,phone=@ph,address=@add where id=@ID", conn);

                cmd.Parameters.AddWithValue("@name", txtsupp.Text);
                cmd.Parameters.AddWithValue("@ph", txtph.Text);
                cmd.Parameters.AddWithValue("@add", txtadd.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update supplier success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                inv();
                txtsupp.Clear();
                txtph.Clear();
                txtadd.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void label3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new dashboard().Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
            new product().Show();
        }

        private void label13_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new customer().Show();
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

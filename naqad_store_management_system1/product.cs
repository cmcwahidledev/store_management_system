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
    public partial class product : Form
    {
        public product()
        {
            InitializeComponent();
        }

        public product(string username, string role)
        {
            InitializeComponent();
        }
        private void panel2_Paint(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labe31_Click(object sender, EventArgs e)
        {
            this.Hide();
            new dashboard().Show();
        }

        private void reservation_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pro();
            cat();
        }

        void pro()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Products ", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void cat()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from category ", conn);

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
                SqlCommand cmd = new SqlCommand("INSERT INTO Products(ProductName, Category_id, supplier_id, Price, Quantity) VALUES (@name, @cate, @supp, @price, @quan)", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@cate", txtcato.Text);
                cmd.Parameters.AddWithValue("@supp", txtsupp.Text);
                cmd.Parameters.AddWithValue("@price", txtprice.Text);
                cmd.Parameters.AddWithValue("@quan", txtquan.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("product saved success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pro();
                txtname.Clear();
                txtcato.Clear();
                txtprice.Clear();
                txtquan.Clear();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pro();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Products where id='" + txtsearch.Text + "'", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


            SqlCommand cmd = new SqlCommand("delete from Products where id=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete Products success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            pro();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


                SqlCommand cmd = new SqlCommand("update Products set ProductName=@name ,Category_id=@cate, supplier_id=@supp, Price=@price, Quantity=@quan where id=@ID", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@cate", txtcato.Text);
                cmd.Parameters.AddWithValue("@supp", txtsupp.Text);
                cmd.Parameters.AddWithValue("@price", txtprice.Text);
                cmd.Parameters.AddWithValue("@quan", txtquan.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Products success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                pro();

                txtname.Clear();
                txtcato.Clear();
                txtprice.Clear();
                txtquan.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new customer().Show();
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

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO category(category_name) VALUES (@cname)", conn);

                cmd.Parameters.AddWithValue("@cname", txtcname.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("category saved success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cat();
                txtcname.Clear();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


                SqlCommand cmd = new SqlCommand("update category set category_name=@cname where id=@ID", conn);

                cmd.Parameters.AddWithValue("@cname", txtname.Text);
                cmd.Parameters.AddWithValue("@ID", id);
               

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update category success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                cat();

                txtcname.Clear();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


            SqlCommand cmd = new SqlCommand("delete from category where id=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete category success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            cat();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cat();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from category where id='" + search.Text + "'", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new dashboard().Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Supplier().Show();
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

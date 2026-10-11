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

namespace naqad_store_management_system1
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        public dashboard(string username, string role)
        {
            InitializeComponent();
        }

        private void guna2GradientPanel12_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void dashboard_Load(object sender, EventArgs e)
        {
            pro();
            cust();
            inv();
            emp();
            sls();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-K1FL43D;Integrated Security=SSPI;Initial Catalog=NaqadStoreDB;Integrated Security=true");

        void sls()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from  Sales", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void pro()
        {
          SqlCommand cmd = new SqlCommand("select count(*) from Products", conn);
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                lblp.Text = result.ToString();
            }
            else
            {
                lblp.Text = "0";
            }
            conn.Close();
        }


        private void cust()
        {
            SqlCommand cmd = new SqlCommand("select count(*)from Customers", conn);
            conn.Open();
            object resu = cmd.ExecuteScalar();
            if (resu != DBNull.Value)
            {
                lblcust.Text = resu.ToString();
            }
            else
            {
                lblcust.Text = "0";
            }
            conn.Close();
        }


        private void inv()
        {
            SqlCommand cmd = new SqlCommand("select count(*)from Inventory", conn);
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                lblin.Text = result.ToString();
            }
            else
            {
                lblin.Text = "0";
            }
            conn.Close();
        }


        private void emp()
        {
            SqlCommand cmd = new SqlCommand("select count(*)from employee", conn);
            conn.Open();
            object resu = cmd.ExecuteScalar();
            if (resu != DBNull.Value)
            {
                lblemp.Text = resu.ToString();
            }
            else
            {
                lblemp.Text = "0";
            }
            conn.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Supplier().Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new payment().Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
            new product().Show();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();
            new payment().Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
            new customer().Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
            new employee().Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Hide();
            new sales().Show();
        }

        private void label28_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }
    }

}

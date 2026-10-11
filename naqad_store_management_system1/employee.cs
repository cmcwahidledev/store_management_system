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
using System.Windows.Forms;

namespace naqad_store_management_system1
{
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }

        public employee(string username, string role)
        {
            InitializeComponent();
        }

        private void employee_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            emp();
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

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
            new sales().Show();
        }


        void emp()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from employee ", conn);

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
                SqlCommand cmd = new SqlCommand("insert into employee(fullname, position, phone, email, salary) values(@name, @pos, @ph, @em, @sal)", conn);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@pos", compos.Text);
                cmd.Parameters.AddWithValue("@ph", txtphone.Text);
                cmd.Parameters.AddWithValue("@em", txtemail.Text);
                cmd.Parameters.AddWithValue("@sal", txtsal.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("employe saved successfully", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                emp();
                conn.Close();

                txtname.Clear();
                txtemail.Clear();
                txtphone.Clear();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            emp();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

                SqlCommand cmd = new SqlCommand("update employee set fullname=@name , position=@pos , phone=@ph , email=@em, salary=@sal where id=@ID", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@pos", compos.Text);
                cmd.Parameters.AddWithValue("@ph", txtphone.Text);
                cmd.Parameters.AddWithValue("@em", txtemail.Text);
                cmd.Parameters.AddWithValue("@sal", txtsal.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update employee success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                emp();

                txtname.Clear();
                txtemail.Clear();
                txtphone.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


            SqlCommand cmd = new SqlCommand("delete from employee where id=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete employee success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            emp();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from employee where id='" + txtsearch.Text + "'", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Hide();
            new payment().Show();
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

        private void label17_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new sales().Show();
        }

        private void label13_Click(object sender, EventArgs e)
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Retry_Project
{
    public partial class Dashboard : Form

    {
        private bool isNew = false;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
       
            
            private DataTable LoadDatabase(string query)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EOU08BL\SQLEXPRESS;Initial Catalog=medicare;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

 

            DataTable dt = ds.Tables[0];
            return dt;

 


        }




        private void Dashboard_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EOU08BL\SQLEXPRESS;Initial Catalog=medicare;Integrated Security=True");
            con.Open();
            string query = "SELECT * FROM medicines";
            DataTable dt = LoadDatabase(query);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int mid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EOU08BL\SQLEXPRESS;Initial Catalog=medicare;Integrated Security=True");
                con.Open();
                string query = "SELECT * from MEDICINES WHERE mid=" + mid;
                DataTable dt = LoadDatabase(query);
                textBox4.Text = dt.Rows[0]["mid"].ToString();
                textBox1.Text = dt.Rows[0]["name"].ToString();
                textBox2.Text = dt.Rows[0]["type"].ToString();
                textBox3.Text = dt.Rows[0]["price"].ToString();
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name, type,price;
            

            name = textBox1.Text;
            type = textBox2.Text;
            price = textBox3.Text;

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EOU08BL\SQLEXPRESS;Initial Catalog=medicare;Integrated Security=True");
            conn.Open();
            string query;
            if (isNew == true)
            {
                query = "Insert into medicines(name,type,price) VALUES('" + name + "','" +type  + "','" + price + "')";



                isNew = false;
            }
            else
            {
                int mid=Convert.ToInt32(textBox4.Text);
                query = "update medicines set name= '" + name + "', type= '" + type + "',price ='" + price + "' where mid =" + mid;

            }

            SqlCommand cmd = new SqlCommand(query, conn);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("update successfull");
                query = "select * from medicines";
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            conn.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = " ";
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            isNew = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int mid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EOU08BL\SQLEXPRESS;Initial Catalog=medicare;Integrated Security=True");
                con.Open();
                string query = "SELECT * from MEDICINES WHERE mid=" + mid;
                DataTable dt = LoadDatabase(query);
                textBox4.Text = dt.Rows[0]["mid"].ToString();
                textBox1.Text = dt.Rows[0]["name"].ToString();
                textBox2.Text = dt.Rows[0]["type"].ToString();
                textBox3.Text = dt.Rows[0]["price"].ToString();
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EOU08BL\SQLEXPRESS;Initial Catalog=medicare;Integrated Security=True");
            conn.Open();
            string query;
            int mid = Convert.ToInt32(textBox4.Text);
            query = "Delete from medicines where mid =" + mid;



            SqlCommand cmd = new SqlCommand(query, conn);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("operation successfull");
                query = "select * from medicines";
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();

                textBox4.Text = " ";
                textBox1.Text = " ";
                textBox3.Text = " ";
                textBox2.Text = " ";
            }
            conn.Close();
        }

        private void sellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sell s1 = new Sell();
            s1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EOU08BL\SQLEXPRESS;Initial Catalog=medicare;Integrated Security=True");
         
            string query = "SELECT * FROM medicines WHERE mid='" + textBox5.Text + "'";
            DataTable dt = new DataTable();

            conn.Open();

            SqlDataAdapter dtaAdapter = new SqlDataAdapter(query, conn);
            dtaAdapter.Fill(dt);

            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EOU08BL\SQLEXPRESS;Initial Catalog=medicare;Integrated Security=True");
            string query = "SELECT * FROM medicines";
            DataTable dt = new DataTable();

            conn.Open();

            SqlDataAdapter dtaAdapter = new SqlDataAdapter(query, conn);
            dtaAdapter.Fill(dt);

            dataGridView1.DataSource = dt;

            conn.Close();
        }
    }
}

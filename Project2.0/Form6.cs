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

namespace Project2._0
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ankit\OneDrive\Documents\Gadgetrentaldb.mdf;Integrated Security = True; Connect Timeout = 30");
        private void populate()
        {
            Con.Open();
            string query = "select * from customertbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            customerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 main = new Form3();
            main.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            populate();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (custiditb.Text == "" || custnametb.Text == "" || custaddtb.Text == "" || phonetb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into customertbl values(" + custiditb.Text + ",'" + custnametb.Text + "','" + custaddtb.Text + "','" + phonetb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Added");
                    Con.Close();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (custiditb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from customertbl where custid='" + custiditb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (custiditb.Text == "" || custnametb.Text == "" || custaddtb.Text == "" || phonetb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update customertbl set custname='" + custnametb.Text + "',custadd='" + custaddtb.Text + "',phone='" + phonetb.Text+ "' where custid=" + custiditb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Updated");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 main = new Form3();
            main.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void customerDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            customerDGV.CurrentRow.Selected = true;


            custiditb.Text = customerDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            custnametb.Text = customerDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            custaddtb.Text = customerDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            phonetb.Text = customerDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}

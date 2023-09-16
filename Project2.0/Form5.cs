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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ankit\OneDrive\Documents\Gadgetrentaldb.mdf;Integrated Security = True; Connect Timeout = 30");
        private void populate()
        {
            Con.Open();
            string query = "select * from pctbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            pcDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (imeitb.Text == "" || pricetb.Text == "" || brandtb.Text == "" || ostb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into pctbl values(" + imeitb.Text + ",'" + brandtb.Text + "','" + ostb.Text + "','" + availcb.SelectedItem.ToString() + "'," + pricetb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PC Successfully Added");
                    Con.Close();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
        
        private void Form5_Load(object sender, EventArgs e)
        {
            populate();
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (imeitb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from pctbl where Imei='" + imeitb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PC Deleted Successfully");
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
            if (imeitb.Text == "" || pricetb.Text == "" || brandtb.Text == "" || ostb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update pctbl set brand='" + pricetb.Text + "',os='" + brandtb.Text + "',availabel='"+availcb.SelectedItem.ToString()+"',price="+ostb.Text+"where imei='" + imeitb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PC Successfully Updated");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 main = new Form3();
            main.Show();
        }

        private void pcDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pcDGV.CurrentRow.Selected = true;


            imeitb.Text = pcDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            brandtb.Text = pcDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            ostb.Text = pcDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            availcb.SelectedItem=pcDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
            pricetb.Text = pcDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}

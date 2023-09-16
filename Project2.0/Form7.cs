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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ankit\OneDrive\Documents\Gadgetrentaldb.mdf;Integrated Security = True; Connect Timeout = 30");
        

        private void fillcustomer()
        {
            Con.Open();
            string query = "select custid from customertbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("custid", typeof(string));
            dt.Load(rdr);
            custcb.ValueMember = "custid";
            custcb.DataSource = dt;
            Con.Close();
        }
        private void Fillcombo()
        {
            Con.Open();
            string query = "select imei from pctbl where availabel ='" + "YES" + "' ";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("imei", typeof(string));
            dt.Load(rdr);
            pcreg.ValueMember = "imei";
            pcreg.DataSource = dt;
            Con.Close();
        }
        private void fetchcustname()
        {
            Con.Open();
            string query = "select * from customertbl where custid =" + custcb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                custnmtb.Text = dr["custname"].ToString();
            }
            Con.Close();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from rentaltbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            rentDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void updateonrent()
        {
            Con.Open();
            string query = "update pctbl set Available='" + "NO" + "' where Imei='" +pcreg.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("PC Successfully Updated");
            Con.Close();
        }
        private void updateonrentDelete()
        {
            Con.Open();
            string query = "update pctbl set Available='" + "YES" + "' where Imei='" + pcreg.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("PC Successfully Updated");
            Con.Close();
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            
            fillcustomer();
            populate();
            Fillcombo();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pcreg_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchcustname();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (custiditb.Text == "" || custnmtb.Text == "" || rentfee.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into rentaltbl values(" + custiditb.Text + ",'" + pcreg.SelectedValue.ToString() + "','" + custnmtb.Text + "','" +this.dateTimePicker1.Text + "','"+ this.dateTimePicker2.Text + "',"+rentfee.Text+")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PC Successfully Rented");
                    Con.Close();
                    updateonrent();
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
                    string query = "delete from rentaltbl where rentid=" + custiditb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rental Deleted Successfully");
                    Con.Close();
                    populate();
                    updateonrentDelete();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
    }
}

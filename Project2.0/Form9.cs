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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ankit\OneDrive\Documents\Gadgetrentaldb.mdf;Integrated Security = True; Connect Timeout = 30");

        private void Form9_Load(object sender, EventArgs e)
        {
            string querypc = "select Count(*) from pctbl";
            SqlDataAdapter sda = new SqlDataAdapter(querypc,Con);
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            pclbl.Text = dt.Rows[0][0].ToString();

            string querycust = "select Count(*) from customertbl";
            SqlDataAdapter sda1 = new SqlDataAdapter(querycust, Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            custlbl.Text = dt1.Rows[0][0].ToString();

            string queryuser = "select Count(*) from Usertbl";
            SqlDataAdapter sda2 = new SqlDataAdapter(queryuser, Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            userlbl.Text = dt2.Rows[0][0].ToString();
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
    }
}

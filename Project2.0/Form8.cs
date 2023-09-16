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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ankit\OneDrive\Documents\Gadgetrentaldb.mdf;Integrated Security = True; Connect Timeout = 30");
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
        private void populateRet()
        {
            Con.Open();
            string query = "select * from returntbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            returnDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void DeleteonReturn()
        {
            int rentid;
            rentid= Convert.ToInt32(rentDGV.Rows[0].Cells[0].Value.ToString());
            Con.Open();
            string query = "delete from rentaltbl where rentid=" + custiditb.Text + ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Rental Deleted Successfully");
            Con.Close();
            populate();
           // updateonrentDelete();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            populate();
            populateRet();
        }

        private void rentDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rentDGV.CurrentRow.Selected = true;


            pcidtb.Text=rentDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            custnmtb.Text=rentDGV.Rows[e.RowIndex ].Cells[2].Value.ToString();
            dateTimePicker2.Text=rentDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
            DateTime d1 = dateTimePicker2.Value.Date;
            DateTime d2 = DateTime.Now; 
            TimeSpan t=d2 - d1;
            int noOfdays=Convert.ToInt32(t.TotalDays);
            if (noOfdays <= 2)
            {
                delay.Text = "No Delay";
                finetb.Text = "0";
            }
            else if(noOfdays>2 && noOfdays<7 )
            {
                delay.Text = "" + noOfdays;
                finetb.Text = "" + (noOfdays * 60);
            }
            else
            {
                delay.Text = "" + noOfdays;
                finetb.Text = "" + (noOfdays * 90);
            }


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

        private void button1_Click(object sender, EventArgs e)
        {
            if (custiditb.Text == "" || custnmtb.Text == "" || finetb.Text=="" || delay.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into returntbl values(" + custiditb.Text + ",'" + pcidtb.Text + "','" + custnmtb.Text + "','" + this.dateTimePicker2.Text + "','" + delay.Text + "','" + finetb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PC Dully Returned");
                    Con.Close();
                   // updateonrent();
                    populateRet();
                    DeleteonReturn();

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
                    string query = "delete from returntbl where returnid=" + custiditb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Return Deleted Successfully");
                    Con.Close();
                    populate();
                    DeleteonReturn();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
    }
}

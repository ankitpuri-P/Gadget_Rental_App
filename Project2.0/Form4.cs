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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ankit\OneDrive\Documents\Gadgetrentaldb.mdf;Integrated Security = True; Connect Timeout = 30");
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from Usertbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder=new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            UserDGV.DataSource=ds.Tables[0]; 
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(Uid.Text=="" || Uname.Text==""|| Upass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Usertbl values(" + Uid.Text + ",'" + Uname.Text + "','" + Upass.Text + "')";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Added");
                    Con.Close();
                    populate();
                }
                catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from Usertbl where ID=" + Uid.Text + ";";
                    SqlCommand cmd= new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery ();
                    MessageBox.Show("User Deleted Successfully");
                    Con.Close();
                    populate ();
                }catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "" || Uname.Text == "" || Upass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update Usertbl set Uname='"+Uname.Text+"',Upass='"+Upass.Text+"'where Id="+Uid.Text+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Updated");
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
            Form3 main=new Form3();
            main.Show();
        }

        private void UserDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UserDGV.CurrentRow.Selected = true;


            Uid.Text = UserDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            Uname.Text = UserDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            Upass.Text = UserDGV.Rows[e.RowIndex].Cells[2].Value.ToString();

        }
    }
}

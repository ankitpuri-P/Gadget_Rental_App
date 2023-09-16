using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2._0
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 pc = new Form5();
            pc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 customer = new Form6();
            customer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 hi = new Form7();
            hi.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 retur = new Form8();
            retur.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 users = new Form4();
            users.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 db = new Form9();
            db.Show();
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 ss =new Form2();
            ss.Show();
        }
    }
}

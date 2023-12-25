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

namespace newresto
{
    
    public partial class main : Form
    {
        public string addmin;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6NVC0CS;Initial Catalog=restaurant;Integrated Security=True");
        public main()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addmin = label2.Text;
            if (addmin == "daxit"|| addmin == "neel"|| addmin == "yash")
            {
                customer c1 = new customer();
                this.Hide();
                c1.Show();
            }
            else
            {
                MessageBox.Show("not access");
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addmin = label2.Text;
            if (addmin == "daxit" || addmin == "neel" || addmin == "yash")
            {
                foodmenu c1 = new foodmenu();
                this.Hide();
                c1.Show();
            }
            else
            {
                MessageBox.Show("not access");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            addmin = label2.Text;
            if (addmin == "daxit" || addmin == "neel" || addmin == "yash")
            {
                Form1 f1=new Form1();
            this.Hide();
            f1.Show();
            }
            else
            {
                MessageBox.Show("not access");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addmin = label2.Text;
            if (addmin == "daxit" || addmin == "neel" || addmin == "yash")
            {
            table t1=new table();
            this.Hide();
            t1.Show();
            }
            else
            {
                MessageBox.Show("not access");
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.passname;
        }

        private void button5_Click(object sender, EventArgs e)
        {
                    addmin = label2.Text;
                    if (addmin == "daxit" || addmin == "neel" || addmin == "yash")
                    {
                        order o1 = new order();
                        this.Hide();
                         o1.Show();
                    }
            else
            {
                MessageBox.Show("not access");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addmin = label2.Text;
            if (addmin == "daxit" || addmin == "neel" || addmin == "yash")
            {

            bill b1 = new bill();
            this.Hide();
            b1.Show();
            }
            else
            {
                MessageBox.Show("not access");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addmin = label2.Text;
            if ( addmin == "yash")
            {

                satff s1 = new satff();
            this.Hide();
            s1.Show();
            }
            else
            {
                MessageBox.Show("not access");
            }
        }
    }
}

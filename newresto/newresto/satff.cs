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
    public partial class satff : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6NVC0CS;Initial Catalog=restaurant;Integrated Security=True");
        public satff()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "insert into staff values('"+textBox2.Text+"','"+textBox4.Text+"','"+textBox3.Text+"')";
            cmd1.ExecuteNonQuery();
            con.Close();
            diply_data();
            CleraTextBoxes();


            MessageBox.Show("Record Inserted Succesfully");
        }
        public void diply_data()
        {
            con.Close();

            SqlDataAdapter da1 = new SqlDataAdapter();
            DataTable bt1 = new DataTable();



            da1 = new SqlDataAdapter("SELECT * FROM staff", con);


            //cmd.ExecuteNonQuery();

            con.Open();
            da1.Fill(bt1);

            gunaDataGridView1.DataSource = bt1;

            con.Close();

        }

        private void CleraTextBoxes()
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };
            func(Controls);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update staff set sname = '" + textBox2.Text+ "' where id='"+textBox5.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            diply_data();

            CleraTextBoxes();

            MessageBox.Show("Record update Succesfully");
        }

        private void satff_Load(object sender, EventArgs e)
        {
            diply_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from staff where id = '" + textBox5.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            diply_data();

            CleraTextBoxes();

            MessageBox.Show("Record delete Succesfully");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            main m1 = new main();
            this.Hide();
            m1.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            con.Close();
            SqlDataAdapter da = new SqlDataAdapter("select * from staff where sname='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);

            gunaDataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

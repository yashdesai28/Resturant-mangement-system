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
    public partial class foodmenu : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6NVC0CS;Initial Catalog=restaurant;Integrated Security=True");
        public foodmenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Visible = true;
            textBox5.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label8.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "insert into foodmenu1(foodname,Category,price,status)values('" + textBox5.Text.ToString() + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox2.SelectedItem.ToString() + "')";
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



            da1 = new SqlDataAdapter("SELECT * FROM foodmenu1", con);


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
             cmd.CommandText = "update foodmenu1 set foodname = '" + textBox5.Text.ToString() + "' , price = '" + textBox3.Text.ToString() + "' where id = '" + textBox2.Text.ToString()+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            diply_data();

            CleraTextBoxes();

            MessageBox.Show("Record update Succesfully");
        }

        private void foodmenu_Load(object sender, EventArgs e)
        {
            diply_data();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from foodmenu1 where id = '" + textBox2.Text.ToString() + "'";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Visible = true;
            textBox5.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label8.Visible = true;

            gunaDataGridView1.CurrentRow.Selected = true;
            textBox2.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            textBox5.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["foodname"].Value.ToString();
            textBox3.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

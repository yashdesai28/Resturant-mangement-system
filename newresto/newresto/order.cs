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
    public partial class order : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6NVC0CS;Initial Catalog=restaurant;Integrated Security=True");
    
        public order()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int total,qu,price;

            qu = Convert.ToInt32(numericUpDown1.Value);
            
            price = Convert.ToInt32(textBox3.Text);
            total = qu * price;


            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "insert into ordersp(id,item,price,quantity,table1,total12,sname)values('"+textBox5.Text+"','" + comboBox2.SelectedValue.ToString() + "','" + textBox3.Text.ToString() + "','"+numericUpDown1.Value.ToString()+"','" + comboBox1.SelectedValue.ToString() + "','"+total+"','"+comboBox3.Text+"')";
            cmd1.ExecuteNonQuery();
            cmd1.CommandText = "insert into ordersp1(id,item,price,quantity,table1,total,sname)values('" + textBox5.Text + "','" + comboBox2.SelectedValue.ToString() + "','" + textBox3.Text.ToString() + "','" + numericUpDown1.Value.ToString() + "','" + comboBox1.SelectedValue.ToString() + "','" + total + "','" + comboBox3.Text + "')";
            cmd1.ExecuteNonQuery();
            con.Close();
            diply_data();
            CleraTextBoxes();


            MessageBox.Show("Record Inserted Succesfully");
        }

        void items()
        {
            string s1 = "select * from foodmenu1";
            SqlCommand cmd = new SqlCommand(s1, con);
            SqlDataReader rdr;

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("foodname",typeof(string));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                comboBox2.ValueMember = "foodname";
                comboBox2.DataSource = dt;
                con.Close();

            }
            catch
            {

            }
        }

        private void order_Load(object sender, EventArgs e)
        {
            items();
            diply_data();
            table();
            byding();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            textBox3.ReadOnly=false;  

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from foodmenu1 where foodname='" + comboBox2.Text.ToString() + "'", con);
                cmd.Parameters.AddWithValue("foodname", comboBox2.SelectedItem.ToString());
                SqlDataReader dr;
                dr = cmd.ExecuteReader();



                if (dr.Read())
                {
                   textBox3.Text=dr["price"].ToString();
                }
                
                con.Close();
            }

            catch
            {

            }
        }

        public void diply_data()
        {
            con.Close();

            SqlDataAdapter da1 = new SqlDataAdapter();
            DataTable bt1 = new DataTable();



            da1 = new SqlDataAdapter("SELECT * FROM ordersp", con);


            //cmd.ExecuteNonQuery();

            con.Open();
            da1.Fill(bt1);
          
            gunaDataGridView1.DataSource= bt1;

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

        private void button5_Click(object sender, EventArgs e)
        {
            con.Close();

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable bt = new DataTable();



            da = new SqlDataAdapter("SELECT * FROM ordersp1", con);


            //cmd.ExecuteNonQuery();

            con.Open();
            da.Fill(bt);
            gunaDataGridView1.DataSource = bt;

            con.Close();

        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            main m1 = new main();
            this.Hide();
            m1.Show();
        }

        void table()
        {
            string s1 = "select * from tablecustomer";
            SqlCommand cmd = new SqlCommand(s1, con);
            SqlDataReader rdr;

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("table1", typeof(string));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                comboBox1.ValueMember = "table1";
                comboBox1.DataSource = dt;
                con.Close();

            }
            catch
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from ordersp where id = '" + textBox5.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from ordersp1 where id = '" + textBox5.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            diply_data();

            CleraTextBoxes();

            MessageBox.Show("Record delete Succesfully");
        }

        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            gunaDataGridView1.CurrentRow.Selected = true;
            textBox5.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            comboBox2.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["item"].Value.ToString();
            textBox3.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString();
           // numericUpDown1.Value = gunaDataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            comboBox1.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["table1"].Value.ToString();
            comboBox3.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["sname"].Value.ToString();


        }

        void byding()
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from staff", con);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();

            comboBox3.DisplayMember = "sname";
            comboBox3.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int total, qu, price;

            qu = Convert.ToInt32(numericUpDown1.Value);

            price = Convert.ToInt32(textBox3.Text);
            total = qu * price;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update ordersp set item = '" + comboBox2.Text + "' , price = '" + textBox3.Text.ToString() + "', table1 ='" + comboBox1.Text + "',sname='" + comboBox3.Text + "',total12='"+total+"',quantity='"+numericUpDown1.Value+"' where id = '" + textBox5.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "update ordersp1 set item = '" + comboBox2.Text + "' , price = '" + textBox3.Text.ToString() + "', table1 ='" + comboBox1.Text + "',sname='" + comboBox3.Text + "',total='"+total+ "',quantity='" + numericUpDown1.Value + "' where id = '" + textBox5.Text.ToString() + "'";

            cmd.ExecuteNonQuery();
            con.Close();
            diply_data();

            CleraTextBoxes();

            MessageBox.Show("Record update Succesfully");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter("select * from ordersp1 where sname='" + textBox1.Text + "'", con);
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
    }
}

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

    public partial class customer : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6NVC0CS;Initial Catalog=restaurant;Integrated Security=True");
        SqlDataReader dr;
        public customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox5.Visible = true;
            label8.Visible = true;

            diply_data();

           

            CleraTextBoxes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

          

           con.Open();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into tablecustomer(id,name,phone,address,table1,date1)values('"+textBox5.Text+"','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox1.SelectedValue.ToString() + "','" + dateTimePicker1.Text + "')";
            
            cmd1.ExecuteNonQuery();
            cmd1.CommandText = "insert into customer1(id,name,phone,address,table1,date1)values('" + textBox5.Text + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox1.SelectedValue.ToString() + "','" + dateTimePicker1.Text + "')";
            cmd1.ExecuteNonQuery();
            con.Close();
                diply_data();

                CleraTextBoxes();


                MessageBox.Show("Record Inserted Succesfully");

            


        }

        public void diply_data()
        {
            con.Close();

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable bt = new DataTable();


           
            da = new SqlDataAdapter("SELECT * FROM tablecustomer", con);


            //cmd.ExecuteNonQuery();

            con.Open();
            da.Fill(bt);
            gunaDataGridView1.DataSource = bt;
            
            con.Close();

        }

        private void customer_Load(object sender, EventArgs e)
        {
            diply_data();
            table();
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd=con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from tablecustomer where id = '" + textBox5.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from customer1 where id = '" + textBox5.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            diply_data();

            CleraTextBoxes();

            MessageBox.Show("Record delete Succesfully");

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update tablecustomer set name = '"+textBox2.Text.ToString()+"' , phone = '"+textBox3.Text.ToString()+"', address ='"+textBox4.Text.ToString()+"',table1='"+comboBox1.SelectedValue+"',date1='"+dateTimePicker1.Text+"' where id = '" + textBox5.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "update customer1 set name = '" + textBox2.Text.ToString() + "' , phone = '" + textBox3.Text.ToString() + "', address ='" + textBox4.Text.ToString() + "',table1='" + comboBox1.SelectedValue + "',date1='" + dateTimePicker1.Text + "' where id = '" + textBox5.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            diply_data();

            CleraTextBoxes();

            MessageBox.Show("Record update Succesfully");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            main m1=new main();
            this.Hide();
            m1.Show();
        }

        void table()
        {
            string s1 = "select * from Table1";
            SqlCommand cmd= new SqlCommand(s1,con);
            SqlDataReader rdr;

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("tablenumber");
                rdr=cmd.ExecuteReader();
                dt.Load(rdr);
                comboBox1.ValueMember = "tablenumber";
                comboBox1.DataSource = dt;
                con.Close();
              
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Close();

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable bt = new DataTable();



            da = new SqlDataAdapter("SELECT * FROM customer1", con);


            //cmd.ExecuteNonQuery();

            con.Open();
            da.Fill(bt);
            gunaDataGridView1.DataSource = bt;

            con.Close();

        }

        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox4.ReadOnly = false;

            label8.Visible = true;
            textBox5.Visible = true;

            gunaDataGridView1.CurrentRow.Selected = true;
            textBox5.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            textBox2.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
            textBox3.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["phone"].Value.ToString();
            textBox4.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
            comboBox1.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["table1"].Value.ToString();
            dateTimePicker1.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["date1"].Value.ToString();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string st = @"SELECT [table1]
        FROM [restaurant].[dbo].[tablecustomer] where table1='" + comboBox1.SelectedValue.ToString() + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(st, con);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("6e");

            }
            else
            {
                MessageBox.Show("nathi");
            }
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter("select * from customer1 where name='" + textBox1.Text+ "'", con);
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
    }
    
}

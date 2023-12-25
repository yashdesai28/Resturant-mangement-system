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
    public partial class table : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6NVC0CS;Initial Catalog=restaurant;Integrated Security=True");
        public table()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label6.Visible = true;
            label8.Visible = true;
            textBox2.Visible = true;
            textBox5.Visible = true;
            comboBox1.Visible = true;
            
          
            textBox5.ReadOnly = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Table1(tablenumber,chairs)values('" + textBox5.Text.ToString() + "','" + comboBox1.SelectedItem.ToString()+ "') ";
            cmd.ExecuteNonQuery();
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



            da1 = new SqlDataAdapter("SELECT * FROM Table1", con);


            //cmd.ExecuteNonQuery();

            con.Open();
            da1.Fill(bt1);
            gunaDataGridView2.DataSource = bt1;

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

       

        private void table_Load(object sender, EventArgs e)
        {
            diply_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Table1 set tablenumber='" + textBox5.Text.ToString() + "' where id='" + textBox2.Text.ToString() + "'";
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

        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label3.Visible = true;
            label6.Visible = true;
            label8.Visible = true;
            textBox2.Visible = true;
            textBox5.Visible = true;
            comboBox1.Visible = true;
            textBox5.ReadOnly = false;

            gunaDataGridView2.CurrentRow.Selected = true;
            textBox2.Text = gunaDataGridView2.Rows[e.RowIndex].Cells["id"].Value.ToString();
            textBox5.Text = gunaDataGridView2.Rows[e.RowIndex].Cells["tablenumber"].Value.ToString();

        }
    }
}

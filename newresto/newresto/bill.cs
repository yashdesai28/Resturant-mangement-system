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
using Microsoft.Reporting.WinForms;

namespace newresto
{

    public partial class bill : Form
    {
        public int maintotal=0,total = 0, qu, a,table11;
        string name;
        SqlDataReader dr;
        
        SqlConnection con =new SqlConnection("Data Source=DESKTOP-6NVC0CS;Initial Catalog=restaurant;Integrated Security=True");
        public bill()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            main m1 = new main();
            this.Hide();
            m1.Show();
        }

        void table()
        {
            string s1 = "select * from orders";
            SqlCommand cmd = new SqlCommand(s1, con);
            SqlDataReader rdr;

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("table1", typeof(string));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                comboBox2.ValueMember = "table1";
                comboBox2.DataSource = dt;
                con.Close();

            }
            catch
            {

            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bill_Load(object sender, EventArgs e)
        {
            table();
            this.reportViewer1.RefreshReport();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {

            int count = 1;
            con.Close();

            SqlDataAdapter da1 = new SqlDataAdapter();
            DataTable bt1 = new DataTable();



            da1 = new SqlDataAdapter("SELECT * FROM ordersp where table1 = '"+comboBox2.SelectedValue.ToString()+"'", con);


            //cmd.ExecuteNonQuery();

            con.Open();
            da1.Fill(bt1);
          
            gunaDataGridView1.DataSource= bt1;

            con.Close();


           //try
            //{
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT price,quantity,total12,item FROM ordersp where table1 = '" + comboBox2.SelectedValue.ToString() + "'", con);
                table11 = Convert.ToInt32(comboBox2.SelectedValue);
                textBox8.Text = table11.ToString();
                cmd.Parameters.AddWithValue("table1", comboBox2.SelectedItem.ToString());
                SqlDataReader dr;
                dr = cmd.ExecuteReader();


               
                while(dr.Read())
                {

                   
                    a=Convert.ToInt32( dr["price"]);
                    qu= Convert.ToInt32(dr["quantity"]);
                    total = Convert.ToInt32(dr["total12"]);
                    name =dr["item"].ToString();

                   
                    maintotal += total;
              

                    textBox2.Text=name;
                    textBox4.Text = a.ToString();
                    textBox6.Text = qu.ToString();
                    textBox7.Text = total.ToString();
                  

                   


                total = 0;
                  
                    


                }

                con.Close();
          // }

            //catch
            //{

            //}
            label6.Text = ("total amount = " + maintotal.ToString());





        }

        void bills1()
        {
            con.Close();
            con.Open();
           
            

      
           
            
           
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "insert into bills1 values('"+textBox4.Text+"','"+textBox8.Text+"','"+textBox6.Text+"','"+textBox7.Text+"','"+textBox2.Text+"')";
            cmd1.ExecuteNonQuery();
            con.Close();
            bill12();
        }

        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CleraTextBoxes();

            gunaDataGridView1.CurrentRow.Selected = true;
            textBox5.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            textBox4.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["item"].Value.ToString();
            textBox7.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString();
            textBox6.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["quantity"].Value.ToString();
            textBox8.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["table1"].Value.ToString();
            textBox2.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["total12"].Value.ToString();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

           
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int a, b;
            a = Convert.ToInt32(textBox3.Text);
            b = a - maintotal;
            textBox1.Text = b.ToString();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from ordersp where id = '" + textBox5.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            

            MessageBox.Show("Record delete Succesfully");
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "delete from tablecustomer where table1 = '" + comboBox2.SelectedValue.ToString() + "'";
            cmd1.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "delete from orders where table1 = '" + comboBox2.SelectedValue.ToString() + "'";
            cmd2.ExecuteNonQuery();
            con.Close();

            table();

            SqlDataAdapter da = new SqlDataAdapter("select * from bills1", con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            ReportDataSource data = new ReportDataSource("DataSet1", ds);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath =@"C:\Users\Admin\Desktop\newresto\newresto\Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(data);
            reportViewer1.RefreshReport();

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

        void bill12()
        {
            con.Close();

            SqlDataAdapter da1 = new SqlDataAdapter();
            DataTable bt1 = new DataTable();



            da1 = new SqlDataAdapter("SELECT * FROM bills1 ", con);


            //cmd.ExecuteNonQuery();

            con.Open();
            da1.Fill(bt1);

            gunaDataGridView2.DataSource = bt1;

            con.Close();
        }
    }
}

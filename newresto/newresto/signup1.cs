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
    
    public partial class signup1 : Form
    {
        SqlConnection conn=new SqlConnection(@"Data Source=DESKTOP-6NVC0CS;Initial Catalog=restaurant;Integrated Security=True");
        public signup1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into signup(username,password)values('" + susername.Text.ToString() + "','" + spassword.Text.ToString() + "')";
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Record Inserted Succesfully");

            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
            
        }
    }
}

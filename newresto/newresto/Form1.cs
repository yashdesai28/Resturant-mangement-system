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
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-6NVC0CS;Initial Catalog=restaurant;Integrated Security=True");
        SqlDataReader dr;
        public static string passname;
        public Form1()
        {
            InitializeComponent();
            password.Focus();
            password.PasswordChar = '*';

            password.MaxLength = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            passname = username.Text;
            string st= @"SELECT [username]
      ,[password]
  FROM[restaurant].[dbo].[signup] Where username='" + username.Text + "' AND password='" + password.Text + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(st, conn);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                main m1=new main();
                this.Hide();
                m1.Show();
                CleraTextBoxes();
              


            }
            else
            {
                MessageBox.Show("incorrt password");
                CleraTextBoxes();
            }
            conn.Close();
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

    }
}

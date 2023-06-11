using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ses1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-J3F0GHQ\SQLEXPRESS; Initial Catalog=Ses1; Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            Gosti gosti     = new Gosti();
            gosti.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string log, pass;
            log=txtLogin.Text;
            pass=txtPassword.Text;
            try
            {
                string qwerry = "select* from Users where Login ='" + txtLogin.Text + "'and Password='" + txtPassword.Text + "';" + "";
                SqlDataAdapter sda = new SqlDataAdapter(qwerry, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count > 0) { log = txtLogin.Text; pass = txtPassword.Text;
                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                }
                else { MessageBox.Show("error");
                    txtLogin.Clear();
                    txtPassword.Clear();
                }
            }
            catch { MessageBox.Show("error");
            } finally { conn.Close(); }
        }
    }
}

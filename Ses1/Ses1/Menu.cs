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



namespace Ses1
{
    public partial class Menu : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand();

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-J3F0GHQ\SQLEXPRESS; Initial Catalog=Ses1; Integrated Security=True");
        DataSet ds = new DataSet();
        public Menu()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            adapter = new SqlDataAdapter("select * from Tovary", conn);
            adapter.Fill(ds);
            tovaryDataGridView.DataSource = ds.Tables[0];
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ses1DataSet.Tovary". При необходимости она может быть перемещена или удалена.
            this.tovaryTableAdapter.Fill(this.ses1DataSet.Tovary);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ses1DataSet.Tovary". При необходимости она может быть перемещена или удалена.
            this.tovaryTableAdapter.Fill(this.ses1DataSet.Tovary);

        }

        private void tovaryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tovaryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ses1DataSet);

        }

        private void tovaryBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.tovaryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ses1DataSet);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    (tovaryDataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                    break;

                case 1:
                    (tovaryDataGridView.DataSource as DataTable).DefaultView.RowFilter = $"[Размер максимально возможной скидки] <=9";
                    break;

                case 2:
                    (tovaryDataGridView.DataSource as DataTable).DefaultView.RowFilter = $"[Размер максимально возможной скидки] >=10 AND [Размер максимально возможной скидки] <=14";
                    break;

                case 3:
                    (tovaryDataGridView.DataSource as DataTable).DefaultView.RowFilter = $"[Размер максимально возможной скидки] >=15";
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PainRows();
        }

        private void PainRows()
        {
            

            var c = System.Drawing.ColorTranslator.FromHtml("#7fff00");
            foreach (DataGridViewRow row in tovaryDataGridView.Rows)
            {
                try
                {
                    if (int.Parse(row.Cells[4].Value.ToString()) > 15)
                    {
                        row.DefaultCellStyle.BackColor = c;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }

                }
                catch { }
            }

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    tovaryDataGridView.Sort(tovaryDataGridView.Columns[4], ListSortDirection.Ascending);
                    break;
                case 1:
                    tovaryDataGridView.Sort(tovaryDataGridView.Columns[4], ListSortDirection.Descending);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
    
}

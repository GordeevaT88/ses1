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
    public partial class Gosti : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand();

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-J3F0GHQ\SQLEXPRESS; Initial Catalog=Ses1; Integrated Security=True");
        DataSet ds = new DataSet();
        public Gosti()
        {
            InitializeComponent();
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Gosti_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ses1DataSet.Tovary". При необходимости она может быть перемещена или удалена.
            this.tovaryTableAdapter.Fill(this.ses1DataSet.Tovary);

        }

        private void tovaryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
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
        private void LoadData()
        {
            adapter = new SqlDataAdapter("SELECT * FROM Tovary", conn);
            adapter.Fill(ds);
            tovaryDataGridView.DataSource = ds.Tables[0];
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    pictureBox2.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 6\Импорт\Товар_import\B320R5.jpg");
                    break;
                case 1:
                    pictureBox2.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 6\Импорт\Товар_import\D329H3.jpg");
                    break;
                case 2:
                    pictureBox2.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 6\Импорт\Товар_import\D572U8.jpg");
                    break;
                case 3:
                    pictureBox2.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 6\Импорт\Товар_import\F572H7.jpg");
                    break;
                case 4:
                    pictureBox2.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 6\Импорт\Товар_import\F635R4.jpg");
                    break;
                case 5:
                    pictureBox2.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 6\Импорт\Товар_import\G432E4.jpg");
                    break;
                case 6:
                    pictureBox2.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 6\Импорт\Товар_import\G783F5.jpg");
                    break;
                case 7:
                    pictureBox2.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 6\Импорт\Товар_import\H782T5.jpg");
                    break;
                case 8:
                    pictureBox2.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 6\Импорт\Товар_import\J384T6.jpg");
                    break;
                case 9:
                    pictureBox2.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 6\Импорт\Товар_import\А112Т4.jpg");
                    break;
            }
        }
    }
}

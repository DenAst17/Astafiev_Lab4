using Astafiev_Lab4.Classes;
using System;
using System.Windows.Forms;

namespace Astafiev_Lab4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButton3_Click(object sender, EventArgs e) // Add row
        {
            InputForm inputForm = new InputForm();
            inputForm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) // Delete row by index
        {
            try
            {
                if (!string.IsNullOrEmpty(toolStripTextBox4.Text))
                {
                    if (int.TryParse(toolStripTextBox4.Text, out int index))
                    {
                        mainDataGridView.Rows.RemoveAt(index - 1);
                        Table.tableData.RemoveAt(index - 1);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Число має бути у проміжку від 1 до номера останнього рядка", "Помилка вводу");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Помилка");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e) // Serialize
        {
            Table.ExportToJson();
        }

        private void toolStripButton2_Click(object sender, EventArgs e) // Deserialize
        {
            Table.ImportFromJson();
        }

        private void toolStripButton5_Click(object sender, EventArgs e) // Import
        {
            try
            {
                Table.Import();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Текстовий файл повинен мати в собі всі дані у форматі по 14 окремих блоків у рядку", "Помилка вводу");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Помилка");
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e) // Export
        {
            try
            {
                Table.Export();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                MessageBox.Show(exception.Message, "Помилка");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Помилка");
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(toolStripTextBox1.Text))
                {
                    MessageBox.Show("Введіть ПІП для пошуку", "Помилка вводу");
                }
                else
                {
                    string searchCriteria = toolStripTextBox1.Text;

                    Table.FilterByCell(searchCriteria, 0);
                    Table.PrintTableFiltered();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Помилка");
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(toolStripTextBox2.Text))
                {
                    MessageBox.Show("Введіть назву факультету для пошуку", "Помилка вводу");
                }
                else
                {
                    string searchCriteria = toolStripTextBox2.Text;

                    Table.FilterByCell(searchCriteria, 1);
                    Table.PrintTableFiltered();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Помилка");
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(toolStripTextBox3.Text))
                {
                    MessageBox.Show("Введіть назву роботи для пошуку", "Помилка вводу");
                }
                else
                {
                    string searchCriteria = toolStripTextBox3.Text;
                    
                    Table.FilterByCell(searchCriteria, 9);
                    Table.PrintTableFiltered();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Помилка");
            }
        }

        private void cancelSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table.PrintTable();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Helper.SetupDataGridView(mainDataGridView);
            Table.dataGridView = mainDataGridView;
        }
    }
}

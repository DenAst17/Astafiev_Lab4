using Astafiev_Lab4.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace Astafiev_Lab4
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        void checkEmpty()
        {
            if (
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                string.IsNullOrWhiteSpace(textBox8.Text) ||
                string.IsNullOrWhiteSpace(textBox9.Text) ||
                string.IsNullOrWhiteSpace(textBox10.Text) ||
                string.IsNullOrWhiteSpace(textBox11.Text) ||
                string.IsNullOrWhiteSpace(textBox12.Text) ||
                string.IsNullOrWhiteSpace(textBox13.Text) ||
                string.IsNullOrWhiteSpace(textBox14.Text) ||
                string.IsNullOrWhiteSpace(textBox15.Text)
                )
            {
                throw new Exception("Всі поля повинні бути заповнені");
            }
        }

        void checkInput()
        {
            if (
                textBox1.Text.Contains('|') ||
                textBox2.Text.Contains('|') ||
                textBox3.Text.Contains('|') ||
                textBox4.Text.Contains('|') ||
                textBox5.Text.Contains('|') ||
                textBox6.Text.Contains('|') ||
                textBox7.Text.Contains('|') ||
                textBox8.Text.Contains('|') ||
                textBox9.Text.Contains('|') ||
                textBox10.Text.Contains('|') ||
                textBox11.Text.Contains('|') ||
                textBox12.Text.Contains('|') ||
                textBox13.Text.Contains('|') ||
                textBox14.Text.Contains('|') ||
                textBox15.Text.Contains('|')
                )
            {
                throw new Exception("Не використовуйте символ |");
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                checkEmpty();
                checkInput();
                Worker worker = new Worker(
                    textBox1.Text,
                    new Faculty(textBox2.Text, textBox3.Text, textBox4.Text),
                    textBox5.Text,
                    textBox6.Text,
                    new Role(textBox7.Text, textBox8.Text, textBox9.Text),
                    textBox10.Text,
                    new Client(textBox11.Text, textBox12.Text, textBox13.Text, textBox14.Text),
                    textBox15.Text
                );

                Table.AddRow(worker.GetData());
                MessageBox.Show("Додано успішно", "Успіх");
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Помилка вводу");
            }
        }
    }
}

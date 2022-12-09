using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Astafiev_Lab4.Classes
{
    internal class Helper
    {
        public static string Serialize(Worker worker)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true 
            };
            string jsonWorker = JsonSerializer.Serialize(worker, options).Replace("\\u0027", "'"); ;
            return jsonWorker;
        }
        public static async Task<List<Worker>> Deserialize(string path)
        {
            using FileStream fs = new FileStream(path, FileMode.Open);
            var workers = await JsonSerializer.DeserializeAsync<List<Worker>>(fs);
            return workers;
        }
        public static void SetupDataGridView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.ColumnCount = 15;
            dataGridView.Columns[0].Name = "ПІП";
            dataGridView.Columns[1].Name = "Назва факультету";
            dataGridView.Columns[2].Name = "Департамент факультету";
            dataGridView.Columns[3].Name = "Відділення факультету";
            dataGridView.Columns[4].Name = "Кафедра";
            dataGridView.Columns[5].Name = "Лабораторія";
            dataGridView.Columns[6].Name = "Назва посади";
            dataGridView.Columns[7].Name = "Початок роботи на посаді";
            dataGridView.Columns[8].Name = "Кінець роботи на посаді";
            dataGridView.Columns[9].Name = "Назва роботи";
            dataGridView.Columns[10].Name = "Замовник";
            dataGridView.Columns[11].Name = "Адреса замовника";
            dataGridView.Columns[12].Name = "Підпорядкування замовника";
            dataGridView.Columns[13].Name = "Галузь";
            dataGridView.Columns[14].Name = "Номер";
        }
    }
}

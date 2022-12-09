using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Astafiev_Lab4.Classes
{
    internal class Table
    {
        public static void FilterByCell(string searchCriteria, int cellNumber)
        {
            filteredTableData = (
                from workerData in tableData
                where workerData[cellNumber] == searchCriteria
                select workerData
                ).ToList();
        }

        public static void PrintTable()
        {
            dataGridView.Rows.Clear();

            foreach (List<string> workerData in tableData)
            {
                Worker worker = new Worker(workerData.ToList());
                dataGridView.Rows.Add(worker.GetData());
            }
        }
        public static void PrintTableFiltered()
        {
            dataGridView.Rows.Clear();

            foreach (List<string> workerData in filteredTableData)
            {
                Worker worker = new Worker(workerData.ToList());
                dataGridView.Rows.Add(worker.GetData());
            }
        }
        public static void Import() {
            foreach (string line in File.ReadLines(IMPORT_PATH))
            {
                string[] workerData = line.Split("|");
                if (workerData.Length != dataGridView.ColumnCount)
                {
                    throw new ArgumentOutOfRangeException(workerData.Length.ToString());
                }
                tableData.Add(workerData.ToList());
                Worker worker = new Worker(workerData.ToList());
                dataGridView.Rows.Add(worker.GetData());
            }
            MessageBox.Show("Операція успішна", "Успіх");
        }

        public static async void Export()
        {
            List<string> strings = new List<string>();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool rowIsEmpty = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        rowIsEmpty = true;
                        break;
                    }
                }
                if (!rowIsEmpty)
                {
                    var workerData =
                        row.Cells[0].Value + "|" +
                        row.Cells[1].Value + "|" +
                        row.Cells[2].Value + "|" +
                        row.Cells[3].Value + "|" +
                        row.Cells[4].Value + "|" +
                        row.Cells[5].Value + "|" +
                        row.Cells[6].Value + "|" +
                        row.Cells[7].Value + "|" +
                        row.Cells[8].Value + "|" +
                        row.Cells[9].Value + "|" +
                        row.Cells[10].Value + "|" +
                        row.Cells[11].Value + "|" +
                        row.Cells[12].Value + "|" +
                        row.Cells[13].Value + "|" +
                        row.Cells[14].Value + "|";
                    strings.Add(workerData);
                }
            }
            await File.WriteAllLinesAsync(EXPORT_PATH, strings);
            MessageBox.Show("Операція успішна", "Успіх");
        }

        public static async void ImportFromJson()
        {
            var workers = await Helper.Deserialize(DESERIALIZE_PATH);
            if (workers != null)
            {
                foreach (var worker in workers)
                {
                    dataGridView.Rows.Add(worker.GetData());
                    Table.tableData.Add(worker.GetData().ToList());
                }
            }
            MessageBox.Show("Операція успішна", "Успіх");
        }

        public static async void ExportToJson()
        {
            List<string> jsonWorkers = new List<string>();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool rowIsEmpty = true;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        rowIsEmpty = false;
                        break;
                    }
                }

                if (!rowIsEmpty)
                {
                    Worker worker = new Worker(row);

                    string jsonWorker = Helper.Serialize(worker);
                    jsonWorkers.Add(jsonWorker);
                }
            }

            await File.WriteAllLinesAsync(SERIALIZE_PATH, jsonWorkers, Encoding.UTF8);
            MessageBox.Show("Операція успішна", "Успіх");
        }
        public static void AddRow(string[] row)
        {
            dataGridView.Rows.Add(row);
            Table.tableData.Add(row.ToList());
        }

        public static List<List<string>> tableData = new List<List<string>>();
        public static List<List<string>> filteredTableData = new List<List<string>>();
        public static DataGridView dataGridView = new DataGridView();

        public const string DESERIALIZE_PATH = @".\data.json";
        public const string SERIALIZE_PATH = @".\result.json";
        public const string EXPORT_PATH = @".\output.txt";
        public const string IMPORT_PATH = @".\input.txt";
    }
}

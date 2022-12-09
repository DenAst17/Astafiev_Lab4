using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Astafiev_Lab4.Classes
{
    internal class Worker
    {
        //[JsonIgnore]
        //[JsonPropertyName("Name")]

        public Worker
            (
            string pIP, 
            Faculty faculty, 
            string cathedra, 
            string laboratory, 
            Role role, 
            string workTitle, 
            Client client,
            string numberString
            )
        {
            PIP = pIP;
            Faculty = faculty;
            Cathedra = cathedra;
            Laboratory = laboratory;
            Role = role;
            WorkTitle = workTitle;
            Client = client;
            if(int.TryParse(numberString, out int number))
            {
                Number = number;
            }
            else
            {
                throw new Exception("В полі Number повинно бути число");
            }
        }

        public Worker(List<string> workerData)
        {
            PIP = workerData[0];
            Faculty = new Faculty(workerData[1], workerData[2], workerData[3]);
            Cathedra = workerData[4];
            Laboratory = workerData[5];
            Role = new Role(workerData[6], workerData[7], workerData[8]);
            WorkTitle = workerData[9];
            Client = new Client(workerData[10], workerData[11], workerData[12], workerData[13]);
            if(int.TryParse(workerData[14], out int number))
            {
                Number = number;
            }
            else
            {
                throw new Exception("В полі Number повинно бути число");
            }
        }

        public Worker(DataGridViewRow row)
        {
            PIP = row.Cells[0].Value + "";

            Faculty = new Faculty(
                row.Cells[1].Value + "", 
                row.Cells[2].Value + "", 
                row.Cells[3].Value + ""
                );

            Cathedra = row.Cells[4].Value + "";
            Laboratory = row.Cells[5].Value + "";

            Role = new Role(
                row.Cells[6].Value + "",
                row.Cells[7].Value + "",
                row.Cells[8].Value + ""
                );

            WorkTitle = row.Cells[9].Value + "";

            Client = new Client(
                row.Cells[10].Value + "",
                row.Cells[11].Value + "",
                row.Cells[12].Value + "",
                row.Cells[13].Value + ""
                );
            if (int.TryParse(row.Cells[14].Value + "", out int number))
            {
                Number = number;
            }
            else
            {
                throw new Exception("В полі повинно бути число");
            }
        }

        public Worker()
        {
            PIP = "";
            Faculty = new Faculty("", "", "");
            Cathedra = "";
            Laboratory = "";
            Role = new Role("", "", "");
            WorkTitle = "";
            Client = new Client("", "", "", "");
            Number = 0;
        }

        public string PIP { get; set; }
        public Faculty Faculty{ get; set; }
        public string Cathedra { get; set; }
        public string Laboratory { get; set; }
        public Role Role { get; set; }
        public string WorkTitle { get; set; }
        public Client Client { get; set; }
        public int Number { get; set; }
        public string[] GetData()
        {
            string[] row = { 
                PIP, 
                Faculty.Title, 
                Faculty.Department, 
                Faculty.Branch,
                Cathedra,
                Laboratory,
                Role.Title, 
                Role.StartDate, 
                Role.EndDate,
                WorkTitle,
                Client.Name,
                Client.Address,
                Client.Submission,
                Client.Area,
                Number.ToString(),
            };

            return row;
        }
    }
}

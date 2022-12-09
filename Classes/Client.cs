using System;
using System.Collections.Generic;
using System.Text;

namespace Astafiev_Lab4.Classes
{
    internal class Client
    {
        public Client() { }

        public Client(string name, string address, string submission, string area)
        {
            Name = name;
            Address = address;
            Submission = submission;
            Area = area;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Submission { get; set; }
        public string Area { get; set; }
    }
}

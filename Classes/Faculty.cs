using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace Astafiev_Lab4.Classes
{
    internal class Faculty
    {
        public Faculty(string title, string department, string branch)
        {
            Title = title;
            Department = department;
            Branch = branch;
        }

        public Faculty() { }

        public string Title { get; set; }
        public string Department { get; set; }
        public string Branch { get; set; }
    }
}

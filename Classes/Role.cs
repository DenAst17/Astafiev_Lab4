using System;
using System.Collections.Generic;
using System.Text;

namespace Astafiev_Lab4.Classes
{
    internal class Role
    {
        public Role(string title, string startDate, string endDate)
        {
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Role()
        {

        }

        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}

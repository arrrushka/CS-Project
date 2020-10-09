using System;
using System.Collections.Generic;

namespace ProjectV2.Models
{
    public partial class Class
    {
        public Class()
        {
            Schedule = new HashSet<Schedule>();
        }

        public int ClassId { get; set; }
        public string Class1 { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}

using System;

namespace ProjectV2.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public TimeSpan SubjectStart { get; set; }
        public TimeSpan SubjectEnd { get; set; }
        public int Day { get; set; }
        public String Class { get; set; }
        public string Group { get; set; }
        public string Subject { get; set; }
    }
}
using MediaAPI.Domain.Media;
using System;

namespace MediaAPI.Domain.Statistics
{
    public class MediaStatistics
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Person UsingPerson { get; set; }
    }
}

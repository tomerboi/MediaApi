using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Domain.Media
{
    public class DiskOnKeyMedia : MediaAbs
    {
        public DiskOnKeyMedia(string name, EventType eventType, List<Person> participants, DateTime date, string location) : base(name, eventType, participants, date, location)
        {
        }
    }
}

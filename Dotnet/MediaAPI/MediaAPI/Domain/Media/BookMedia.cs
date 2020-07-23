using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Domain.Media
{
    public class BookMedia : MediaAbs
    {
        public BookMedia(string name, EventType eventType, List<Person> participants, DateTime date, string location) : base(name, eventType, participants, date, location)
        {
        }
    }
}

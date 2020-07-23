using MediaAPI.Domain.Media;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Contracts.V1.Response
{
    public class FullMediaResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EventType { get; set; }
        public List<Person> Participants { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public Person UsingPerson { get; set; }

        public string MediaType { get; set; }
    }
}

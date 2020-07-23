using MediaAPI.Domain.Media;
using System;
using System.Collections.Generic;

namespace MediaAPI.Contracts.V1.Requset
{
    public class MediaRequest
    {
        public string Name { get; set; }
        public string EventType { get; set; }
        public string Participants { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string UsingPerson { get; set; }
        public string MediaType { get; set; }        
        public string Id { get; set; }        
    }
}

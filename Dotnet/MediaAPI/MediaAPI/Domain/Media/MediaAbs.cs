using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace MediaAPI.Domain.Media
{
    public enum EventType
    {
        Birthday, 
        Bar_Mitzva, 
        Wedding, 
        Holiday
    }
    public abstract class MediaAbs
    {
        public readonly Guid Id; 
        public string Name { get; set; }
        public EventType EventType { get; set; }
        public List<Person> Participants { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public Person UsingPerson { get; set; }

        public MediaAbs(string name, EventType eventType, List<Person> participants, DateTime date, string location)
        {
            Name = name;
            EventType = eventType;
            Participants = participants;
            Date = date;
            Location = location;
            Id = Guid.NewGuid();
        }
        public bool IsInUse()
        {
            return UsingPerson == null;
        }

        public void SetUsingPerson(Person person)
        {
            UsingPerson = person;
        }
    }
}

using System;

namespace MediaAPI.Domain.Media
{
    public class Person
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public Person(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }
    }
}
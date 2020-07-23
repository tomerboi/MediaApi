using MediaAPI.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Data
{
    public class PersonData
    {
        public List<Person> Persons => m_Persons;
        private List<Person> m_Persons = new List<Person>();

        public PersonData()
        {
            m_Persons.Add(new Person("Tamar"));
            m_Persons.Add(new Person("Yoav"));
            m_Persons.Add(new Person("Mor"));
            m_Persons.Add(new Person("Tomer"));
        }
    }
}

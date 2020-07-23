using MediaAPI.Domain;
using MediaAPI.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Data
{
    public class DbConnector : IDbConnector
    {
        private readonly PersonData m_personData;
        private readonly UsersData m_usersData;

        public DbConnector()
        {
            m_personData = new PersonData();
            m_usersData = new UsersData();
        }

        public List<Person> GetAllPersons()
        {
            return m_personData.Persons;
        }

        public List<User> GetAllUsers()
        {
            return m_usersData.Users;
        }
    }
}

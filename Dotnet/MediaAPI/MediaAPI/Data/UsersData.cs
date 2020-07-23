using MediaAPI.Domain;
using System.Collections.Generic;

namespace MediaAPI.Data
{
    public class UsersData
    {
        public List<User> Users => m_users;
        private readonly List<User> m_users;
        public UsersData()
        {

            m_users = new List<User>{ new User("test1", "password1") , new User("test2", "password2") };
        }
        
    }
}

using MediaAPI.Domain;
using MediaAPI.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MediaAPI.Data
{
    public interface IDbConnector
    {
        List<User> GetAllUsers();
        List<Person> GetAllPersons();
    }
}

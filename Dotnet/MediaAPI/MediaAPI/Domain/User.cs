﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Domain
{
    public class User
    {
        public string UserName { get; }
        public string Password { get; }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}

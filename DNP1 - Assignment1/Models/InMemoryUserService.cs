using System;
using System.Collections.Generic;
using System.Linq;

namespace DNP1___Assignment1.Models
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;
        
        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    UserName = "Andreas",
                    Password = "12345",
                    Role = "Student",
                    SecurityLevel = 5
                }
            }.ToList();
        }
        
        public User ValidateUser(string userName, string Password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(Password))
            {
                throw new Exception("Password dont match");
            }

            return first;
        }
    }
}
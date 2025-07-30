using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    class UserManager : IUserManager
    {
        public List<User> Users = new List<User>();

        public User Register(string name, string password, string email)
        {
            // Check if the user already exists
            foreach (var user in Users)
            {
                if (user.Email == email)
                {
                    Console.WriteLine("User already exists with this email.");
                    return null;
                }
            }

            User newUser = new User()
            {
                Name = name,
                Password = password,
                Email = email
            };
            Users.Add(newUser);
            return newUser;
        }

        public User Login(string email, string password)
        {
            // Check if the user exists
            foreach (var user in Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    Console.WriteLine("Login successful.");
                    return user;
                }
            }
            // If the user does not exist or the password is incorrect
            Console.WriteLine("Invalid email or password.");
            return null;
        }


    }
}

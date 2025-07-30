using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    interface IUserManager
    {
        User Register(string name , string password , string email);
        User Login(string email, string password);
    }
}

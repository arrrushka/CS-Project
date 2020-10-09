using ProjectV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectV2.Data.Interfaces
{
    public interface IAuthRepository
    {
        Users Register(Users student, string password);

        Users Login(string username, string password);

        bool UserExists(string username);
    }
}
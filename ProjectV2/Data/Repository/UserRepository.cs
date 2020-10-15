using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ProjectV2.Data.Interfaces;
using ProjectV2.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectV2.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly schedule_dbContext _dbContext;
        private readonly IConfiguration _config;

        public UserRepository(schedule_dbContext schedule_DbContext, IConfiguration config)
        {
            _dbContext = schedule_DbContext;
            _config = config;
        }

        public async Task<bool> SetAsAdmin(string Username)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username.Equals(Username));
            user.Role = "Admin";
            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> SetAsTeacher(string Username)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username.Equals(Username));
            user.Role = "Teacher";
            return _dbContext.SaveChanges() > 0;
        }
    }
}
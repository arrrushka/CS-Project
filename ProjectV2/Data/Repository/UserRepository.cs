using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ProjectV2.Data.Interfaces;
using ProjectV2.Models;
using System.Linq;

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

        public bool SetAsTeacher(string Username)
        {
            MySqlConnection connection;
            connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            connection.Open();
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            string sql = "Update Users set role = 'Teacher' where username = '" + Username + "'";

            command = new MySqlCommand(sql, connection);

            adapter.UpdateCommand = new MySqlCommand(sql, connection);
            adapter.UpdateCommand.ExecuteNonQuery();

            command.Dispose();
            connection.Close();

            var check = _dbContext.Users.Where(x => x.Username == Username).Where(x => x.Role.Equals("Teacher"));
            if (check == null) return false;
            return true;
        }
    }
}
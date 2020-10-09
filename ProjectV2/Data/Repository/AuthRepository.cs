﻿using ProjectV2.Data.Interfaces;
using ProjectV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectV2.Data.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly schedule_dbContext _DbContext;

        public AuthRepository(schedule_dbContext schedule_DbContext)
        {
            _DbContext = schedule_DbContext;
        }

        public Users Register(Users user, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _DbContext.Users.Add(user);
            _DbContext.SaveChanges();

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public bool UserExists(string username)
        {
            return _DbContext.Users.Any(x => x.Username == username);
        }

        public Users Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
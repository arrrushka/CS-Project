﻿namespace ProjectV2.Data.Interfaces
{
    public interface IUserRepository
    {
        bool SetAsTeacher(string Username);

        bool SetAsAdmin(string Username);
    }
}
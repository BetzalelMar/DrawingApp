using DALContracts;
using DrawnigContracts.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DrawnigContracts.Interface
{
    public interface IusersDal
    {
        public DataSet GetUser(string userId);
        public DataSet GetAllUsersNames();
        public DataSet CreateUser(string userId,string userName,string userPassword);
        public DataSet DeleteUser(string userId);
        public DataSet Login(string userId);
        public DataSet Logout(string userId);
    }
}

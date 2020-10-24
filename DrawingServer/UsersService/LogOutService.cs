using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.DTO.usersDTO.UserRequest;
using DrawnigContracts.DTO.usersDTO.UserResponse;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.UsersInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsersService
{
    [Register(Policy.Transient,typeof(ILogOutService))]
    public class LogOutService : ILogOutService
    {
        IusersDal _dal;
        public LogOutService(IusersDal dal)
        {
            _dal = dal;
        }
        public Response LogOut(LogOutRequest request)
        {
            Response retval;
            try
            {
                var dbResponse = _dal.Logout(request.userId);
                var data = new List<string>();
                data.Add(request.userId + "logged out successfully !!");
                retval = new LogOutResponseOk(data);
            }
            catch (Exception)
            {
                retval = new AppResponseError();
            }
            return retval;
        }
    }
}

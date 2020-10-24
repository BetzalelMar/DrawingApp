using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.DTO.usersDTO;
using DrawnigContracts.DTO.usersDTO.UserResponse;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.UsersInterface;
using System;
using System.Collections.Generic;

namespace UsersService
{
    [Register(Policy.Transient,typeof(IRemoveUserService))]
    public class RemoveUserService: IRemoveUserService
    {
        IusersDal _dal;
        public RemoveUserService(IusersDal dal)
        {
            _dal = dal;
        }
        public Response RemoveUser(RemoveUserRequest request)
        {
            Response retval;
            try
            {
                var dbResponse = _dal.DeleteUser(request.userId);
                var data = new List<string>();
                data.Add(request.userId + "was deleted successfully!!");
                retval = new RemoveUserResponseOk(data);
            }
            catch (Exception)
            {
                retval = new AppResponseError();
            }
            return retval;
        }

    }
}

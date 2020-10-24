using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.DTO.usersDTO.UserResponse;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.UsersInterface;
using System;
using System.Data;
using System.Linq;

namespace UsersService
{
    [Register(Policy.Transient, typeof(IGetUserService))]
    public class GetUserService : IGetUserService
    {
        IusersDal _dal;
        IUserConvertor _convertor;
        public GetUserService(IusersDal dal, IUserConvertor convertor)
        {
            _dal = dal;
            _convertor = convertor;
        }
        public Response GetAllUsersNames()
        {
            Response retval;
            try
            {
                var dbResponse = _dal.GetAllUsersNames().Tables[0];
                var data = dbResponse.AsEnumerable().Select(dbRow => dbRow.Field<string>("USERNAME")).ToList<string>();
                retval = new GetAllUsersNameResponse(data);
            }
            catch (Exception)
            {

                retval = new AppResponseError();
            }
            return retval;       
        }

        public Response GetUser(GetUserRequest request)
        {
            Response retval;
            try
            {
                var dbResponse = _dal.GetUser(request.userId).Tables[0];
                if (dbResponse.Rows.Count == 0)
                    retval = new GetUserResponseInValid("user not exist !!");
                else
                {
                    var data = _convertor.convertTableToList(dbResponse);
                    retval = new GetUserResponseOk(data);
                }
            }
            catch (Exception)
            {

                retval = new AppResponseError();
            }
            return retval;
        }
    }
}

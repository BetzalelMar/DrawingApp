using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.DTO.usersDTO.UserResponse;
using DrawnigContracts.Interface;
using System;
using System.Collections.Generic;

namespace UsersService
{
    [Register(Policy.Transient, typeof(IRegisterService))]
    public class RegisterService : IRegisterService
    {
        IusersDal _dal;
        IUserConvertor _convertor;
        IvalidatorService _validator;
        public RegisterService(IusersDal dal, IUserConvertor convertor, IvalidatorService validator)
        {
            _dal = dal;
            _convertor = convertor;
            _validator = validator;
        }
        public Response Register(RegisterRequest request)
        {
            Response retval;
            try
            {
                if (request.userPassword != request.userConfirmPassword)
                    retval = new RegisterResponsePasswordNotMatch("Password Not Match !!");
                else if (_validator.UserExist(request.userId))
                    retval = new RegisterResponseUserExist("user exist !!!");

                else
                {
                    var dbResponse = _dal.CreateUser(request.userId, request.userName, request.userPassword);
                    var data = _convertor.convertTableToList(dbResponse.Tables[0]);
                    retval = new RegisterResponseOk(data);
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

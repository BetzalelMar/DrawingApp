using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace UsersService
{
    [Register(Policy.Transient,typeof(ILogInService))]
    public class LogInService : ILogInService
    {
        IusersDal _dal;
        IUserConvertor _convertor;
        IvalidatorService _validator;
        public LogInService(IusersDal dal, IUserConvertor convertor, IvalidatorService validator)
        {
            _dal = dal;
            _convertor = convertor;
            _validator = validator;
        }

        public Response LogIn(LogInRequest request)
        {
            Response retval = new LogInResponseInValidUserNameOrPassword("In Valid UserName Or Password");
            try
            {
                var user = _dal.GetUser(request.userId).Tables[0];
                if (user.Rows.Count != 0)
                {
                    var password = user.Rows[0].Field<string>("PASSWORD");
                    if (request.userPassword== password)
                    {
                        var dbResponse=_dal.Login(request.userId).Tables[0];
                        var data = _convertor.convertTableToList(dbResponse);
                        retval = new LogInResponseOk(data);
                    }
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

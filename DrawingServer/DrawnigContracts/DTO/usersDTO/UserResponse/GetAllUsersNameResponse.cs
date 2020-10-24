using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.usersDTO.UserResponse
{
    public class GetAllUsersNameResponse:ResponseOk<string>
    {
        public GetAllUsersNameResponse(List<string> responseData):base(responseData)
        {

        }
    }
}

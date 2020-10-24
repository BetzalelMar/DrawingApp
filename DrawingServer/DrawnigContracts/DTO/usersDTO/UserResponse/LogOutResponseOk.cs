using System.Collections.Generic;

namespace DrawnigContracts.DTO.usersDTO.UserResponse
{
    public class LogOutResponseOk:ResponseOk<string>
    {
        public LogOutResponseOk(List<string> data):base(data)
        {

        }
    }
}

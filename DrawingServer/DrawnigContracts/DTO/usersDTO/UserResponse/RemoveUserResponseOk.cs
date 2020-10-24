using System.Collections.Generic;

namespace DrawnigContracts.DTO.usersDTO.UserResponse
{
    public class RemoveUserResponseOk :ResponseOk<string>
    {
        public RemoveUserResponseOk(List<string> msg):base(msg)
        {

        }

    }
}

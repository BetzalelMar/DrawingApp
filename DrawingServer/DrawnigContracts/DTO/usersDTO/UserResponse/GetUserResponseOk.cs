using DrawnigContracts.DTO.usersDTO;
using System.Collections.Generic;

namespace DrawnigContracts.DTO
{
    public class GetUserResponseOk:ResponseOk<UserData>
    {
        public GetUserResponseOk(List<UserData> request)
            :base(request)
        {

        }
    }
}

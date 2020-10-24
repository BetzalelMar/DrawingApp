using Contracts.DTO;
using DrawnigContracts.DTO.usersDTO;

namespace DrawnigContracts.Interface.UsersInterface
{
    public interface IRemoveUserService
    {
        public Response RemoveUser(RemoveUserRequest request);
    }
}

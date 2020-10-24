using Contracts.DTO;
using DrawnigContracts.DTO.usersDTO.UserRequest;

namespace DrawnigContracts.Interface.UsersInterface
{
    public interface ILogOutService
    {
        public Response LogOut(LogOutRequest request);
    }
}

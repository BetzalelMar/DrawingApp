using Contracts.DTO;
using DrawnigContracts.DTO;

namespace DrawnigContracts.Interface.UsersInterface
{
    public interface IGetUserService
    {
        public Response GetUser(GetUserRequest request);
        public Response GetAllUsersNames();
    }
}

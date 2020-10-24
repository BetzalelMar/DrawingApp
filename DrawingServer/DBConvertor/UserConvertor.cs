using Contracts;
using DrawnigContracts.DTO.usersDTO;
using DrawnigContracts.Interface;
using System.Data;


namespace DBConvertor
{
    [Register(Policy.Transient,typeof(IUserConvertor))]
    public class UserConvertor : BaseConvertor<UserData>,IUserConvertor
    {
        public override UserData Convert(DataRow dataRow)
        {
            var userData = new UserData
            {
                userId = dataRow.Field<string>("USERID"),
                userName = dataRow.Field<string>("USERNAME")
            };
            return userData;

        }
    }
}

using Contracts;
using DALContracts;
using DrawnigContracts.Interface;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace UsersDal
{
    [Register(Policy.Transient, typeof(IusersDal))]
    public class userDalImpl : IusersDal
    {
        IDrawingDalService _dalService;
        public userDalImpl(IDrawingDalService dalService)
        {
            _dalService = dalService;
        }
        public DataSet GetUser(string userId)
        {
            IDBParameter[] parm =
 {
               _dalService.DalInfra.getParameter("P_USERID", OracleDbType.Varchar2, userId)
            };
            return _dalService.ESPQ("GET_USER", parm);
        }

        public DataSet CreateUser(string userId, string userName, string userPassword)
        {
            IDBParameter[] parm =
            {
                _dalService.DalInfra.getParameter("P_USERID", OracleDbType.Varchar2, userId),
               _dalService.DalInfra.getParameter("P_USERNAME", OracleDbType.Varchar2, userName),
                _dalService.DalInfra.getParameter("p_USERPASSWORD", OracleDbType.Varchar2,userPassword)

            };
            return _dalService.ESPQ("CREATE_USER", parm);
        }

        public DataSet DeleteUser(string userId)
        {
            IDBParameter[] parm =
            {
               _dalService.DalInfra.getParameter("P_USERID", OracleDbType.Varchar2, userId)
            };
            return _dalService.ESPQ("REMOVE_USER", parm);
        }


        public DataSet Login(string userId)
        {
            IDBParameter[] parm =
             {
                _dalService.DalInfra.getParameter("P_USERID", OracleDbType.Varchar2, userId)
             };
            return _dalService.ESPQ("LOGIN", parm);
        }

        public DataSet Logout(string userId)
        {
            IDBParameter[] parm =
            {
               _dalService.DalInfra.getParameter("P_USERID", OracleDbType.Varchar2, userId)
            };
            return _dalService.ESPQ("LOGOUT", parm);
        }

        public DataSet GetAllUsersNames()
        {
            return _dalService.ESPQ("GET_ALL_USERS_NAME");
        }
    }
}

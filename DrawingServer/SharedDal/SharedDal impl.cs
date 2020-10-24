using Contracts;
using DALContracts;
using DrawnigContracts.DTO.SharedDTO;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.SharedInterface;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace SharedDal
{
    [Register(Policy.Transient, typeof(ISharedDal))]
    public class SharedDalImpl : ISharedDal
    {
        IDrawingDalService _dalService;
        public SharedDalImpl(IDrawingDalService dalService)
        {
            _dalService = dalService;
        }

        public DataSet AddShared(SharedData data)
        {
            IDBParameter[] parm ={
                this._dalService.DalInfra.getParameter("P_USERID", OracleDbType.Varchar2, data.userId),
                this._dalService.DalInfra.getParameter("P_DOCID", OracleDbType.Varchar2, data.docId) };
            return this._dalService.ESPQ("CREATE_SHARED", parm);
        }

        public DataSet GetAllShared(string userId)
        {
            IDBParameter[] parm = {
                this._dalService.DalInfra.getParameter("P_USERID", OracleDbType.Varchar2, userId) };
            return this._dalService.ESPQ("GET_ALL_SHARED_DOC ", parm);

        }

        public DataSet GetShared(string userId, string docId)
        {
            IDBParameter[] parm = {
                this._dalService.DalInfra.getParameter("P_USERID", OracleDbType.Varchar2, userId),
                this._dalService.DalInfra.getParameter("P_DOCID", OracleDbType.Varchar2, docId) };
            return this._dalService.ESPQ("GET_SHARED", parm);

        }

        public DataSet RemoveShared(SharedData data)
        {
            IDBParameter[] parm = {
                this._dalService.DalInfra.getParameter("P_USERID", OracleDbType.Varchar2, data.userId),
                this._dalService.DalInfra.getParameter("P_DOCID", OracleDbType.Varchar2, data.docId) };
            return this._dalService.ESPQ("REMOVE_SHARE", parm);
        }
    }
}

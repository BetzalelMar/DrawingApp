using Contracts;
using DALContracts;
using DrawnigContracts.DTO.DocsDTO;
using DrawnigContracts.DTO.documentsDTO.DocData;
using DrawnigContracts.Interface;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DocsDal
{
    [Register(Policy.Transient,typeof(IDocDal))]
    public class DocDalImpl :IDocDal
    {
        IDrawingDalService _dalService;
        public DocDalImpl(IDrawingDalService dalService)
        {
            _dalService = dalService;

        }
        public DataSet CreateDoc(string docId, AddDocRequest request)
        {
            IDBParameter[] param = {
            _dalService.DalInfra.getParameter("P_OWNER", OracleDbType.Varchar2, request.ownerId),
            _dalService.DalInfra.getParameter("P_DOCID", OracleDbType.Varchar2, docId),
            _dalService.DalInfra.getParameter("P_DOCNAME", OracleDbType.Varchar2, request.docName),
            _dalService.DalInfra.getParameter("P_DOCURL", OracleDbType.Varchar2, request.docUrl)
        };
            return _dalService.ESPQ("CREATE_DOC", param);
        }

        public DataSet GetAllDocs(string ownerId)
        {
            IDBParameter p1 = _dalService.DalInfra.getParameter("P_OWNERID", OracleDbType.Varchar2,ownerId);
            return _dalService.ESPQ("GET_ALL_DOCUMENTS", p1);
        }

        public DataSet GetDoc(string docId)
        {
            IDBParameter p1 = _dalService.DalInfra.getParameter("P_DOCID", OracleDbType.Varchar2, docId);
            return _dalService.ESPQ("GET_DOC", p1);
        }

        public DataSet RemoveDoc(string docId)
        {
            IDBParameter p1 = _dalService.DalInfra.getParameter("P_DOCID", OracleDbType.Varchar2, docId);
            return _dalService.ESPQ("REMOVE_DOC", p1);
        }
    }
}

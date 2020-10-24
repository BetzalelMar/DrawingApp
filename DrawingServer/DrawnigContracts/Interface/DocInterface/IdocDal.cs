using DrawnigContracts.DTO.DocsDTO;
using DrawnigContracts.DTO.documentsDTO.DocData;
using System.Data;

namespace DrawnigContracts.Interface
{
    public interface IDocDal
    {
        public DataSet CreateDoc(string docId,AddDocRequest request);
        public DataSet GetDoc(string docId);
        public DataSet GetAllDocs(string ownerId);
        public DataSet RemoveDoc( string docId);
    }
}

using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.DTO.DocsDTO.DocRequest;
using DrawnigContracts.DTO.documentsDTO.DocResponse;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.DocInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentService
{
    [Register(Policy.Transient, typeof(IRemoveDocService))]

    public class RemoveDocService : IRemoveDocService
    {
        IDocDal _dal;
        public RemoveDocService(IDocDal dal)
        {
            _dal = dal;
        }

        public Response removeDoc(RemoveDocRequest request)
        {
            Response retval;
            try
            {
                var doc = _dal.GetDoc(request.docId).Tables[0];
                if (doc.Rows.Count == 0)
                    retval = new RemoveDocBadResponse("Document does not exist !");
                else
                {
                    _dal.RemoveDoc(request.docId);
                    var list = new List<string>();
                    list.Add(request.docId);
                    retval = new RemoveDocResponseOk(list);
                }
            }
            catch (Exception)
            {

                retval = new AppResponseError();
            }
            return retval;
        }
    }
}

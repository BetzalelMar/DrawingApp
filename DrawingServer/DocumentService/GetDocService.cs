using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.DTO.DocsDTO;
using DrawnigContracts.DTO.documentsDTO.DocData;
using DrawnigContracts.DTO.documentsDTO.DocResponse;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.DocInterface;
using System;

namespace DocumentService
{
    [Register(Policy.Transient, typeof(IGetDocService))]
    public class GetDocService : IGetDocService
    {
        IDocDal _dal;
        IDocConvertor _convertor;
        public GetDocService(IDocDal dal, IDocConvertor convertor)
        {
            _dal = dal;
            _convertor = convertor;
        }


        public Response GetDoc(GetDocRequest request)
        {
            Response retval;
            try
            {
                var dbResponse = _dal.GetDoc(request.docId).Tables[0];
                var data = _convertor.convertTableToList(dbResponse);
                retval = new GetDocResponseOk(data);
            }
            catch (Exception)
            {

                retval = new AppResponseError();
            }
            return retval;
        }

    }
}

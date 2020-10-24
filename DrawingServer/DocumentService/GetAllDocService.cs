using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.DTO.DocsDTO;
using DrawnigContracts.DTO.documentsDTO.DocResponse;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.DocInterface;
using System;

namespace DocumentService
{
    [Register(Policy.Transient, typeof(IGetAllDocService))]
    public class GetAllDocService : IGetAllDocService
    {
        IDocDal _dal;     
        IDocConvertor _convertor;
        public GetAllDocService(IDocDal dal,IDocConvertor convertor)
        {
            _dal = dal;
            _convertor = convertor;
        }
        public Response GetAllDocs(GetAllDocsRequest request)
        {
            Response retval;
            try
            {
                var dbResponse = _dal.GetAllDocs(request.UserId).Tables[0];
                var data= _convertor.convertTableToList(dbResponse);
                retval = new GetAllDocResponseOk(data);
            }
            catch (Exception)
            {

                retval = new AppResponseError();
            }


            return retval;
        }
    }
}

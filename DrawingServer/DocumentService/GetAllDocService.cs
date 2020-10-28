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
        IMapDocToUsersService _docToUsersService;
        public GetAllDocService(IDocDal dal,IDocConvertor convertor,IMapDocToUsersService docToUsersService)
        {
            _dal = dal;
            _convertor = convertor;
            _docToUsersService = docToUsersService;
        }
        public Response GetAllDocs(GetAllDocsRequest request)
        {
            Response retval;
            try
            {
                var dbResponse = _dal.GetAllDocs(request.UserId).Tables[0];
                var data= _convertor.convertTableToList(dbResponse);
                retval = new GetAllDocResponseOk(data);
                data.ForEach(doc => _docToUsersService.AddUserToDoc(doc.docId, request.UserId));
            }
            catch (Exception)
            {

                retval = new AppResponseError();
            }


            return retval;
        }
    }
}

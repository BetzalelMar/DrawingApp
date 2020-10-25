using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.DTO.DocsDTO;
using DrawnigContracts.DTO.DocsDTO.Response;
using DrawnigContracts.Interface;
using System;


namespace DocService
{
    [Register(Policy.Transient,typeof(IAddDocService))]
    public class AddDocService:IAddDocService
    {
        IDocDal _dal;
        IGenerateIdService _generatIdService;
        IImageService _imageService;
        IDocConvertor _convertor;
        public AddDocService(IDocDal dal,IGenerateIdService generatIdService,IImageService imageService,IDocConvertor convertor)
        {
            _dal = dal;
            _generatIdService = generatIdService;
            _imageService = imageService;
            _convertor = convertor;
        }

        public Response AddDoc(AddDocRequest request)
        {
            //TODO user  exist???????
            Response retval;
            var docId = _generatIdService.GenerateId();
            try
            {
            
                string dir = @"\final project\gitClone\DrawingApp\DrawingClient\src\assets" + "/Pictures";
                var docUrl = _imageService.storeImage(dir,docId+request.docName, request.docUrl);

                if (_dal.GetDoc(docId).Tables[0].Rows.Count!=0) retval = new AddDocResponseDocExist("Document Exist");
                request.docUrl = docUrl;
                var dbResponse = _dal.CreateDoc(docId,request).Tables[0];
                var data = _convertor.convertTableToList(dbResponse);

                retval = new AddDocResponseOk(data);
            }
            catch (Exception)
            {

                retval = new AppResponseError();
            }
            return retval;
        }
    }
}

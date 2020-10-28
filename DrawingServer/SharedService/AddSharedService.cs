using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.DTO.DocsDTO;
using DrawnigContracts.DTO.SharedDTO.SharedRequest;
using DrawnigContracts.DTO.SharedDTO.SharedResponse;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.DocInterface;
using DrawnigContracts.Interface.SharedInterface;
using System;

namespace SharedService
{
    [Register(Policy.Transient, typeof(IAddSharedService))]
    public class AddSharedService : IAddSharedService
    {
        ISharedDal _dal;
        IDocConvertor _convertor;
        IvalidatorService _validator;
        IMapDocToUsersService _docToUsersService;
        IWsAppService _wsAppService;
        public AddSharedService(ISharedDal dal,IWsAppService wsService, IDocConvertor convertor,IvalidatorService validator, IMapDocToUsersService docToUsersService,IWsAppService wsAppService)
        {
            _dal = dal;
            _convertor = convertor;
            _docToUsersService = docToUsersService;
            _validator = validator;
            _wsAppService = wsAppService;
        }

        public  Response  AddShaerd(AddSharedRequest request)
        {
            Response retval;
            if (!(this._validator.UserExist(request.sharedData.userId) && this._validator.DocExist(request.sharedData.docId)))
               retval = new AddSharedBadResponse("the system can not shaer this document " + request.sharedData.docId + "with " + request.sharedData.userId);

            else if (this._validator.SharedExist(request.sharedData.userId, request.sharedData.docId))
                retval = new AddSharedBadResponse("shared exist !!");

            else
            {
                try
                {
                    var dbResponse = this._dal.AddShared(request.sharedData).Tables[0];
                    var data = this._convertor.convertTableToList(dbResponse);
                    retval = new AddSharedResponseOk(data);
                    this._docToUsersService.AddUserToDoc(data[0].docId, request.sharedData.userId);
                    _wsAppService.sendDoc(request.sharedData.userId, data[0]);
                }
                catch (Exception)
                {
                    retval = new AppResponseError();
                }
            }
            return retval;
        }
    }
}

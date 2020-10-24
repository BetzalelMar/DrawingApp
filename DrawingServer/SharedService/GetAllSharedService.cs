using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.DTO.SharedDTO.SharedRequest;
using DrawnigContracts.DTO.SharedDTO.SharedResponse;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.SharedInterface;
using System;

namespace SharedService
{
    [Register(Policy.Transient, typeof(IGetAllSharedService))]
    public class GetAllSharedService:IGetAllSharedService
    {
        ISharedDal _dal;
        IDocConvertor _convertor;
        public GetAllSharedService(ISharedDal dal, IDocConvertor convertor)
        {
            _dal = dal;
            _convertor = convertor;
        }

        public Response GetAllSeared(GetAllSharedRequest request)
        {
            Response retval;
            //UserExsist?
            try
            {
                var dbResponse = this._dal.GetAllShared(request.userId).Tables[0];
                var data = this._convertor.convertTableToList(dbResponse);
                retval = new GetAllSharedResponseOk(data);
            }
            catch (Exception)
            {
                retval = new AppResponseError();
            }
            return retval;

        }
    }
}

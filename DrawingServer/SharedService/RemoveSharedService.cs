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
    [Register(Policy.Transient, typeof(IRemoveSharedService))]

    public class RemoveSharedService: IRemoveSharedService
    {
        ISharedDal _dal;
        IDocConvertor _convertor;
        public RemoveSharedService(ISharedDal dal, IDocConvertor convertor)
        {
            _dal = dal;
            _convertor = convertor;
        }

        public Response RemoveShaerd(RemoveShaerdRequest request)
        {
            Response retval;
            //UserExist?
            //docExist
            try
            {
                var dbResponse = this._dal.RemoveShared(request.sharedData).Tables[0];
                var data = this._convertor.convertTableToList(dbResponse);
                retval = new RemoveSharedResponseOk(data);
            }
            catch (Exception)
            {
                retval = new AppResponseError();
            }
            return retval;

        }

    }
}

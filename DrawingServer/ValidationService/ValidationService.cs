using Contracts;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.SharedInterface;
using System;
using System.Data;

namespace ValidationService
{
    [Register(Policy.Transient,typeof(IvalidatorService))]
    public class ValidationService : IvalidatorService
    {
        IDocDal   _docDal;
        IusersDal _usersDal;
        ISharedDal _sharedDal;
        public ValidationService(IDocDal docDal, IusersDal userDal ,ISharedDal sharedDal)
        {
            _docDal = docDal;
            _usersDal= userDal   ;
            _sharedDal= sharedDal;
        }

        public bool DocExist(string docId)
        {
            return this._docDal.GetDoc(docId).Tables[0].Rows.Count!=0;
        }

        public bool SharedExist(string userId,string docId)
        {
            return this._sharedDal.GetShared(userId,docId).Tables[0].Rows.Count != 0;
        }

        public bool UserExist(string userId)
        {
            return this._usersDal.GetUser(userId).Tables[0].Rows.Count != 0;
        }

    }
}

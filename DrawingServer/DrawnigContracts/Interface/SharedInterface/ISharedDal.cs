using DrawnigContracts.DTO.SharedDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DrawnigContracts.Interface.SharedInterface
{
    public interface ISharedDal
    {
        public DataSet AddShared(SharedData data);
        public DataSet RemoveShared(SharedData data);
        public DataSet GetAllShared(string userId);
        public DataSet GetShared(string userId,string docId);
    }
}

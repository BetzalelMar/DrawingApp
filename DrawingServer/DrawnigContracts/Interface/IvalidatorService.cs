using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.Interface
{
    public interface IvalidatorService
    {
        public bool DocExist(string docId);
        public bool UserExist(string userId);
        public bool SharedExist(string userId,string docId);
    }
}

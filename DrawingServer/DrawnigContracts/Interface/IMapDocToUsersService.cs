using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.Interface
{
    public interface IMapDocToUsersService
    {
        public void AddUserToDoc(string docId, string userId);
        public List<string> GetUsersByDoc(string docId);
    }
}

using Contracts;
using DrawnigContracts.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MapDocToUsersService
{
    [Register(Policy.Singleton, typeof(IMapDocToUsersService))]
    public class MapDocToUsersServiceImpl : IMapDocToUsersService
    {
        public ConcurrentDictionary<string, List<string>> _docToUsers = new ConcurrentDictionary<string, List<string>>();

        public void AddUserToDoc(string docId, string userId)
        {
            List<string> list;
            if (_docToUsers.TryGetValue(docId, out list))
            {
                if (!list.Contains(userId))
                    list.Add(userId);
                _docToUsers[docId] = list;
            }
            else
            {
                _docToUsers.TryAdd(docId, new List<string> { userId });
            }
        }

        public List<string> GetUsersByDoc(string docId)
        {
            List<string> list=null;
            if (_docToUsers.TryGetValue(docId, out list))
            {
            }
            return list;
        }
    }
}

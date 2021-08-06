using System;
using System.Collections.Generic;
using Reminder.Core.Repository;
using Reminder.StateMachine.Model;

namespace Reminder.StateMachine.Repository
{
    public class MemoryRepository : IRepository<HistoryModel>
    {
        private Dictionary<string, HistoryModel> _usersHistory = new Dictionary<string, HistoryModel>();
        
        public HistoryModel Get(string userId)
        {
            if (!_usersHistory.ContainsKey(userId)) {
                return null;
            }
            return _usersHistory[userId];
        }

        public void Save(string userId, HistoryModel model)
        {
            _usersHistory.Add(userId, model);
        }

        public bool Delete(string userId)
        {
            /*когд-нибудь допишу*/
            throw new NotImplementedException("Will soon");
        }

        public bool Has(string userId)
        {
            return Get(userId) != null;
        }
    }
}
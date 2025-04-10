using api_rest.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace api_rest.Persistence.Repositories
{
    public class UserActionLogRepository
    {
        private static List<UserActionLog> logs = new List<UserActionLog>();

        public void SaveLog(UserActionLog log)
        {
            logs.Add(log);
        }

        public List<UserActionLog> GetAllLogs()
        {
            return logs.OrderByDescending(l => l.Timestamp).ToList();
        }

        public List<UserActionLog> GetLogsByUser(string userName)
        {
            return logs
                .Where(log => log.UserName != null && log.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(log => log.Timestamp)
                .ToList();
        }

    }
}
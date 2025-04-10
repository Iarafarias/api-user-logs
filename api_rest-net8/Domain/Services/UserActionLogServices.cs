using api_rest.Domain.Models;
using api_rest.Persistence.Repositories;
using System.Collections.Generic;

namespace api_rest.Domain.Services
{
    public class UserActionLogServices
    {
        private readonly UserActionLogRepository _logRepository;

        public UserActionLogServices()
        {
            _logRepository = new UserActionLogRepository();
        }

        public void RegisterLog(string userName, string action, string endpoint)
        {
            var log = new UserActionLog
            {
                UserName = userName,
                Action = action,
                Endpoint = endpoint
            };
            _logRepository.SaveLog(log);
        }

        public List<UserActionLog> GetLogs()
        {
            return _logRepository.GetAllLogs();
        }

        public void AddLog(UserActionLog log)
        {
            _logRepository.SaveLog(log);
        }

        public List<UserActionLog> GetLogsByUser(string userName)
        {
            return _logRepository.GetLogsByUser(userName);
        }
    }
}

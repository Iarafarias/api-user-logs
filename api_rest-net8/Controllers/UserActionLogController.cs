using api_rest.Domain.Models;
using api_rest.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_rest.Controllers
{
    [ApiController]
    [Route("api/logs")]
    public class UserActionLogController : ControllerBase
    {
        private readonly UserActionLogServices _logService;

        public UserActionLogController(UserActionLogServices logService)
        {
            _logService = logService;
        }

        [HttpGet]
        public IActionResult GetLogs()
        {
            var logs = _logService.GetLogs();
            return Ok(logs);
        }

        [HttpPost]
        public IActionResult CreateLog([FromBody] UserActionLog log)
        {
            if (log == null)
                return BadRequest("Dados inválidos.");

            _logService.AddLog(log);

            return Ok(log);
        }

        [HttpGet("user/{userName}")]
        public IActionResult GetLogsByUser(string userName)
        {
            var logs = _logService.GetLogsByUser(userName);
            return Ok(logs);
        }

    }

}

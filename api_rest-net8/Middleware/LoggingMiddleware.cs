using api_rest.Domain.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace api_rest.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly UserActionLogServices _logService;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
            _logService = new UserActionLogServices();
        }

        public async Task Invoke(HttpContext context)
        {
            // Captura o usuário da requisição (se existir)
            var userName = context.User.Identity?.Name ?? "Usuário Anônimo";

            // Captura a rota acessada
            var endpoint = context.Request.Path;

            // Define a ação (apenas um exemplo básico)
            string action = $"Acessou {endpoint}";

            // Registra o log
            _logService.RegisterLog(userName, action, endpoint);

            await _next(context);
        }
    }
}

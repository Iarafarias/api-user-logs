using System;

namespace api_rest.Domain.Models
{
    public class UserActionLog
    {
        public int Id { get; set; } // primary key
        public string UserName { get; set; }  // Nome do usuário que realizou a ação
        public string Action { get; set; }    // Ações realizadas
        public string Endpoint { get; set; }  // Rota acessada
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}

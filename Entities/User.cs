using Microsoft.EntityFrameworkCore;

namespace DotNet8.WebApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
    }
}

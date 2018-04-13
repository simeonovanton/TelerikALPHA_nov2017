using BlogSystem.Data.Models;
using BlogSystem.Infrastructure.Mapping;

namespace BlogSystem.DTO
{
    public class UserDto
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
    }
}
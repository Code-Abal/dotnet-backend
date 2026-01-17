using System;

namespace MyApi.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "User"; // User or Admin
        public string FullName { get; set; }
    }
}

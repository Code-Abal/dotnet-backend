using System;

namespace MyApi.Models.DTOs
{
    public class UserDto
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public Guid Id { get; set; }
    }
}

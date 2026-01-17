using DodamClip.Repositories.Auth;
using DodamClip.Models.DTOs;
using DodamClip.Models.Entities;

namespace DodamClip.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;

        public AuthService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserDto?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepo.GetByUsernameAsync(dto.Username);
            if (user == null) return null;
            // NOTE: Plain text password for demo only
            if (user.Password != dto.Password) return null;

            return new UserDto { Id = user.Id, Username = user.Username, Email = user.Email, Role = user.Role };
        }

        public async Task<UserDto> RegisterAsync(UserDto dto, string password)
        {
            var existing = await _userRepo.GetByUsernameAsync(dto.Username);
            if (existing != null) throw new InvalidOperationException("User already exists");

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = password,
                Role = dto.Role
            };

            await _userRepo.AddAsync(user);
            dto.Id = user.Id;
            return dto;
        }
    }
}
using System.Threading.Tasks;
using MyApi.Models.DTOs;
using MyApi.Repositories.Auth;
using MyApi.Models.Entities;

namespace MyApi.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;

        public AuthService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserDto> LoginAsync(LoginDto dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);
            if (user == null) return null;
            if (user.Password != dto.Password) return null; // plaintext for demo only

            return new UserDto { Id = user.Id, Email = user.Email, FullName = user.FullName, Role = user.Role };
        }

        public async Task<UserDto> RegisterAsync(LoginDto dto)
        {
            var existing = await _userRepo.GetByEmailAsync(dto.Email);
            if (existing != null) return null;

            var user = new User { Email = dto.Email, Password = dto.Password, FullName = dto.Email };
            await _userRepo.AddAsync(user);

            return new UserDto { Id = user.Id, Email = user.Email, FullName = user.FullName, Role = user.Role };
        }
    }
}

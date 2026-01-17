using DodamClip.Models.DTOs;

namespace DodamClip.Services.Auth
{
    public interface IAuthService
    {
        Task<UserDto?> LoginAsync(LoginDto dto);
        Task<UserDto> RegisterAsync(UserDto dto, string password);
    }
}
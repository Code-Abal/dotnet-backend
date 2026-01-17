using System.Threading.Tasks;
using MyApi.Models.DTOs;

namespace MyApi.Services.Auth
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(LoginDto dto);
        Task<UserDto> LoginAsync(LoginDto dto);
    }
}

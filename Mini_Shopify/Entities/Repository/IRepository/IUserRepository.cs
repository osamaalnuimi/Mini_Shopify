using Mini_Shopify.Entities.Models;
using Mini_Shopify.Entities.Models.Dto;

namespace Mini_Shopify.Entities.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO);

    }
}

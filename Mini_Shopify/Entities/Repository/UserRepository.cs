using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mini_Shopify.Entities.Data;
using Mini_Shopify.Entities.Models;
using Mini_Shopify.Entities.Models.Dto;
using Mini_Shopify.Entities.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mini_Shopify.Entities.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _applicationDb;
        private string _secretKey = "This is a random key for testing";
        public UserRepository(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
        }

        public bool IsUniqueUser(string username)
        {
           return (_applicationDb.LocalUsers.FirstOrDefault(u=> u.UserName == username) == null);
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _applicationDb.LocalUsers.FirstOrDefault(u=> u.UserName.ToLower() == loginRequestDTO.UserName.ToLower() && u.Password == loginRequestDTO.Password);

            if (user == null)
            {
                return new LoginResponseDTO()
                {
                    Token ="",
                    User = null
                };
            }
            // if user was found generate JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };
        }

        public async Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            LocalUser user = new LocalUser()
            {
                Password = registerationRequestDTO.Password,
                Role = registerationRequestDTO.Role,
                UserEmail = registerationRequestDTO.Email,
                UserName = registerationRequestDTO.UserName,
                Name = registerationRequestDTO.Name,
            };

            _applicationDb.LocalUsers.Add(user);
            await _applicationDb.SaveChangesAsync();
            user.Password = "";

            return user;
        }
    } 
}


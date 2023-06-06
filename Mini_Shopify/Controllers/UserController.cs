using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_Shopify.Entities.Models;
using Mini_Shopify.Entities.Models.Dto;
using Mini_Shopify.Entities.Repository.IRepository;
using System.Net;

namespace Mini_Shopify.Controllers
{
    [Route("api/UsersAuth")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<VillaApiController> _logger;
        private readonly IRepositoryWrapper _repository;
        
        public UserController(ILogger<VillaApiController> logger, IRepositoryWrapper repository)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequest) {
            var user = await _repository.User.Login(loginRequest);
            if (user.User == null || string.IsNullOrEmpty(user.Token)) {
                return BadRequest(new APIResponse<LoginResponseDTO> { Data = user,
                    IsSuccess = false,
                    StatusCode= (int)HttpStatusCode.BadRequest});
            }
            return Ok(new APIResponse<LoginResponseDTO> { Data = user,IsSuccess = true,StatusCode= (int)HttpStatusCode.OK});
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDTO model)
        {
              
            if (!_repository.User.IsUniqueUser(model.UserName))
            {
                return BadRequest(new APIResponse<LoginResponseDTO>
                {
                    Data = null,
                    IsSuccess = false,
                    StatusCode = (int)HttpStatusCode.BadRequest
                });
            }
            var user = await _repository.User.Register(model);
            if (user == null)
            {
                return BadRequest(new APIResponse<LocalUser>() { Data = null, IsSuccess = false, Message = "Error while registering", StatusCode = StatusCodes.Status400BadRequest });
            }
            return Ok(new APIResponse<LocalUser> { Data = user, IsSuccess = true, StatusCode = StatusCodes.Status200OK });
        }
    }
}

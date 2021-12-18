using Car.Model;
using Car.Model.User;
using Car.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Car.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        private readonly IUserService userService;
        public LoginController(IMemoryCache _memoryCache, IUserService _userService)
        {
            memoryCache = _memoryCache;
            userService = _userService;
        }

        [HttpPost]
        public General<bool> Login([FromBody] UserLoginModel loginUser)
        {
            General<bool> response = new() { Entity = false };
            General<UserViewModel> _response = userService.Login(loginUser);
            if (_response.IsSuccess)
            {
                if(!memoryCache.TryGetValue(key: $"LoginUser", out UserViewModel _loginuser))
                {
                    memoryCache.Set(key: $"LoginUser", response.Entity);
                }
                response.Entity = true;
            }
            return response;
        }

    }
}

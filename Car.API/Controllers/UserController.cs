using AutoMapper;
using Car.API.Infrastructure;
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
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService _userService, IMapper _mapper, IMemoryCache _memoryCache) : base(_memoryCache)
        {
            userService = _userService;
            mapper = _mapper;
        }

        [HttpPost]
        public General<UserViewModel> Insert([FromBody] UserCreateModel newUser)
        {
            General<UserViewModel> response = new();
            if(CurrentUser is { Id: <= 0 })
            {
                return response;
            }
            return userService.Insert(newUser);
        }

    }
}

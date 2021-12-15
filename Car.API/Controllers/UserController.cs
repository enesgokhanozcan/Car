using AutoMapper;
using Car.Model;
using Car.Model.User;
using Car.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService _userService,IMapper _mapper)
        {
            userService = _userService;
            mapper = _mapper;
        }

        [HttpPost]
        public General<UserViewModel> Insert([FromBody] UserCreateModel newUser)
        {
            var result = false;
            return userService.Insert(newUser);
        }

    }
}

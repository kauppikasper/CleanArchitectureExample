using CleanArchitectureExample.Application.Interfaces;
using CleanArchitectureExample.Application.Mappers;
using CleanArchitectureExample.Domain.Interfaces;
using CleanArchitectureExample.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureExample.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class GreetingController : ControllerBase
    {
        private readonly IGreetingService _greetingservice;

        public GreetingController(IGreetingService greetingservice)
        {
            _greetingservice = greetingservice;

        }

        [HttpGet("{name}")]

        public ActionResult<string> Get(string name)
        {
            var greeting = _greetingservice.Greet(name);
            return Ok(greeting);

        }

    }

    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IUserRegistrationService _registrationService;

        public UsersController(IUserRegistrationService RegistrationService)
        {
            _registrationService = RegistrationService;

        }

        [HttpPost]

        public IActionResult RegisterUser(string name, string email)
        {
            _registrationService.RegisterUser(name, email);

            return Ok("Rekistöityminen onnistui.");

        }

        [HttpPost("UserAsync")]

        public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegistrationRequest request)
        {
            {

                var isExistingEmail = await _registrationService.EmailExistsAsync(request.Email);

                if (isExistingEmail)
                {
                    return BadRequest("Sähköposti on jo käytössä.");
                }

                var success = await _registrationService.RegisterUserAsync(request.Name, request.Email);


                if (!success)
                {
                    return BadRequest("Rekisteröinti epäonnistui.");
                }

                return Created();

            }

        }
    }


    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var userDto = UserMapper.ToDto(user);
            return Ok(userDto);
        }
    }



}
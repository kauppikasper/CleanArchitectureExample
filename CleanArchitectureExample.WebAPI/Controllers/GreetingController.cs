using CleanArchitectureExample.Application.Interfaces;
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
}
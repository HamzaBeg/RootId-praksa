using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsWebApp.Buisness.Commands;
using NewsWebApp.Buisness.Queries;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticatiController : Controller
    {
        private readonly IMediator _dispeacher;

        public AuthenticatiController(IMediator dispeacher)
        {
            _dispeacher = dispeacher;
        }
 
        [HttpGet("/Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var response =
                await _dispeacher.Send(new Login.Query(email, password));
            if (response != null)
                return Ok(response);
            return BadRequest("Incorrect email or password, try again!");
        }

        [HttpPost("/Registration")]
        public async Task<IActionResult> Registration(Registration.CommandRegister command)
        {
            var response =
                await _dispeacher.Send(command);

            return Ok(response);
        }
    }
}
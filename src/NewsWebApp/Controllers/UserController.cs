using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsWebApp.Buisness.Commands;
using NewsWebApp.Buisness.Queries;

namespace NewsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        
        private readonly IMediator _dispeacher;

        public UserController(IMediator dispeacher)
        {
            _dispeacher = dispeacher;
        }
        [HttpGet("/GetUsers")]
        public async Task<IActionResult> GetAll()
        {
            var response =
                await _dispeacher.Send(new GetAllUsers.Query());

            return Ok(response);
        }

        [HttpPost("/AddUsers")]
        public async Task<IActionResult> AddUser(AddUser.CommandAdd command1)
        {
            var response =
                await _dispeacher.Send(command1);

            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, EditUser.CommandEdit command)
        {
            command.Id = Id;
            var response = await _dispeacher.Send(command);
            if (response != null)
                return Ok(response);
            else
                return BadRequest("User Id not found in database, try again!");
        }
    }
}
